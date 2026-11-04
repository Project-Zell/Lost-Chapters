using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.Utility;
using System.Linq;

namespace LostChapters.Components;

internal class NegateBuffApply : UnitBuffComponentDelegate, IInitiatorRulebookHandler<RuleCanApplyBuff>, IInitiatorRulebookSubscriber
{
    public BlueprintBuff[] NegateBuffs;

    public void OnEventAboutToTrigger(RuleCanApplyBuff evt)
    {
        if (NegateBuffs.Contains(evt.Blueprint))
        {
            evt.CanApply = false;
        }
    }

    public void OnEventDidTrigger(RuleCanApplyBuff evt) { }
}