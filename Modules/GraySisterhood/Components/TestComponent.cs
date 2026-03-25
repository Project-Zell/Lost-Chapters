using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.Components;
internal class TestComponent : UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>, ITargetRulebookHandler<RuleCalculateAC>, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleCalculateAC>, ISubscriber, IRulebookHandler<RuleAttackWithWeapon>
{
    public void OnEventAboutToTrigger(RuleCalculateAC evt)
    {

    }

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        var maybeCaster = Context.MaybeCaster;

        var swiftAidArmorBuff = BlueprintTool.Get<BlueprintBuff>(SwiftAid.ArmorClassBuff.Guid);
        var aidAnotherArmorBuff = BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.ArmorClassBuff.Guid);

        if (evt.Target == maybeCaster) 
            return;

        if (Toolbox.IsTargetInMeleeRangeOfCaster(maybeCaster, evt.Target) is false || Toolbox.IsEventTargetInMeleeRange(evt) is false ||
            Toolbox.IsTargetHasBuffFromCaster(evt.Target.Buffs, [swiftAidArmorBuff, aidAnotherArmorBuff], maybeCaster) is false)
            return;

        if (evt.Initiator.Descriptor.State.Prone.Active || evt.Initiator.View.IsGetUp)
            return;

        RuleCombatManeuver ruleCombatManeuver = new (maybeCaster, evt.Initiator, CombatManeuver.Trip)
        {
            IgnoreConcealment = true
        };

        //Game.Instance.CombatEngagementController.ForceAttackOfOpportunity(maybeCaster, evt.Initiator);

        if (base.Context.TriggerRule(ruleCombatManeuver).Success)
        {

            //evt.Initiator.Hold();
        }
    }

    public void OnEventDidTrigger(RuleCalculateAC evt)
    {
        throw new System.NotImplementedException();
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
        throw new System.NotImplementedException();
    }
}