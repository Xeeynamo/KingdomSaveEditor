using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHSave.LibDDD.Model
{
    public interface IDeck
    {
        public byte[] Unk01 { get; set; }
        public byte[] Name { get; set; }
        public byte[] Unk02 { get; set; }
    }
}
