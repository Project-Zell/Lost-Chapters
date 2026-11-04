using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;

namespace LostChapters.Components;

internal class AddBonusToBaseAttackUpToCharacterLevel : UnitFactComponentDelegate, IUnitReapplyFeaturesOnLevelUpHandler
{
    public override void OnTurnOn()
    {
        var stat = base.Owner.Stats.GetStat(StatType.BaseAttackBonus);
        var statBonus = base.Owner.Progression.CharacterLevel - base.Owner.Stats.BaseAttackBonus;
        stat.AddModifierUnique(statBonus, base.Runtime, ModifierDescriptor.None);
    }

    public override void OnTurnOff()
    {
        base.Owner.Stats.GetStat(StatType.BaseAttackBonus).RemoveModifiersFrom(base.Runtime);
    }

    public void HandleUnitReapplyFeaturesOnLevelUp()
    {
        OnTurnOff();
        OnTurnOn();
    }
}
