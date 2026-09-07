using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class VrockSummonUnit
{
    public static readonly string Guid = "{908010d9-a3ce-4a30-a111-63a0743992ea}";

    private static readonly string UnitName = "VrockSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "f1d670fe8dc2598499a4ec7cae2f1c89";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Big;

    internal static void Configure()
    {
        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR9_VrockStandard.Reference.Get(),
            prefabID: SourcePrefabID,
            level: 9,
            baseAttackBonus: 9,
            stats: (Str: 21, Dex: 15, Con: 25, Int: 14, Wis: 16, Cha: 16),
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Toughness.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatReflexes.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.LightningReflexes.ToString())],
            fxSize: FxSize);
    }
}