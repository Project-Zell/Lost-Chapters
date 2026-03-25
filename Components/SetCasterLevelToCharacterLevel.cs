using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace LostChapters.Components;

internal class SetCasterLevelToCharacterLevel : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber
{
    public BlueprintAbility Spell;

    public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
    {
        if (evt.Spell == Spell)
            evt.ReplaceCasterLevel = 1; //evt.Initiator.Progression.m_CharacterLevel;
    }

    public void OnEventDidTrigger(RuleCalculateAbilityParams evt) { }
}
