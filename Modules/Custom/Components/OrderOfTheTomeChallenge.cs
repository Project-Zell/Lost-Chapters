using BlueprintCore.Blueprints.References;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Components
{
    internal class OrderOfTheTomeChallenge : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSpellResistanceCheck>, IRulebookHandler<RuleSpellResistanceCheck>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleSpellResistanceCheck evt)
        {
            if (Owner == evt.Target)
                return;

            if (Toolbox.IsTargetHasBuffFromCaster(evt.Target.Buffs, BuffRefs.CavalierChallengeBuffTarget.Reference, evt.Initiator))
            {
                var bonus = 1 + evt.Initiator.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;
                evt.AddSpellPenetration(bonus, ModifierDescriptor.UntypedStackable);
            }
        }

        public void OnEventDidTrigger(RuleSpellResistanceCheck evt) { }
    }
}
