using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Enchantment;
using LostChapters.Modules.GraySisterhood.Backgrounds;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Modules.GraySisterhood.Items.Other;
using LostChapters.Tools;
using System;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class AidAnotherAttack : UnitFactComponentDelegate<AttackBonusConditional.RuntimeData>, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber, IInitiatorRulebookHandler<RuleCalculateAttackBonus>, IRulebookHandler<RuleCalculateAttackBonus>, IUnitNewCombatRoundHandler, IUnitCombatHandler, IUnitBuffHandler
{
    public int BasicBonus = 2;

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        var maybeCaster = base.Context.MaybeCaster;
        var targetInInitiatorMeleeRange = evt.Weapon is not null && evt.Weapon.Blueprint.IsMelee;

        if (Toolbox.IsTargetInMeleeRangeOfCaster(maybeCaster, evt.Initiator) is false || targetInInitiatorMeleeRange is false)
            return;

        var rankBonus = 0;
        var rankFeature = BlueprintTool.Get<BlueprintFeature>(AidAnotherFeature.AttackRank.Guid);

        if (maybeCaster.HasFact(rankFeature))
            rankBonus = maybeCaster.Descriptor.Progression.Features.GetRank(rankFeature);
        rankBonus = Mathf.Min(rankBonus, 5);

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
        if (maybeCaster.HasFact(BenevolentWeaponEnchantment.FeatReference))
        {
            var mainHandBonus = Toolbox.IsWeaponHasEnchantment(maybeCaster.Body.CurrentHandsEquipmentSet.PrimaryHand.MaybeWeapon.Blueprint,
                BenevolentWeaponEnchantment.Reference) ? Toolbox.GetItemEnhancementBonus(maybeCaster.Body.CurrentHandsEquipmentSet.PrimaryHand) : 0;

            var offHandBonus = Toolbox.IsWeaponHasEnchantment(maybeCaster.Body.CurrentHandsEquipmentSet.SecondaryHand.MaybeWeapon.Blueprint,
                BenevolentWeaponEnchantment.Reference) ? Toolbox.GetItemEnhancementBonus(maybeCaster.Body.CurrentHandsEquipmentSet.SecondaryHand) : 0;

            equipmentBonus = Math.Max(mainHandBonus, offHandBonus);
        }

        if (maybeCaster.HasFact(RingOfAltruismItem.Reference))
            equipmentBonus += 1;

        Data.AttackBonus = BasicBonus + rankBonus + featBonus + equipmentBonus;
        Data.Target = evt.Target;
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
        Data.Clear();

        var harryingPartners = BlueprintTool.Get<BlueprintFeature>(HarryingPartnersFeature.Guid);

        var hasHarryingPartners = evt.Initiator.HasFact(harryingPartners) && Context.MaybeCaster.HasFact(harryingPartners);
        var targetInMeleeRange = evt.Weapon is not null && evt.Weapon.Blueprint.IsMelee;

        if (hasHarryingPartners || targetInMeleeRange is false)
            return;

        var buffs = evt.Initiator.Buffs;
        foreach (var buff in buffs)
        {
            if (base.Context.MaybeCaster == buff.Context.MaybeCaster &&
                (buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.AttackBuff.Guid) || buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(SwiftAid.AttackBuff.Guid)))
            {
                buff.Remove();
            }
        }
    }

    public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
    {
        if (Data.Target != null && Data.Target == evt.Target)
        {
            evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(Data.AttackBonus, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventDidTrigger(RuleCalculateAttackBonus evt) { }

    private void RemoveBuffFromUnit(UnitEntityData unit)
    {
        if (unit == Context.MaybeCaster)
        {
            var buffs = Context.MaybeOwner.Buffs;
            foreach (var buff in buffs)
            {
                if (buff.Context.MaybeCaster == unit &&
                    (buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.AttackBuff.Guid) || buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(SwiftAid.AttackBuff.Guid)))
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
            if (currentBuff.Context.MaybeCaster == buff.Context.MaybeCaster && buff != currentBuff &&
                (currentBuff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.AttackBuff.Guid) || currentBuff.Blueprint == BlueprintTool.Get<BlueprintBuff>(SwiftAid.AttackBuff.Guid)))
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