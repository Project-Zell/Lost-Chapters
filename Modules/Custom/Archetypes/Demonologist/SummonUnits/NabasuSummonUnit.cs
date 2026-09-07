using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class NabasuSummonUnit
{
    public static readonly string Guid = "{c011be55-0771-4dc9-9ded-d63222e7390e}";

    private static readonly string UnitName = "NabasuSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "a7534f92d250de24eb8e50f8ccd887e1";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Medium;

    internal static void Configure()
    {
        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR8_NabasuStandard.Reference.Get(),
            prefabID: SourcePrefabID,
            level: 11,
            baseAttackBonus: 11,
            isCaster: true,
            speed: 40,
            stats: (Str: 22, Dex: 17, Con: 22, Int: 15, Wis: 16, Cha: 19),
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Toughness.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Dodge.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatCasting.ToString())],
            fxSize: FxSize);
    }
}