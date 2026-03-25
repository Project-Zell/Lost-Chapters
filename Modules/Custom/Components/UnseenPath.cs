using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Parts;
using LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

namespace LostChapters.Modules.Custom.Components;

internal class UnseenPath : UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>, ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleCalculateAC>, IRulebookHandler<RuleCalculateAC>, IUnitCombatHandler //, IAreaActivationHandler
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

    public void HandleUnitJoinCombat(UnitEntityData unit)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting))
        {
            Owner.AddBuff(BlueprintTool.Get<BlueprintBuff>(UnseenPathFeature.Buff.Guid), Owner);
        }
    }

    public void HandleUnitLeaveCombat(UnitEntityData unit) { }
}
