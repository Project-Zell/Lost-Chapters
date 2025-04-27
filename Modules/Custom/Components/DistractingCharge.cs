using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using LostChapters.Modules.Custom.Feats;

namespace LostChapters.Modules.Custom.Components;

internal class DistractingCharge : UnitBuffComponentDelegate, IRulebookHandler<RuleCalculateAttackBonus>, ITargetRulebookHandler<RuleCalculateAttackBonus>, ITargetRulebookSubscriber, ISubscriber
{
    public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
    {
        if (evt.Initiator.HasFact(BlueprintTool.Get<BlueprintFeature>(DistractingChargeFeature.Guid)) is false || Buff.Context.MaybeCaster == evt.Initiator)
            return;

        evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(2, Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventDidTrigger(RuleCalculateAttackBonus evt) { }
}
