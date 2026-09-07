using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class BalorSummonUnit
{
    public static readonly string Guid = "{7ac86705-9dd9-4775-9be0-4a4277c9e8c8}";

    private static readonly string UnitName = "BalorSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "ede35c527b9a0e5428188d1258d05786";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Giant;

    internal static void Configure()
    {
        var weaponFocus = new SelectionEntry()
        {
            IsParametrizedFeature = true,
            m_ParametrizedFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString()),
            ParamWeaponCategory = WeaponCategory.Longsword
        };

        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR20_BalorStandard.Reference.Get(),
            prefabID: SourcePrefabID,
            level: 20,
            baseAttackBonus: 20,
            stats: (Str: 35, Dex: 25, Con: 36, Int: 24, Wis: 24, Cha: 27),
            size: Size.Medium,
            speed: 40,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatReflexes.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.IronWill.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.TwoWeaponFighting.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.TwoWeaponFightingImproved.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.TwoWeaponFightingGreater.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString())],
            skillFocus: weaponFocus,
            fxSize: FxSize);
    }
}
