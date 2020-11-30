using KHSave.Attributes;
using KHSave.Lib2.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Kh2.Interfaces;
using System.Collections.Generic;
using Xe.Tools;

namespace KHSave.SaveEditor.Kh2.Models
{
    public class AbilityModel : BaseNotifyPropertyChanged
    {
        private readonly int _index;
        private readonly ushort[] _abilities;
        private readonly IResourceGetter _resourceGetter;

        public AbilityModel(int index, ushort[] abilities, IResourceGetter resourceGetter)
        {
            _index = index;
            _abilities = abilities;
            _resourceGetter = resourceGetter;
        }

        public IEnumerable<EnumIconTypeModel<EquipmentType>> Abilities => _resourceGetter.Abilities;

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
                OnPropertyChanged(nameof(Active));
            }
        }

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
