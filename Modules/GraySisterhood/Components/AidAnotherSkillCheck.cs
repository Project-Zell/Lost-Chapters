using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.GraySisterhood.Backgrounds;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Modules.GraySisterhood.Items.Other;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class AidAnotherSkillCheck : EntityFactComponentDelegate, IRulebookHandler<RuleSkillCheck>, IInitiatorRulebookHandler<RuleSkillCheck>, ISubscriber, IInitiatorRulebookSubscriber, IUnitNewCombatRoundHandler, IUnitCombatHandler, IUnitBuffHandler
{
    private bool _initiatorInCasterRange = false;

    public void OnEventAboutToTrigger(RuleSkillCheck evt)
    {
        var maybeCaster = base.Context.MaybeCaster;
        _initiatorInCasterRange = Toolbox.IsTargetInMeleeRangeOfCaster(maybeCaster, evt.Initiator);

        if (_initiatorInCasterRange is false)
            return;

        var rankBonus = 0;
        var rankFeature = BlueprintTool.Get<BlueprintFeature>(AidAnotherFeature.SkillCheckRank.Guid);
        if (maybeCaster.HasFact(rankFeature))
            rankBonus = maybeCaster.Descriptor.Progression.Features.GetRank(rankFeature);
        rankBonus = Mathf.Min(rankBonus, 4);

        var featBonus = 0;
        if (maybeCaster.HasFact(BlueprintTool.Get<BlueprintFeature>(HelpfulFeature.Guid)))
        {
            var isTiny = maybeCaster.HasFact(RaceRefs.HalflingRace.Reference) ||
                         maybeCaster.HasFact(RaceRefs.GnomeRace.Reference);

            featBonus = isTiny ? 2 : 1;
        }

        if (maybeCaster.HasFact(BlueprintTool.Get<BlueprintFeature>(BattlefieldDiscipleBackground.Guid)))
            featBonus += 1;

        var equipmentBonus = 0;
        if (maybeCaster.HasFact(RingOfAltruismItem.Reference))
            equipmentBonus = 1;

        var bonus = 2 + rankBonus + featBonus + equipmentBonus;

        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
        foreach (var type in StatTypeHelper.Skills)
        {
            evt.AddTemporaryModifier(evt.Initiator.Stats.GetStat<ModifiableValue>(type)
                .AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventDidTrigger(RuleSkillCheck evt)
    {
        if (_initiatorInCasterRange is false)
            return;

        var buffs = evt.Initiator.Buffs;
        foreach (var buff in buffs)
        {
            if (base.Context.MaybeCaster == buff.Context.MaybeCaster && buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.SkillCheckBuff.Guid))
            {
                buff.Remove();
            }
        }
    }

    private void RemoveBuffFromUnit(UnitEntityData unit)
    {
        if (unit == Context.MaybeCaster)
        {
            var buffs = Context.MaybeOwner.Buffs;
            foreach (var buff in buffs)
            {
                if (buff.Context.MaybeCaster == unit && buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.SkillCheckBuff.Guid))
                {
                    buff.Remove();
                    break;
                }
            }
        }
    }

    public void HandleBuffDidAdded(Buff buff)
    {
        var buffs = Context.MaybeOwner.Buffs;
        foreach (var currentBuff in buffs)
        {
            if (currentBuff.Context.MaybeCaster == buff.Context.MaybeCaster && buff != currentBuff && currentBuff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.SkillCheckBuff.Guid))
            {
                currentBuff.Remove();
                break;
            }
        }
    }

    public void HandleNewCombatRound(UnitEntityData unit) => RemoveBuffFromUnit(unit);
    public void HandleUnitJoinCombat(UnitEntityData unit) => RemoveBuffFromUnit(unit);
    public void HandleUnitLeaveCombat(UnitEntityData unit) => RemoveBuffFromUnit(unit);
    public void HandleBuffDidRemoved(Buff buff) { }
}