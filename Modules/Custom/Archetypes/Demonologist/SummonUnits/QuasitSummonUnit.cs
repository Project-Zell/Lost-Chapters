using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class QuasitSummonUnit
{
    public static readonly string Guid = "{50687770-4858-4a1a-9a56-a613addcffed}";

    private static readonly string UnitName = "QuasitSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "da63033598ff6f5439bb6b25445931d6";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Small;

    internal static void Configure()
    {
        var unit = DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR2_QuasitStandard.Reference.Get(),
            level: 1,
            prefabID: SourcePrefabID,
            stats: (Str: 8, Dex: 14, Con: 11, Int: 11, Wis: 12, Cha: 11),
            baseAttackBonus: 1,
            size: Size.Tiny,
            speed: 35,
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.WeaponFinesse.ToString())],
            fxSize: FxSize);

        var quasitBite = BlueprintTool.GetRef<BlueprintItemWeaponReference>(ItemWeaponRefs.Bite1d8.ToString());
        var quasitClaw = BlueprintTool.GetRef<BlueprintItemWeaponReference>(ItemWeaponRefs.Claw1d6.ToString());

        unit.Body.m_AdditionalLimbs = [quasitBite, quasitClaw, quasitClaw];
    }
}