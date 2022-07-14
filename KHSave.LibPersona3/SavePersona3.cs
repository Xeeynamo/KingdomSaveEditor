using KHSave.Attributes;
using KHSave.LibPersona3.Models;
using KHSave.LibPersona3.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.BinaryMapper;

namespace KHSave.LibPersona3
{
    [Flags]
    public enum GameVersion
    {
        Vanilla = 1,
        FES = 2,
        Portable = 4,
    }

    public enum TimeOfTheDay : byte
    {
        [Info("Late Night?")] Default,
        [Info("Early morning")] EarlyMorning,
        [Info] Morning,
        [Info] Lunchtime,
        [Info] Afternoon,
        [Info("After School")] AfterSchool,
        [Info] Evening,
        [Info("Late Night")] LateNight,
        [Info("Dark Hour")] DarkHour,
    }
    
    public enum McStatus : short
    {
        [Info] Good,
        [Info("-")] Status01,
        [Info] Great,
        [Info] Tired,
        [Info("-")] Status04,
        [Info] Sick
    }

    public class SavePersona3
    {
        public enum SectionType
        {
            End = -1,
            Header,

            SocialLinks = 3,
            Inventory = 7,
            CalendarDisplay = 8,
            TimeOfTheDay = 9,
            Calendar = 11,
            Unknown12,

            EquippedPersona = 14,
            Persona,
            Compendium,
            GameFlags,
            Money,
            BattlePartyMembers,
            Unknown20,
            FieldZone,
            FieldZoneRoom,
            ForceTartarus,

            PortableInventory = 6,
        }

        private enum Flags
        {
            FemaleProtagonist = 4103,
        }
        
        internal static IBinaryMapping Mapper;

        static SavePersona3()
        {
            Mapper = MappingConfiguration
                .DefaultConfiguration(Encoding.UTF8)
                .Build();
        }

        public readonly Dictionary<SectionType, byte[]> Sections = new();

        public GameVersion Version { get; private set; }

        public short[] ExpendableItems { get; private set; }
        public TimeOfTheDay TimeOfTheDay { get; set; }
        public short CalendarDate { get; set; }
        public byte Unknown12 { get; set; }
        public short EquippedPersona { get; set; }
        public Persona[] Persona { get; private set; }
        public Persona[] Compendium { get; private set; }
        public SocialLinks SocialLinks { get; set; }
        public SocialLinksPortable SocialLinksPortable { get; set; }

        public int Money { get; set; }
        public Characters BattlePartyMember1 { get; set; }
        public Characters BattlePartyMember2 { get; set; }
        public Characters BattlePartyMember3 { get; set; }
        public Characters BattlePartyMember4 { get; set; }
        public int Unknown20 { get; set; }
        public int FieldZone { get; set; }
        public int FieldZoneRoom { get; set; }
        public bool ForceTartarus { get; set; }

        // Game flags
        public bool IsFemaleProtagonist { get; set; }

