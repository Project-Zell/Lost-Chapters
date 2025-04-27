using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using System.Linq;

namespace LostChapters.Modules.Custom.Components;

internal class IgnoreDesease : UnitFactComponentDelegate, IRulebookHandler<RuleDealStatDamage>, ISubscriber, ITargetRulebookHandler<RuleDealStatDamage>, ITargetRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleDealStatDamage evt)
    {
        if(evt.Target == base.Owner && evt.Initiator == base.Owner) 
        {
            if(evt.Reason.Context.SpellDescriptor == SpellDescriptor.Disease)
            {
                evt.Immune = true;
            }
        }
    }

    public void OnEventDidTrigger(RuleDealStatDamage evt)
    {
        foreach (var buff in base.Owner.Buffs)
        {
            if (buff.Context.SpellDescriptor == SpellDescriptor.Disease)
            {
                var list = buff.Blueprint.Components.ToList();
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] is BuffStatusCondition)
                    {
                        list.RemoveAt(i);
                    }
                }
                buff.Blueprint.Components = [.. list];
            }
        }
    }
}