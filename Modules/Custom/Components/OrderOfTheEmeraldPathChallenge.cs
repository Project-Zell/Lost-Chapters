using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Components;

internal class OrderOfTheEmeraldPathChallenge : UnitFactComponentDelegate, IRulebookHandler<RuleCombatManeuver>, IInitiatorRulebookHandler<RuleCombatManeuver>, IInitiatorRulebookSubscriber, ISubscriber
{
    public void OnEventAboutToTrigger(RuleCombatManeuver evt)
    {
        if (Toolbox.IsTargetHasBuffFromCaster(evt.Target.Buffs, BuffRefs.CavalierChallengeBuffTarget.Reference, evt.Initiator))
        {
            var bonus = 1 + evt.Initiator.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;
            evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalCMB.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventDidTrigger(RuleCombatManeuver evt) { }
}
