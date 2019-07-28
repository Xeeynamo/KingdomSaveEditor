using System;
using System.Collections.Generic;
using Xe.BinaryMapper;

namespace KHSave.LibRecom.Models
{
    public class TutorialFlags
    {
        [Data] public int Data { get; set; }
        [Data(0)] public bool KeyRoom { get; set; }
        [Data] public bool MoogleShop { get; set; }
        [Data] public bool FloorMove { get; set; }
        [Data] public bool WarpPoint { get; set; }
        [Data] public bool SavePoint { get; set; }
        [Data] public bool Field { get; set; }
        [Data] public bool WorldSelect { get; set; }
    }
}
