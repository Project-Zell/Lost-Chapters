using BlueprintCore.Utils;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;

internal class OrderOfTheChainsDocrtine : UnitFactComponentDelegate, IRulebookHandler<RuleCombatManeuver>, IInitiatorRulebookHandler<RuleCombatManeuver>, IInitiatorRulebookSubscriber, ISubscriber
{
    public void OnEventAboutToTrigger(RuleCombatManeuver evt)
    {
        if (evt.Type is not CombatManeuver.Trip)
            return;

        var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
        var bonus = Owner.HasFact(buff) ? 4 : 2;

        evt.AddModifier(bonus, Fact, ModifierDescriptor.None);
    }

    public void OnEventDidTrigger(RuleCombatManeuver evt) { }
}
