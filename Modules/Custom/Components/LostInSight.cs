using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;

namespace LostChapters.Modules.Custom.Components;

internal class LostInSight : UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>, ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleCalculateAC>, IRulebookHandler<RuleCalculateAC>
{
    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting) is false)
            return;

        if (evt.Target == Owner && evt.IsAttackOfOpportunity)
        {
            Data.ACModifier = 4;
            Data.Initiator = evt.Initiator;
        }
    }

    public void OnEventAboutToTrigger(RuleCalculateAC evt)
    {
        if (Data.Initiator != null && evt.Initiator == Data.Initiator)
        {
            evt.AddModifier(Data.ACModifier, Fact, ModifierDescriptor.None);
        }
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
        Data.Clear();
    }

    public void OnEventDidTrigger(RuleCalculateAC evt) { }
}
