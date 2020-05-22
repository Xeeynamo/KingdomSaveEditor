using System;
using System.IO;
using Xe.BinaryMapper;

namespace KHSave.Lib1
{
    public partial class SaveKh1
    {

        internal static IBinaryMapping Mapper;

        static SaveKh1()
        {
            Mapper = MappingConfiguration
                .DefaultConfiguration()
                .ForType<TimeSpan>(
                    x => new TimeSpan(0, 0, 0, x.Reader.ReadInt32(), 0),
                    x => x.Writer.Write((int)((TimeSpan)x.Item).TotalSeconds)
                )
                .Build();
        }

        public static bool IsValid(Stream stream)
        {
            var prevPosition = stream.Position;
            var magicCode = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            switch (magicCode)
            {
                case Constants.MagicCodeFm:
                case Constants.MagicCodeEverythingElse:
                    return true;
                default:
                    return false;
            }
        }

        public static uint GetGameVersion(Stream stream)
        {
            if (!IsValid(stream))
                return 0;

            var prevPosition = stream.Position;
            stream.Position = 0;
            var version = new BinaryReader(stream).ReadUInt32();
            stream.Position = prevPosition;

            return version;
        }

        private static TSaveKh1 Read<TSaveKh1>(Stream stream)
            where TSaveKh1 : class, ISaveKh1 =>
            BinaryMapping.ReadObject<TSaveKh1>(stream.SetPosition(0));

        public static ISaveKh1 Read(Stream stream)
        {
            switch (GetGameVersion(stream))
            {
                case Constants.MagicCodeFm:
                    return Read<SaveFinalMix>(stream);
                case Constants.MagicCodeEverythingElse:
                    return Read<SaveEU>(stream);
                default:
                    throw new NotSupportedException("The version is not supported.");
            }
        }
    }
}
