using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Designers;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.Items;
using Kingmaker.Items.Slots;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Conditions;
using Kingmaker.Utility;

namespace LostChapters.Tools;

internal static class Toolbox
{
    public static int GetItemEnhancementBonus(HandSlot handSlot)
    {
        ItemEntityWeapon maybeWeapon = handSlot.MaybeWeapon;
        if (maybeWeapon != null)
        {
            return GameHelper.GetItemEnhancementBonus(maybeWeapon);
        }

        return 0;
    }

    public static int GetItemEnhancementBonus(ArmorSlot armorSlot)
    {
        ItemEntityArmor maybeArmor = armorSlot.MaybeArmor;
        if (maybeArmor != null)
        {
            return GameHelper.GetItemEnhancementBonus(maybeArmor);
        }

        return 0;
    }

    public static bool IsWeaponHasEnchantment(BlueprintItemWeapon weapon, BlueprintWeaponEnchantment enchantment)
    {
        return weapon.Enchantments.Contains(enchantment);
    }

    public static bool IsArmorHasEnchantment(BlueprintItemArmor armor, BlueprintArmorEnchantment enchantment)
    {
        return armor.Enchantments.Contains(enchantment);
    }

    public static bool IsEventTargetInMeleeRange(RuleAttackWithWeapon evt)
    {
        return evt.Weapon is not null && evt.Weapon.Blueprint.IsMelee;
    }

    public static bool IsTargetInMeleeRangeOfCaster(UnitEntityData maybeCaster, TargetWrapper target)
    {
        if (maybeCaster is null) 
            return false;

        var casterWeaponSlot = maybeCaster.GetThreatHandMelee();
        float meleeRangeDistance = casterWeaponSlot.Weapon.AttackRange.Meters + maybeCaster.View.Corpulence + target.Unit.View.Corpulence;
        float distanceFromCasterToTarget = maybeCaster.DistanceTo(target.Point);
        return distanceFromCasterToTarget <= meleeRangeDistance;
    }

    public static bool IsTargetHasBuffFromCaster(BuffCollection targetBuffs, BlueprintBuff buff, UnitEntityData caster)
    {
        foreach (var targetBuff in targetBuffs)
        {
            if (targetBuff.Blueprint == buff && targetBuff.Context.MaybeCaster == caster)
            {
                return true;
            }
        }
        return false;
    }

    public static bool IsTargetHasBuffFromCaster(BuffCollection targetBuffs, BlueprintBuff[] buffs, UnitEntityData caster)
    {
        foreach (var targetBuff in targetBuffs)
        {
            foreach(var buff in buffs)
            {
                if (targetBuff.Blueprint == buff && targetBuff.Context.MaybeCaster == caster)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static int GetFavoriteTerrainCount(UnitEntityData owner)
    {
        int count = 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainAbyss.Reference) ? 1 : 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainDesert.Reference) ? 1 : 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainFirstWorld.Reference) ? 1 : 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainForest.Reference) ? 1 : 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainHighlands.Reference) ? 1 : 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainPlains.Reference) ? 1 : 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainUnderground.Reference) ? 1 : 0;
        count += owner.HasFact(FeatureRefs.FavoriteTerrainUrban.Reference) ? 1 : 0;

        return count;
    }

    public static Condition GenderCondition(Gender gender, bool negate = false)
    {
        var condition = new ContextConditionGender
        {
            Gender = gender,
            Not = negate
        };
        return condition;
    }

    public static bool IsWeaponEquipped(this UnitEntityData unitEntityData, WeaponCategory category)
    {
        if ((unitEntityData.Body.PrimaryHand.HasWeapon || unitEntityData.Body.SecondaryHand.HasWeapon) is false)
            return false;

        return unitEntityData.Body.PrimaryHand.Weapon.Blueprint.Category == category || 
               unitEntityData.Body.SecondaryHand.Weapon.Blueprint.Category == category;
    }

    public static BlueprintItemReference GetWeaponItemReference(string guid)
    {
        if (BlueprintTool.TryGet<BlueprintItemWeapon>(guid, out var blueprint))
            return blueprint.ToReference<BlueprintItemReference>();
        return new BlueprintItemReference();
    }
}
