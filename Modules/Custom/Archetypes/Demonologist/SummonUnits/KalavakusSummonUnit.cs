using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class KalavakusSummonUnit
{
    internal static readonly string Guid = "{8d45f9be-4a06-4878-bdf9-168c877a79c5}";

    internal static readonly string UnitName = "KalavakusSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        Prefab.Configure();

        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR10_KalavakusStandard.Reference.Get(),
            prefabID: Prefab.PrefabID,
            level: 13,
            baseAttackBonus: 13,
            stats: (Str: 22, Dex: 13, Con: 24, Int: 15, Wis: 17, Cha: 16),
            isCaster: true,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatExpertiseFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ImprovedBullRush.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ImprovedDisarm.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.ImprovedTrip.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString())]);
    }

    internal class Prefab
    {
        internal static readonly string PrefabID = "{c4eb48d0-0bc4-48bd-aed7-49addaeb6158}";

        private static readonly string SourcePrefabID = "db68b3208721d624ea1061f18fc29122";

        internal static void Configure()
        {
            SummonDemonVisual.ConfigureUnit(
                unitName: UnitName,
                newPrefabID: PrefabID,
                sourcePrefabID: SourcePrefabID,
                fxSize: SummonDemonVisual.FxSize.Medium);
        }
    }
}