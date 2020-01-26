using System.IO;
using Xe.BinaryMapper;

namespace KHSave.LibRecom
{
    public class SaveKhRecom
    {
        private const int ValidMagicCode = 7;

        [Data] public int MagicCode { get; set; }
        [Data] public uint Checksum { get; set; }
        [Data] public int Length { get; set; }
        [Data] public int Zeroed { get; set; }
        public DataRecom Data { get; set; }

        public SaveKhRecom()
        {
            Data = new DataRecom();
        }

        public void Write(Stream stream)
        {
            byte[] data;
            using (var saveStream = new MemoryStream())
            {
                BinaryMapping.WriteObject(saveStream, Data);
                data = saveStream.ToArray();
            }

            MagicCode = ValidMagicCode;
            Checksum = CalculateChecksum(data);
            Length = data.Length;
            Zeroed = 0;

            BinaryMapping.WriteObject(stream, this);
            stream.Write(data, 0, Length);
        }

        public static SaveKhRecom Read(Stream stream)
        {
            var obj = BinaryMapping.ReadObject<SaveKhRecom>(stream);
            obj.Data = BinaryMapping.ReadObject<DataRecom>(stream, (int)stream.Position);

            return obj;
        }

        public static bool IsValid(Stream stream)
        {
            var prevPosition = stream.Position;
            int magicCode = new BinaryReader(stream).ReadInt32();
            stream.Position = prevPosition;

            return magicCode == ValidMagicCode && stream.Length >= 0x10;
        }


        private static uint CalculateChecksum(byte[] data)
        {
            int checksum = -1;

            for (var i = 0; i < data.Length; i++)
            {
                checksum ^= data[i] << 31;
                checksum = checksum << 1 ^ (checksum < 0 ? 0x4c11db7 : 0);
            }

            return (uint)~checksum;
        }
    }
}
