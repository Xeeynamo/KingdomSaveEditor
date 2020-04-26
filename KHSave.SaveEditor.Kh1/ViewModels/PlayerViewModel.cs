using KHSave.Attributes;
using KHSave.Lib1.Models;
using KHSave.Lib1.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class PlayerViewModel
    {
        private readonly Character character;
        private readonly int index;

        public PlayerViewModel(Character character, int index)
        {
            this.character = character;
            this.index = index;
        }

        public string Name => InfoAttribute.GetInfo((PlayableCharacterType)index);
    }
}
