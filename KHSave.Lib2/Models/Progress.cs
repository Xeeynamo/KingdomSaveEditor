using Xe.BinaryMapper;

namespace KHSave.Lib2.Models
{
    public class Progress
    {
        [Data(Count = 0x20)] public byte[] Flags { get; set; }

        public bool GetFlag(int index) => (Flags[index / 8] & (1 << (index % 8))) != 0;
        public void SetFlag(int index, bool value)
        {
            var mask = (byte)(1 << (index % 8));
            if (value)
                Flags[index / 8] |= mask;
            else
                Flags[index / 8] &= (byte)~mask;
        }
    }
}
