using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Buffs.Components;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class InitiatorCritAutofail : UnitBuffComponentDelegate, IInitiatorRulebookHandler<RuleAttackRoll>, IRulebookHandler<RuleAttackRoll>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleAttackRoll evt)
    {
        evt.ImmuneToCriticalHit = true;
    }

    public void OnEventDidTrigger(RuleAttackRoll evt) { }
}
