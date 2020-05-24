using KHSave.Lib1.Types;
using System;
using Xe.BinaryMapper;

namespace KHSave.Lib1.Models
{
    public class GummiBlock
    {
        //0xYX with Y and X having a value between 0-9, A-F will place the block outside the editor
        [Data] public byte BlockPositionYX { get; set; }
        //Range 0-9
        [Data] public byte BlockPositionZ { get; set; }
        [Data] public byte Unknown2 { get; set; }
        [Data] public byte Unknown3 { get; set; }
        [Data] public GummiBlocksType BlockID { get; set; }
        [Data] public byte Unknown4 { get; set; }
        [Data] public byte Unknown5 { get; set; }
        [Data] public byte Unknown6 { get; set; }
        [Data] public byte ColorID { get; set; }
        [Data] public byte Unknown7 { get; set; }
        [Data] public byte Unknown8 { get; set; }
        [Data] public byte Unknown9 { get; set; }
    }
}
