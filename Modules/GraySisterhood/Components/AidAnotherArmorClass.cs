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
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class AidAnotherArmorClass : UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>, ITargetRulebookHandler<RuleCalculateAC>, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleCalculateAC>, ISubscriber, IRulebookHandler<RuleAttackWithWeapon>, IUnitNewCombatRoundHandler, IUnitCombatHandler, IUnitBuffHandler
{
    public int BasicBonus = 2;

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        var maybeCaster = base.Context.MaybeCaster;
        var targetInInitiatorMeleeRange = evt.Weapon is not null && evt.Weapon.Blueprint.IsMelee;

        if (Toolbox.IsTargetInMeleeRangeOfCaster(maybeCaster, evt.Target) is false || targetInInitiatorMeleeRange is false)
            return;

        var rankBonus = 0;
        var rankFeature = BlueprintTool.Get<BlueprintFeature>(AidAnotherFeature.ArmorClassRank.Guid);

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
        if (maybeCaster.HasFact(BenevolentArmorEnchantment.FeatReference))
        {
            equipmentBonus = Toolbox.IsArmorHasEnchantment(maybeCaster.Body.Armor.MaybeArmor.Blueprint,
                    BenevolentArmorEnchantment.Enchantment) ? Toolbox.GetItemEnhancementBonus(maybeCaster.Body.Armor) : 0;
        }

        if (maybeCaster.HasFact(RingOfAltruismItem.Reference))
            equipmentBonus += 1;

        Data.ACModifier = BasicBonus + rankBonus + featBonus + equipmentBonus;
        Data.Initiator = evt.Initiator;
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
        Data.Clear();

        var harryingPartners = BlueprintTool.Get<BlueprintFeature>(HarryingPartnersFeature.Guid);

        var hasHarryingPartners = evt.Target.HasFact(harryingPartners) && Context.MaybeCaster.HasFact(harryingPartners);
        var targetInMeleeRange = evt.Weapon is not null && evt.Weapon.Blueprint.IsMelee;

        if (hasHarryingPartners || targetInMeleeRange is false)
            return;

        var buffs = evt.Target.Buffs;
        foreach (var buff in buffs)
        {
            if (base.Context.MaybeCaster == buff.Context.MaybeCaster &&
                (buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.ArmorClassBuff.Guid) || buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(SwiftAid.ArmorClassBuff.Guid)))
            {
                buff.Remove();
                break;
            }
        }
    }

    public void OnEventAboutToTrigger(RuleCalculateAC evt)
    {
        if (Data.Initiator != null && evt.Initiator == Data.Initiator)
        {
            evt.AddTemporaryModifier(evt.Target.Stats.AC.AddModifier(Data.ACModifier, Fact, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventDidTrigger(RuleCalculateAC evt) { }

    private void RemoveBuffFromUnit(UnitEntityData unit)
    {
        if (unit == Context.MaybeCaster)
        {
            var buffs = Context.MaybeOwner.Buffs;
            foreach (var buff in buffs)
            {
                if (buff.Context.MaybeCaster == unit &&
                    (buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.ArmorClassBuff.Guid) || buff.Blueprint == BlueprintTool.Get<BlueprintBuff>(SwiftAid.ArmorClassBuff.Guid)))
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
                (currentBuff.Blueprint == BlueprintTool.Get<BlueprintBuff>(AidAnotherFeature.ArmorClassBuff.Guid) || currentBuff.Blueprint == BlueprintTool.Get<BlueprintBuff>(SwiftAid.ArmorClassBuff.Guid)))
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
