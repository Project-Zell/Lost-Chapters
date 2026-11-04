using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;

namespace LostChapters.Components;

internal class SimpleAbilityParams : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber
{
    public int BaseValue = 10;
    public StatType Stat = StatType.Charisma;
    public BlueprintCharacterClass CharacterClass = CharacterClassRefs.FighterClass.Reference;
    public int ClassLevelDivider = 2;

    public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
    {
        if (evt.Initiator != base.Owner)
            return;

        var statBonus = evt.Initiator.Stats.GetAttribute(Stat).Bonus;
        var classLevel = evt.Initiator.Progression.GetClassLevel(CharacterClass);

        evt.ReplaceDC = 350 + BaseValue + statBonus + classLevel / ClassLevelDivider;
    }

    public void OnEventDidTrigger(RuleCalculateAbilityParams evt) { }
}