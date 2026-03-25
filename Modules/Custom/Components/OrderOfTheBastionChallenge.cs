using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Tools;
using System;
using System.Linq;

namespace LostChapters.Modules.Custom.Components;

internal class OrderOfTheBastionChallenge : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        if (Owner == evt.Initiator)
        {
            if (Toolbox.IsTargetHasBuffFromCaster(evt.Reason.Caster.Buffs, BuffRefs.CavalierChallengeBuffTarget.Reference, evt.Initiator)
                && evt.Reason.Caster.CombatState.EngagedUnits.Contains(Owner))
            {
                var bonus = 1 + evt.Initiator.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;

                evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(bonus, Fact, ModifierDescriptor.Morale));
                evt.AddTemporaryModifier(evt.Initiator.Stats.SaveReflex.AddModifier(bonus, Fact, ModifierDescriptor.Morale));
                evt.AddTemporaryModifier(evt.Initiator.Stats.SaveFortitude.AddModifier(bonus, Fact, ModifierDescriptor.Morale));
            }
        }
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}