        private SavePersona3(Stream stream)
        {
            var reader = new BinaryReader(stream);
            var gameIdentifier = reader.ReadInt32();
            if (gameIdentifier == 3)
            {
                Sections[SectionType.Header] = reader.ReadBytes(0x34);
                Version = GameVersion.Vanilla;
            }
            else if (gameIdentifier == 0)
            {
                Version = GameVersion.Portable;
            }
            else
                throw new Exception("This Persona 3 save is not recognized.");

            SectionType sectionId;
            while (true)
            {
                sectionId = (SectionType)reader.ReadInt32();
                if (sectionId == SectionType.End)
                    break;
                var length = reader.ReadInt32();
                Sections[sectionId] = reader.ReadBytes(length);
            }

            Task.WaitAll(
                Task.Run(() =>
                {
                    ReadSectionInt16(SectionType.CalendarDisplay); // ignore
                    TimeOfTheDay = (TimeOfTheDay)ReadSectionByte(SectionType.TimeOfTheDay);
                    CalendarDate = ReadSectionInt16(SectionType.Calendar);
                    Unknown12 = ReadSectionByte(SectionType.Unknown12);
                    EquippedPersona = ReadSectionInt16(SectionType.EquippedPersona);
                    Money = ReadSectionInt32(SectionType.Money);
                    Unknown20 = ReadSectionInt32(SectionType.Unknown20);
                    FieldZone = ReadSectionInt32(SectionType.FieldZone);
                    FieldZoneRoom = ReadSectionInt32(SectionType.FieldZoneRoom);
                    ForceTartarus = ReadSectionInt32(SectionType.ForceTartarus) != 0;
                }),
                Task.Run(() =>
                {
                    IsFemaleProtagonist = GetGameFlag(Flags.FemaleProtagonist);
                }),
                Task.Run(() =>
                {
                    if (Sections.TryGetValue(SectionType.SocialLinks, out var data))
                    {
                        switch (data.Length)
                        {
                            case 0x430:
                                SocialLinksPortable = TryReadSection<SocialLinksPortable>(SectionType.SocialLinks);
                                break;
                            case 0x508:
                                SocialLinks = TryReadSection<SocialLinks>(SectionType.SocialLinks);
                                break;
                        }
                    }
                }),
                Task.Run(() =>
                {
                    if (Version == GameVersion.Portable)
                    {
                        using var stream = new MemoryStream(Sections[SectionType.PortableInventory]);
                        using var reader = new BinaryReader(stream);
                        ExpendableItems = new short[(int)stream.Length / sizeof(byte)];
                        for (var i = 0; i < ExpendableItems.Length; i++)
                            ExpendableItems[i] = reader.ReadByte();
                    }
                    else
                    {
                        using var stream = new MemoryStream(Sections[SectionType.Inventory]);
                        using var reader = new BinaryReader(stream);
                        ExpendableItems = new short[(int)stream.Length / sizeof(short)];
                        for (var i = 0; i < ExpendableItems.Length; i++)
                            ExpendableItems[i] = reader.ReadInt16();
                    }
                }),
                Task.Run(() => Persona = ReadSectionArray<Persona>(SectionType.Persona)),
                Task.Run(() => Compendium = ReadSectionArray<Persona>(SectionType.Compendium)),
                Task.Run(() =>
                {
                    using var stream = new MemoryStream(Sections[SectionType.BattlePartyMembers]);
                    using var reader = new BinaryReader(stream);
                    BattlePartyMember1 = (Characters)reader.ReadInt16();
                    BattlePartyMember2 = (Characters)reader.ReadInt16();
                    BattlePartyMember3 = (Characters)reader.ReadInt16();
                    BattlePartyMember4 = (Characters)reader.ReadInt16();
                })
            );

            var path = $"D:\\{Version}";
            Directory.CreateDirectory(path);
            foreach (var s in Sections)
            {
                using var _stream = File.Create($"{path}\\{(int)s.Key}");
                var _writer = new BinaryWriter(_stream);
                _writer.Write((int)s.Key);
                _writer.Write(s.Value.Length);
                _writer.Write(s.Value);
            }
        }

        public static SavePersona3 Read(Stream stream) => new(stream);

        public static bool IsValid(Stream stream)
        {
            stream.Position = 0;
            var reader = new BinaryReader(stream);
            var result = IsValidInternal(reader);
            stream.Position = 0;
            return result;
        }

        private static bool IsValidInternal(BinaryReader reader)
        {
            switch (reader.ReadInt32())
            {
                case 0:
                    break;
                case 3:
                    reader.BaseStream.Position += 0x34;
                    break;
                default:
                    return false;
            }

            while (true)
            {
                if ((SectionType)reader.ReadInt32() == SectionType.End)
                    return true;

                var length = reader.ReadInt32();
                if (length < 0)
                    return false;

                reader.BaseStream.Position += length;
                if (reader.BaseStream.Position > reader.BaseStream.Length)
                    return false;
            }
        }

