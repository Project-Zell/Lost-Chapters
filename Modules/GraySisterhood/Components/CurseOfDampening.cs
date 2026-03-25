using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class CurseOfDampening : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateDamage>, IRulebookHandler<RuleCalculateDamage>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleCalculateDamage evt)
    {
        foreach (BaseDamage item in evt.DamageBundle)
        {
            item.Dice.Modify(new DiceFormula(item.Dice.ModifiedValue.Rolls, DiceType.One), Fact);
        }
    }

    public void OnEventDidTrigger(RuleCalculateDamage evt) { }
}
