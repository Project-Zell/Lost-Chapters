using BlueprintCore.Blueprints.References;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class SeekingJustice : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleInitiativeRoll>, IRulebookHandler<RuleInitiativeRoll>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleInitiativeRoll evt)
        {
            if (evt.Initiator != Owner) return;

            if (Owner.Resources.GetResourceAmount(AbilityResourceRefs.SmiteChaosResource.Reference.Get()) is 0)
            {
                Owner.Descriptor.Resources.Restore(AbilityResourceRefs.SmiteChaosResource.Reference.Get(), 1);
            }
        }

        public void OnEventDidTrigger(RuleInitiativeRoll evt) { }
    }
}
