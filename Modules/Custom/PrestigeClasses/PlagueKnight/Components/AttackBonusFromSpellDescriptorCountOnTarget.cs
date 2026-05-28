using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Components;

internal class AttackBonusFromSpellDescriptorCountOnTarget : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber
{
    public SpellDescriptor spellDescriptor;

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        if ((evt.Initiator == base.Owner) is false)
            return;

        var bonus = Toolbox.GetSpellDescriptorCountOnUnit(evt.Target, spellDescriptor);
        evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(bonus, base.Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt) { }
}
