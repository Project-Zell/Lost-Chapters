using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class NabasuSummonUnit
{
    internal static readonly string Guid = "{c011be55-0771-4dc9-9ded-d63222e7390e}";

    internal static readonly string UnitName = "NabasuSummon";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        Prefab.Configure();

        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR8_NabasuStandard.Reference.Get(),
            prefabID: Prefab.PrefabID,
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
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatCasting.ToString())]);
    }

    internal class Prefab
    {
        internal static readonly string PrefabID = "{a51486d1-52ce-4ff4-920f-9d84a3363a4a}";

        private static readonly string SourcePrefabID = "a7534f92d250de24eb8e50f8ccd887e1";

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