using KHSave.LibPersona5.Models;
using System;
using System.IO;
using System.Text;
using Xe.BinaryMapper;

namespace KHSave.LibPersona5
{
    public interface ISavePersona5
    {
        bool IsRoyal { get; }
        string ProtagonistLastName { get; set; }
        string ProtagonistFirstName { get; set; }
        int Money { get; set; }
        bool PartyModifierRyuji { get; set; }
        bool PartyModifierMorgana { get; set; }
        bool PartyModifierAnn { get; set; }
        bool PartyModifierYusuke { get; set; }
        bool PartyModifierMakoto { get; set; }
        bool PartyModifierHaru { get; set; }
        bool PartyModifierFutaba { get; set; }
        bool PartyModifierAkechi { get; set; }
        float PositionX { get; set; }
        float PositionY { get; set; }
        float PositionZ { get; set; }
        short RoomCategory { get; set; }
        short RoomMap { get; set; }
        Character[] Characters { get; set; }
    }

    public class SavePersona5
    {
        private const int Persona5Identifier = 0x0e000000;
        private const int Persona5RoyalIdentifier = 0x2d000000;
        internal static IBinaryMapping Mapper;

        static SavePersona5()
        {
            Mapper = MappingConfiguration
                .DefaultConfiguration(Encoding.UTF8, true)
                .ForType<string>(ReadString, WriteString)
                .ForType<float>(ReadFloat, WriteFloat)
                .Build();
        }

        public static bool IsValid(Stream stream)
        {
            switch (GetGameIdentifier(stream.SetPosition(0)))
            {
                case Persona5Identifier:
                    return stream.Length == 192 * 1024;
                case Persona5RoyalIdentifier:
                    return stream.Length == 256 * 1024;
            }
            return false;
        }

        public static ISavePersona5 Read(Stream stream)
        {
            switch (GetGameIdentifier(stream.SetPosition(0)))
            {
                case Persona5Identifier:
                    return Mapper.ReadObject<Persona5Vanilla>(stream.SetPosition(0));
                case Persona5RoyalIdentifier:
                    return Mapper.ReadObject<Persona5Royal>(stream.SetPosition(0));
                default:
                    throw new NotImplementedException("The version has been recognized but it is not supported.");
            }
        }

        public static void Write<TSavePersona5>(Stream stream, TSavePersona5 save)
            where TSavePersona5 : class, ISavePersona5
        {
            Mapper.WriteObject(stream.FromBegin(), save);
        }

        private static TSavePersona5 Read<TSavePersona5>(Stream stream)
            where TSavePersona5 : class, ISavePersona5 =>
            Mapper.ReadObject<TSavePersona5>(stream.FromBegin());

        private static int GetGameIdentifier(Stream stream) =>
            new BinaryReader(stream).ReadInt32();

        private static object ReadString(MappingReadArgs arg)
        {
            var dstPosition = arg.Reader.BaseStream.Position + arg.Count * 2;
            var count = arg.Count;
            var sb = new StringBuilder(count);
            for (var i = 0; i < count; i++)
            {
                var ch = arg.Reader.ReadByte();
                if (ch == 0) break;
                if (ch != 0x80) throw new NotImplementedException($"Read P5 string: first char {ch:X02}");

                ch = arg.Reader.ReadByte();
                if (ch >= 0xc1 && ch <= 0xc1 + ('z' - 'a'))
                    sb.Append((char)(ch - 0xc1 + 'a'));
                else if (ch >= 0xa1 && ch <= 0xa1 + ('Z' - 'A'))
                    sb.Append((char)(ch - 0xa1 + 'A'));
                else
                    throw new NotImplementedException($"Read P5 string: second char {ch:X02}");
            }

            arg.Reader.BaseStream.Position = dstPosition;
            return sb.ToString();
        }

        private static void WriteString(MappingWriteArgs arg)
        {
            var index = 0;
            var str = arg.Item as string;
            var remaining = arg.Count;
            while (index < str.Length && remaining-- > 0)
            {
                var data = 0;
                var ch = str[index++];
                if (ch >= 'A' && ch <= 'Z')
                    data = ch - 'A' + 0xa1;
                else if (ch >= 'a' && ch <= 'z')
                    data = ch - 'a' + 0xc1;
                else
                    throw new NotImplementedException($"Write P5 string: can't write '{ch}'");

                arg.Writer.Write((byte)0x80);
                arg.Writer.Write((byte)data);
            }
            while (remaining-- > 0)
            {
                arg.Writer.Write((short)0);
            }
        }

        private unsafe static object ReadFloat(MappingReadArgs arg)
        {
            var data = (arg.Reader.ReadByte() << 24) |
                (arg.Reader.ReadByte() << 16) |
                (arg.Reader.ReadByte() << 8) |
                arg.Reader.ReadByte();
            return *(float*)&data;
        }

        private unsafe static void WriteFloat(MappingWriteArgs arg)
        {
            var value = (float)arg.Item;
            var data = *(int*)&value;
            arg.Writer.Write((byte)((data >> 24) & 0xff));
            arg.Writer.Write((byte)((data >> 16) & 0xff));
            arg.Writer.Write((byte)((data >> 8) & 0xff));
            arg.Writer.Write((byte)(data & 0xff));
        }
    }
}
