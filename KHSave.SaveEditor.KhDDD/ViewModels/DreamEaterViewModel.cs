using KHSave.LibDDD;
using KHSave.LibDDD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    class DreamEaterViewModel
    {
        private readonly DreamEater[] dreamEater;

        public DreamEaterViewModel(DreamEater[] dreamEater)
        {
            this.dreamEater = dreamEater;
        }
    }
}
