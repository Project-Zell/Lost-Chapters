using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

namespace LostChapters.Components;

internal class ChangeDCToClassLevelPlusStatBonus : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber
{
    public BlueprintAbility Spell;
    public string ClassGuid;
    public StatType Stat;
    public int BaseDC = 10;
    public bool HalfClassLevel = false;

    public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
    {
        if(evt.Spell == Spell)
        {
            var classLevel = evt.Initiator.Progression.GetClassLevel(BlueprintTool.Get<BlueprintCharacterClass>(ClassGuid));
            evt.ReplaceDC = BaseDC + evt.Initiator.Stats.GetAttribute(Stat).Bonus + (HalfClassLevel ? classLevel / 2 : classLevel);
        }
    }

    public void OnEventDidTrigger(RuleCalculateAbilityParams evt) { }
}