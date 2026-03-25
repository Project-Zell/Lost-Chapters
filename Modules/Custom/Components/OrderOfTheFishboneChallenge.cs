using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Components;

internal class OrderOfTheFishboneChallenge : UnitBuffComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, IInitiatorRulebookSubscriber, ISubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        if (Toolbox.IsTargetHasBuffFromCaster(evt.Initiator.Buffs, BuffRefs.CavalierChallengeBuffTarget.Reference, Context.MaybeCaster))
        {
            var bonus = 1 + Context.MaybeCaster.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;
            evt.AddTemporaryModifier(evt.Initiator.Stats.SaveReflex.AddModifier(-bonus, Fact, ModifierDescriptor.Circumstance));
        }
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}
