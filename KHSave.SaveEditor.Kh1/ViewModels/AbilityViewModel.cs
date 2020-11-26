using KHSave.Lib1.Types;
using KHSave.SaveEditor.Common.Models;
using KHSave.SaveEditor.Kh1.Interfaces;

namespace KHSave.SaveEditor.Kh1.ViewModels
{
    public class AbilityViewModel
    {
        private readonly byte[] _abilities;
        private readonly int _abilityIndex;
        private readonly IGetAbilities _getAbilities;

        public AbilityViewModel(byte[] abilities, int index, IGetAbilities getAbilities)
        {
            _abilities = abilities;
            _abilityIndex = index;
            _getAbilities = getAbilities;
        }

        private byte AbilityId
        {
            get => _abilities[_abilityIndex];
            set => _abilities[_abilityIndex] = value;
        }

        public bool IsEnabled
        {
            get => AbilityId < 0x80;
            set => AbilityId = (byte)((AbilityId & 0x7F) | (value ? 0x00 : 0x80));
        }

        public AbilityType Ability
        {
            get => (AbilityType)(AbilityId & 0x7F);
            set => AbilityId = (byte)(((int)value & 0x7F) | (AbilityId & 0x80));
        }

        public string Name => Ability.ToString();

        public KhEnumListModel<AbilityType> AbilityList => _getAbilities.Abilities;
    }
}
