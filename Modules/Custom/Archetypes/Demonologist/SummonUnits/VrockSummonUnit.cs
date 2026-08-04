using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.Utility;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class VrockSummonUnit
{
    internal static readonly string Guid = "{908010d9-a3ce-4a30-a111-63a0743992ea}";

    internal static readonly string UnitName = "VrockSummon";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        Prefab.Configure();

        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR4_SchirStandard.Reference.Get(),
            prefabID: Prefab.PrefabID,
            level: 9,
            baseAttackBonus: 9,
            stats: (Str: 21, Dex: 15, Con: 25, Int: 14, Wis: 16, Cha: 16),
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Toughness.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatReflexes.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.LightningReflexes.ToString())]);
    }

    internal class Prefab
    {
        internal static readonly string PrefabID = "{6331f8a2-822c-42f9-9317-ea6bc2a7330e}";

        private static readonly string SourcePrefabID = "f1d670fe8dc2598499a4ec7cae2f1c89";

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