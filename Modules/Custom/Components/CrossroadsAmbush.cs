using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.Custom.Archetypes.HoodedWanderer;
using System.Collections.Generic;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class CrossroadsAmbush : BlueprintComponent, IAbilityOnCastLogic
{
    private static readonly List<WeaponCategory> SimpleWeapons =
        [
            WeaponCategory.Dagger,
            WeaponCategory.LightMace,
            WeaponCategory.PunchingDagger,
            WeaponCategory.Sickle,
            WeaponCategory.Club,
            WeaponCategory.HeavyMace,
            WeaponCategory.Shortspear,
            WeaponCategory.Dart,
            WeaponCategory.HeavyCrossbow,
            WeaponCategory.Javelin,
            WeaponCategory.LightCrossbow,
            WeaponCategory.Sling,
            WeaponCategory.Greatclub,
            WeaponCategory.Longspear,
            WeaponCategory.Quarterstaff,
            WeaponCategory.Spear
        ];

    public void OnCast(AbilityExecutionContext context)
    {
        var caster = context.Caster;

        var feature = BlueprintTool.Get<BlueprintFeature>(CrossroadsAmbushFeature.Guid);
        if (caster.HasFact(feature) is false)
            return;

        var pounceBuff = BlueprintTool.Get<BlueprintBuff>(CrossroadsAmbushFeature.PounceBuff.Guid);
        var hasBuff = caster.HasFact(pounceBuff);
        var isWieldSimpleWeapon = SimpleWeapons.Contains(caster.Body.PrimaryHand.Weapon.Blueprint.Category);

        if (isWieldSimpleWeapon)
        {
            if (hasBuff is false)
            {
                caster.AddBuff(pounceBuff, caster);
            }
        }
        else
        {
            if (hasBuff)
            {
                caster.Buffs.RemoveFact(pounceBuff);
            }
        }
    }
}
