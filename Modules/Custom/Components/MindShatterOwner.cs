using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.Custom.Archetypes.MageSlayer;
using UnityEngine;

namespace LostChapters.Modules.Custom.Components;

internal class MindShatterOwner : UnitFactComponentDelegate<AttackBonusConditional.RuntimeData>, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber, IInitiatorRulebookHandler<RuleCalculateAttackBonus>, IRulebookHandler<RuleCalculateAttackBonus>, IInitiatorRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>
{
    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        if (evt.Target.HasFact(BlueprintTool.Get<BlueprintBuff>(MindShatterFeature.Buff.Guid)) is false)
            return;

        var rankFeature = BlueprintTool.Get<BlueprintFeature>(MindShatterFeature.Guid);
        var maybeCaster = Context.MaybeOwner;

        var rankBonus = 0;
        if (maybeCaster.HasFact(rankFeature))
            rankBonus = maybeCaster.Descriptor.Progression.Features.GetRank(rankFeature);
        rankBonus = Mathf.Min(rankBonus, 5);

        Data.AttackBonus = rankBonus;
    }

    public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
    {
        if (Data.Target != null && Data.Target == evt.Target)
        {
            evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(Data.AttackBonus, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventAboutToTrigger(RuleCalculateDamage evt)
    {
        if (Data.Target != null && Data.Target == evt.Target)
        {
            evt.DamageBundle.First?.AddModifierTargetRelated(Data.AttackBonus, Fact, ModifierDescriptor.UntypedStackable);
        }
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt) { }

    public void OnEventDidTrigger(RuleCalculateAttackBonus evt) { }

    public void OnEventDidTrigger(RuleCalculateDamage evt) { }
}
