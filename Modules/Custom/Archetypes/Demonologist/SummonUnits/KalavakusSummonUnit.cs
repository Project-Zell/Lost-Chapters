using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class KalavakusSummonUnit
{
    public static readonly string Guid = "{8d45f9be-4a06-4878-bdf9-168c877a79c5}";

    private static readonly string UnitName = "KalavakusSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "db68b3208721d624ea1061f18fc29122";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Big;

    internal static void Configure()
    {
        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR10_KalavakusStandard.Reference.Get(),
            prefabID: SourcePrefabID,
            level: 13,
            baseAttackBonus: 13,
            stats: (Str: 22, Dex: 13, Con: 24, Int: 15, Wis: 17, Cha: 16),
            isCaster: true,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatExpertiseFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ImprovedBullRush.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ImprovedDisarm.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ImprovedTrip.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString())],
            fxSize: FxSize);
    }
}