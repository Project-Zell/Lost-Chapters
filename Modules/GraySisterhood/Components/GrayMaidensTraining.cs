using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Items.Armors;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class GrayMaidensTraining : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSkillCheck>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        var buff = BlueprintTool.Get<BlueprintFeature>(GrayMaidenItemSet.GrayMaidenPlateBuff.Guid);

        if (evt.Initiator.HasFact(buff) is false)
            return;

        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(1, Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventAboutToTrigger(RuleSkillCheck evt)
    {
        var buff = BlueprintTool.Get<BlueprintFeature>(GrayMaidenItemSet.GrayMaidenPlateBuff.Guid);

        if (evt.Initiator.HasFact(buff) is false || evt.StatType != StatType.CheckIntimidate)
            return;

        evt.AddTemporaryModifier(evt.Initiator.Stats.CheckIntimidate.AddModifier(2, Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }

    public void OnEventDidTrigger(RuleSkillCheck evt) { }
}
