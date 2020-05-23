using KHSave.Lib2.Types;

namespace KHSave.Lib2.Models
{
    public interface ICharacter
    {
        EquipmentType Weapon { get; set; }
        short Unk02 { get; set; }
        byte HpCur { get; set; }
        byte HpMax { get; set; }
        byte MpCur { get; set; }
        byte MpMax { get; set; }
        byte ApBoost { get; set; }
        byte StrengthBoost { get; set; }
        byte MagicBoost { get; set; }
        byte DefenseBoost { get; set; }
        byte Unk0c { get; set; }
        byte Unk0d { get; set; }
        byte Unk0e { get; set; }
        byte Level { get; set; }
        byte ArmorCount { get; set; }
        byte AccessoryCount { get; set; }
        byte ItemCount { get; set; }
        byte UnknownCount { get; set; }
        short[] Armors { get; set; }
        short[] Accessories { get; set; }
        short[] Items { get; set; }
        short[] ItemAutoReload { get; set; }

        ushort[] Abilities { get; set; }

        BattleStyleType BattleStyle { get; set; }
        AbilityStyleType AbilityStyle1 { get; set; }
        AbilityStyleType AbilityStyle2 { get; set; }
        AbilityStyleType AbilityStyle3 { get; set; }
        AbilityStyleType AbilityStyle4 { get; set; }
    }
}
