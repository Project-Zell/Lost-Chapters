using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Tools;
using System.Linq;

namespace LostChapters.Modules.Custom.Components;

internal class OrderOfTheBlueRoseChallenge : UnitFactComponentDelegate, ISubscriber, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleCalculateCMD>, IRulebookHandler<RuleCalculateCMD>
{
    public void OnEventAboutToTrigger(RuleCalculateCMD evt)
    {
        if (Toolbox.IsTargetHasBuffFromCaster(evt.Initiator.Buffs, BuffRefs.CavalierChallengeBuffTarget.Reference, evt.Target)
            && evt.Target.CombatState.EngagedUnits.Contains(evt.Target)
            && evt.Target == Owner)
        {
            var bonus = 1 + evt.Target.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;
            evt.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable);
        }
    }

    public void OnEventDidTrigger(RuleCalculateCMD evt) { }
}

