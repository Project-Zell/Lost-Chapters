using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class SchirSummonUnit
{
    internal static readonly string Guid = "{dabf0315-e669-461b-b9a6-e1fcd3ea13c6}";

    internal static readonly string UnitName = "SchirSummon";
    internal static readonly string DisplayName = $"{UnitName}.Name";

    internal static void Configure()
    {
        Prefab.Configure();

        var weaponFocus = new SelectionEntry()
        {
            IsParametrizedFeature = true,
            m_ParametrizedFeature = BlueprintTool.GetRef<BlueprintParametrizedFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString()),
            m_Selection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(FeatureSelectionRefs.SkillFocusSelection.ToString()),
            m_Features = [BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.SkillFocusStealth.ToString())],
            ParamWeaponCategory = WeaponCategory.Bardiche
        };

        DemonologistSummonUnitHelper.CreateSummonUnit(
            unitName: UnitName,
            displayName: DisplayName,
            guid: Guid,
            baseUnit: UnitRefs.CR4_SchirStandard.Reference.Get(),
            prefabID: Prefab.PrefabID,
            level: 5,
            baseAttackBonus: 5,
            stats: (Str: 17, Dex: 14, Con: 15, Int: 8, Wis: 5, Cha: 6),
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.IronWill.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString())],
            skillFocus: weaponFocus);
    }

    internal class Prefab
    {
        internal static readonly string PrefabID = "{6158d055-9f0f-434b-96f4-185da8d29f12}";

        private static readonly string SourcePrefabID = "8d71692bbaf847044a90d6519b1b9e91";

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