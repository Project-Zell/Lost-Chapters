using BlueprintCore.Utils;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;

internal class OrderOfTheWallDoctrine : UnitFactComponentDelegate, ITargetRulebookHandler<RuleCalculateCMD>, IRulebookHandler<RuleCalculateCMD>, ISubscriber, ITargetRulebookSubscriber
{
    private readonly CombatManeuver[] _maneuvers = [CombatManeuver.Trip, CombatManeuver.BullRush];

    public void OnEventAboutToTrigger(RuleCalculateCMD evt)
    {

        foreach (CombatManeuver combatManeuver in _maneuvers)
        {
            if (evt.Type == combatManeuver)
            {
                var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
                var bonus = Owner.HasFact(buff) ? 4 : 2;

                evt.AddModifier(bonus, Fact, ModifierDescriptor.None);
                break;
            }
        }
    }

    public void OnEventDidTrigger(RuleCalculateCMD evt) { }
}
