using BlueprintCore.Blueprints.References;
using Kingmaker;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace LostChapters.Modules.HellknightCodex.Components;
internal class BlackArmy : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttackBonus>, IRulebookHandler<RuleCalculateAttackBonus>, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, IInitiatorRulebookHandler<RuleCalculateCMB>, IRulebookHandler<RuleCalculateCMB>,  ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
    {
        if (evt.Target.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic) is false)
            return;

        int bonusValue = -1;
        foreach (UnitEntityData character in Game.Instance.Player.Party)
        {
            if (character.Descriptor.HasFact(FeatureRefs.SmiteChaosFeature.Reference))
            {
                bonusValue++;
            }
        }

        if (bonusValue > 0)
        {
            evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(bonusValue, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        if (evt.Target.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic) is false)
            return;

        int bonusValue = -1;
        foreach (UnitEntityData character in Game.Instance.Player.Party)
        {
            if (character.Descriptor.HasFact(FeatureRefs.SmiteChaosFeature.Reference))
            {
                bonusValue++;
            }
        }

        if (bonusValue > 0)
        {
            evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalDamage.AddModifier(bonusValue, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventAboutToTrigger(RuleCalculateCMB evt)
    {
        if (evt.Target.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic) is false)
            return;

        int bonusValue = -1;
        foreach (UnitEntityData character in Game.Instance.Player.Party)
        {
            if (character.Descriptor.HasFact(FeatureRefs.SmiteChaosFeature.Reference))
            {
                bonusValue++;
            }
        }

        if (bonusValue > 0)
        {
            evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalCMB.AddModifier(bonusValue, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventDidTrigger(RuleCalculateAttackBonus evt) { }
    public void OnEventDidTrigger(RuleAttackWithWeapon evt) { }
    public void OnEventDidTrigger(RuleCalculateCMB evt) { }
}