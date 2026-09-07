using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class DretchSummonUnit
{
    public static readonly string Guid = "{5ec14759-51b1-4cf7-927d-6176766f8a3c}";
    
    private static readonly string UnitName = "DretchSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "08d7013c13b587541bead70c4a254977";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Small;

    internal static void Configure()
    {
        var unit = DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR2_DretchStandard.Reference.Get(),
            prefabID: SourcePrefabID,
            level: 2,
            baseAttackBonus: 2,
            stats: (Str: 12, Dex: 10, Con: 14, Int: 5, Wis: 11, Cha: 11),
            size: Size.Medium,
            speed: 25,
            feats: [BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Toughness.ToString())],
            facts: [
                BlueprintTool.GetRef<BlueprintUnitFactReference>(UnitFactRefs.NaturalArmor3.ToString()),
                BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureRefs.SubtypeDemon.ToString()),
                BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureRefs.SubtypeExtraplanar.ToString()),
                BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureRefs.DemonOfMagicFeature.ToString()),
                BlueprintTool.GetRef<BlueprintUnitFactReference>(FeatureRefs.DRColdIronOrGood5.ToString())],
            fxSize: FxSize);

        var dumbMonsterBrain = "5abc8884c6f15204c8604cb01a2efbab";
        UnitConfigurator.For(unit).SetBrain(dumbMonsterBrain).SetAlternativeBrains([]).Configure();
    }
}