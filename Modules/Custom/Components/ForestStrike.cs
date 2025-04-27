using Kingmaker.Blueprints.Area;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;

namespace LostChapters.Modules.Custom.Components;

internal class ForestStrike : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttackBonus>, IInitiatorRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting) is false)
            return;

        var bonus = evt.Weapon.Blueprint.Category == WeaponCategory.Quarterstaff ? 4 : 2;
        evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting) is false)
            return;

        var bonus = Owner.Body.PrimaryHand.Weapon.Blueprint.Category == WeaponCategory.Quarterstaff ? 4 : 2;
        evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalDamage.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventDidTrigger(RuleCalculateAttackBonus evt) { }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt) { }
}
