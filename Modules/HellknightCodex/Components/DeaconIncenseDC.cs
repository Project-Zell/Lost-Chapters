using BlueprintCore.Blueprints.References;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class DeaconIncenseDC : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
        {
            evt.ReplaceDC = 10 + evt.Initiator.Stats.Wisdom.Bonus + evt.Initiator.Progression.GetClassLevel(CharacterClassRefs.WarpriestClass.Reference) / 2;
        }

        public void OnEventDidTrigger(RuleCalculateAbilityParams evt) { }
    }
}
