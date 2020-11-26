using KHSave.Attributes;

namespace KHSave.Lib2.Types
{
    public enum BattleStyleType : byte
    {
        [CombatStyle("Technic Attack")] TechnicAttack,
        [CombatStyle("Target Attack")] TargetAttack,
        [CombatStyle("Huddle Attack")] HuddleAttack,
        [CombatStyle("Party Attack")] PartyAttack,
        [CombatStyle("Sora Attack")] SoraAttack,
        [CombatStyle("Relentless Attack")] RentlessAttack,
    }
}
