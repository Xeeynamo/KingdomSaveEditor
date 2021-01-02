using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class GummiBlockViewModel : BaseNotifyPropertyChanged
    {
        private readonly GummiBlock gummiblock;
        public GummiBlockViewModel(GummiBlock gummiBlock)
        {
            this.gummiblock = gummiBlock;
            GummiBlockTypes = new KhEnumListModel<GummiBlocksType>();
        }
        public KhEnumListModel<GummiBlocksType> GummiBlockTypes { get; set; }

        public byte BlockPositionYX { get => gummiblock.BlockPositionYX; set => gummiblock.BlockPositionYX = value; }
        public byte BlockPositionZ { get => gummiblock.BlockPositionZ; set => gummiblock.BlockPositionZ = value; }
        public byte Unknown2 { get => gummiblock.Unknown2; set => gummiblock.Unknown2 = value; }
        public byte Unknown3 { get => gummiblock.Unknown3; set => gummiblock.Unknown3 = value; }
        public GummiBlocksType BlockID { get => gummiblock.BlockID; set => gummiblock.BlockID = value; }
        public byte Unknown4 { get => gummiblock.Unknown4; set => gummiblock.Unknown4 = value; }
        public byte Unknown5 { get => gummiblock.Unknown5; set => gummiblock.Unknown5 = value; }
        public byte Unknown6 { get => gummiblock.Unknown6; set => gummiblock.Unknown6 = value; }
        public byte ColorID { get => gummiblock.ColorID; set => gummiblock.ColorID = value; }
        public byte Unknown7 { get => gummiblock.Unknown7; set => gummiblock.Unknown7 = value; }
        public byte Unknown8 { get => gummiblock.Unknown8; set => gummiblock.Unknown8 = value; }
        public byte Unknown9 { get => gummiblock.Unknown9; set => gummiblock.Unknown9 = value; }
    }
}
