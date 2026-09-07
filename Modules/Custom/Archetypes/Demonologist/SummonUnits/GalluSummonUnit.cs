using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class GalluSummonUnit
{
    public static readonly string Guid = "{971eeb98-f36d-4558-b483-c85a78b88788}";

    private static readonly string UnitName = "GalluSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "62904bfeeccdddc4181099d417a933d2";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Big;

    internal static void Configure()
    {
        var weaponFocus = new SelectionEntry()
        {
            IsParametrizedFeature = true,
            m_ParametrizedFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(ParametrizedFeatureRefs.ImprovedCritical.ToString()),
            m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(FeatureSelectionRefs.BasicFeatSelection.ToString()),
            ParamWeaponCategory = WeaponCategory.Falchion
        };

        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR19_GalluStandard.Reference.Get(),
            prefabID: SourcePrefabID,
            level: 19,
            baseAttackBonus: 19,
            stats: (Str: 33, Dex: 18, Con: 34, Int: 18, Wis: 23, Cha: 25),
            size: Size.Medium,
            speed: 50,
            isCaster: true,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Toughness.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CriticalFocus.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.LightningReflexes.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.VitalStrikeFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.VitalStrikeFeatureImproved.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.StaggeringCriticalFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ImprovedBullRush.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.ImprovedCritical.ToString())],
            skillFocus: weaponFocus,
            fxSize: FxSize);
    }
}