        public void Write(Stream stream)
        {
            var writer = new BinaryWriter(stream);
            switch (Version)
            {
                case GameVersion.Vanilla:
                    writer.Write(3);
                    writer.Write(Sections[SectionType.Header]);
                    break;
                case GameVersion.Portable:
                    writer.Write(0);
                    break;
                default:
                    throw new Exception("This Persona 3 save is not allowed to be saved. Save Editor bug?");
            }

            Task.WhenAll(
                Task.Run(() =>
                {
                    WriteSection(SectionType.CalendarDisplay, CalendarDate);
                    WriteSection(SectionType.TimeOfTheDay, (byte)TimeOfTheDay);
                    WriteSection(SectionType.Calendar, CalendarDate);
                    WriteSection(SectionType.Unknown12, Unknown12);
                    WriteSection(SectionType.EquippedPersona, EquippedPersona);
                    WriteSection(SectionType.Money, Money);
                    WriteSection(SectionType.Unknown20, Unknown20);
                    WriteSection(SectionType.FieldZone, FieldZone);
                    WriteSection(SectionType.FieldZoneRoom, FieldZoneRoom);
                    WriteSection(SectionType.ForceTartarus, ForceTartarus ? 1 : 0);
                }),
                Task.Run(() =>
                {
                    SetGameFlag(Flags.FemaleProtagonist, IsFemaleProtagonist);
                }),
                Task.Run(() =>
                {
                    MemoryStream stream;
                    if (SocialLinksPortable != null)
                    {
                        stream = new MemoryStream(0x430);
                        Mapper.WriteObject(stream, SocialLinksPortable);
                    }
                    else
                    {
                        stream = new MemoryStream(0x508);
                        Mapper.WriteObject(stream, SocialLinks);
                    }
                    Sections[SectionType.Inventory] = stream.GetBuffer();
                }),
                Task.Run(() =>
                {
                    if (Version == GameVersion.Portable)
                    {
                        using var stream = new MemoryStream(Sections[SectionType.PortableInventory]);
                        using var writer = new BinaryWriter(stream);
                        for (int i = 0; i < ExpendableItems.Length; i++)
                            writer.Write((byte)ExpendableItems[i]);
                    }
                    else
                    {
                        using var stream = new MemoryStream(Sections[SectionType.Inventory]);
                        using var writer = new BinaryWriter(stream);
                        for (int i = 0; i < ExpendableItems.Length; i++)
                            writer.Write(ExpendableItems[i]);
                    }
                }),
                Task.Run(() => WriteSection(SectionType.Persona, Persona)),
                Task.Run(() => WriteSection(SectionType.Compendium, Compendium)),
                Task.Run(() =>
                {
                    using var stream = new MemoryStream(Sections[SectionType.BattlePartyMembers]);
                    using var writer = new BinaryWriter(stream);
                    writer.Write((short)BattlePartyMember1);
                    writer.Write((short)BattlePartyMember2);
                    writer.Write((short)BattlePartyMember3);
                    writer.Write((short)BattlePartyMember4);
                })
            );

            foreach (var section in Sections.OrderBy(x => x.Key))
            {
                if (section.Key == SectionType.Header)
                    continue;

                writer.Write((int)section.Key);
                writer.Write(section.Value.Length);
                writer.Write(section.Value);
            }
            writer.Write((int)SectionType.End);

            if (Version == GameVersion.Portable)
            {
                var dummyData = new byte[0x4000];
                writer.Write(dummyData);
                writer.Write(dummyData);
                writer.Write(dummyData);
                writer.Write(dummyData);
            }
        }

        public void ConvertToPortable()
        {
            Sections.Remove(SectionType.Header);
            // TODO fix 3
            // TODO fix inventory
            // TODO fix 26
            // TODO fix 30
            // TODO fix 31
        }

        private bool GetGameFlag(Flags flagId)
        {
            if (!Sections.TryGetValue(SectionType.GameFlags, out var data))
                return default;
            var index = (int)flagId / 8;
            if (index > data.Length)
                return default;
            return (data[index] & (1 << ((int)flagId & 7))) != 0;
        }

        private void SetGameFlag(Flags flagId, bool value)
        {
            if (!Sections.TryGetValue(SectionType.GameFlags, out var data))
                return;
            var index = (int)flagId / 8;
            if (index > data.Length)
                return;
            if (value)
                data[index] = (byte)(data[index] | (1 << ((int)flagId & 7)));
            else
                data[index] = (byte)(data[index] & ~(1 << ((int)flagId & 7)));
        }

        private byte ReadSectionByte(SectionType section) => TryReadSection(section, reader => reader.ReadByte());
        private short ReadSectionInt16(SectionType section) => TryReadSection(section, reader => reader.ReadInt16());
        private int ReadSectionInt32(SectionType section) => TryReadSection(section, reader => reader.ReadInt32());
        private T[] ReadSectionArray<T>(SectionType section) where T : class
        {
            using var stream = new MemoryStream(Sections[section]);
            var list = new List<T>();

            var prevPosition = -1L;
            while (stream.Position < stream.Length && prevPosition < stream.Position)
            {
                prevPosition = stream.Position;
                list.Add(Mapper.ReadObject<T>(stream, (int)stream.Position));
            }
            return list.ToArray();
        }

        private void WriteSection(SectionType section, byte value) => TryWriteSection(section, writer => writer.Write(value));
        private void WriteSection(SectionType section, short value) => TryWriteSection(section, writer => writer.Write(value));
        private void WriteSection(SectionType section, int value) => TryWriteSection(section, writer => writer.Write(value));
        private void WriteSection<T>(SectionType section, T[] array) where T : class
        {
            using var stream = new MemoryStream(Sections[section]);
            foreach (var item in array)
                Mapper.WriteObject<T>(stream, item, (int)stream.Position);
        }

        private T TryReadSection<T>(SectionType section, Func<BinaryReader, T> actionReader)
        {
            if (!Sections.TryGetValue(section, out var data))
                return default;
            using var stream = new MemoryStream(data);
            return actionReader(new BinaryReader(stream));
        }

        private T TryReadSection<T>(SectionType section) where T : class
        {
            if (!Sections.TryGetValue(section, out var data))
                return default;
            using var stream = new MemoryStream(data);
            return Mapper.ReadObject<T>(stream);
        }

        private void TryWriteSection(SectionType section, Action<BinaryWriter> actionWriter)
        {
            if (!Sections.TryGetValue(section, out var data))
                return;
            using var stream = new MemoryStream(data);
            actionWriter(new BinaryWriter(stream));
        }
    }
}
