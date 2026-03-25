using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Tools;
using System.Linq;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class Rockslide : UnitFactComponentDelegate, ISubscriber, IGlobalRulebookSubscriber, IGlobalRulebookHandler<RuleCombatManeuver>, IRulebookHandler<RuleCombatManeuver>
{
    public void OnEventAboutToTrigger(RuleCombatManeuver evt)
    {

    }

    public void OnEventDidTrigger(RuleCombatManeuver evt)
    {
        var maybeCaster = base.Context.MaybeCaster;

        if (evt.Target.CombatState.EngagedBy.Contains(maybeCaster) is false || evt.Initiator.IsPlayersEnemy ||
            evt.Initiator == base.Owner || evt.Type is not CombatManeuver.Trip || evt.Success is false)
            return;

        var swiftAidBuff = BlueprintTool.Get<BlueprintBuff>(SwiftAid.AttackBuff.Guid);
        var aidAnotherBuff = BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.AttackBuff.Guid);

        if(Toolbox.IsTargetHasBuffFromCaster(evt.Initiator.Buffs, [swiftAidBuff, aidAnotherBuff], maybeCaster))
        {
            Game.Instance.CombatEngagementController.ForceAttackOfOpportunity(attacker: maybeCaster, target: evt.Target);
        }
    }
}
