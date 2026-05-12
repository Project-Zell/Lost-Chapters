using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class BabauSummonUnit
{
    internal static readonly string Guid = "{351ca3a1-69bd-435b-a045-00e79feaeea5}";

    internal static readonly string UnitName = "BabauSummonUnit";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        Prefab.Configure();

        var skillFocus = new SelectionEntry()
        {
            m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(FeatureSelectionRefs.SkillFocusSelection.ToString()),
            m_Features = [BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.SkillFocusStealth.ToString())]
        };

        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR6_BabauStandard.Reference.Get(),
            prefabID: Prefab.PrefabID,
            level: 7,
            archetype: BlueprintTool.GetRef<BlueprintArchetypeReference>(ArchetypeRefs.OusiderGoodFortitudeReflexSaveArchetype.ToString()),
            baseAttackBonus: 7,
            isCaster: true,
            stats: (Str: 21, Dex: 13, Con: 20, Int: 14, Wis: 13, Cha: 16),
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.CombatReflexes.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.Improved_Initiative.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.IronWill.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureSelectionRefs.SkillFocusSelection.ToString())],
            skillFocus: skillFocus);
    }

    internal class Prefab
    {
        internal static readonly string PrefabID = "{87706d2b-64e6-4e74-9bf6-b85bba03e2e5}";

        private static readonly string SourcePrefabID = "cd82e8b7ae98b2e4f912f4106581a9f0";

        internal static void Configure()
        {
            SummonDemonVisual.ConfigureUnit(
                unitName: UnitName,
                newPrefabID: PrefabID,
                sourcePrefabID: SourcePrefabID,
                fxSize: SummonDemonVisual.FxSize.Small);
        }
    }
}