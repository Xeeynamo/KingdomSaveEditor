using KHSave.LibDDD.Types;
using KHSave.SaveEditor.Common.Models;
using System;
using Xe.Tools;

namespace KHSave.SaveEditor.KhDDD.ViewModels
{
    public class CharacterViewModel : BaseNotifyPropertyChanged
    {
        public static UInt16 ReverseBytes(UInt16 value)
        {
            return (UInt16)((value & 0xFFU) << 8 | (value & 0xFF00U) >> 8);
        }

        public CharacterViewModel(EquipmentType SoraKeyblade, EquipmentType RikuKeyblade, byte SoraLv, byte RikuLv, UInt32 SoraXp, UInt32 RikuXp)
        {
            this.SoraKeyblade = new ItemComboBoxModel<EquipmentType>(() => (EquipmentType)ReverseBytes((UInt16)SoraKeyblade), x => SoraKeyblade = (EquipmentType)ReverseBytes((UInt16)x));
            this.RikuKeyblade = new ItemComboBoxModel<EquipmentType>(() => (EquipmentType)ReverseBytes((UInt16)RikuKeyblade), x => RikuKeyblade = (EquipmentType)ReverseBytes((UInt16)x));
            this.SoraXp = SoraXp;
            this.RikuXp = RikuXp;
            this.SoraLv = SoraLv;
            this.RikuLv = RikuLv;
        }

        //Todo: find cleaner way to fix endian problem
        public ItemComboBoxModel<EquipmentType> SoraKeyblade { get; set; }
        public ItemComboBoxModel<EquipmentType> RikuKeyblade { get; set; }
        public byte SoraLv { get; set; }
        public byte RikuLv { get; set; }
        public UInt32 SoraXp { get; set; }
        public UInt32 RikuXp { get; set; }
    }
}
