using KHSave.Attributes;
using KHSave.Lib2.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh2.Models
{
    public class AbilityModel : BaseNotifyPropertyChanged
    {
        private readonly int _index;
        private readonly ushort[] _abilities;

        public AbilityModel(int index, ushort[] abilities)
        {
            _index = index;
            _abilities = abilities;
        }

        private ushort AbilityData
        {
            get => _abilities[_index];
            set => _abilities[_index] = value;
        }


        public EquipmentType AbilityType
        {
            get => (EquipmentType)(AbilityData & 0x7fff);
            set
            {
                AbilityData = (ushort)((int)value | (Active ? 0x8000 : 0));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Active));
            }
        }

        public string Name => InfoAttribute.GetInfo(AbilityType);
        public bool Active
        {
            get => AbilityData >= 0x8000;
            set
            {
                if (value)
                    AbilityData |= 0x8000;
                else
                    AbilityData &= 0x7fff;
            }
        }
    }
}
