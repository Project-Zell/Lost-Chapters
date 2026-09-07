using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;

internal class SchirSummonUnit
{
    public static readonly string Guid = "{dabf0315-e669-461b-b9a6-e1fcd3ea13c6}";

    private static readonly string UnitName = "SchirSummon";
    private static readonly string DisplayName = $"{UnitName}.Name";

    private static readonly string SourcePrefabID = "8d71692bbaf847044a90d6519b1b9e91";

    internal static readonly SummonDemonVisual.FxSize FxSize = SummonDemonVisual.FxSize.Medium;

    internal static void Configure()
    {
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
            prefabID: SourcePrefabID,
            level: 5,
            baseAttackBonus: 5,
            stats: (Str: 17, Dex: 14, Con: 15, Int: 8, Wis: 5, Cha: 6),
            feats: [
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.PowerAttackFeature.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(FeatureRefs.IronWill.ToString()),
                BlueprintTool.GetRef<BlueprintFeatureReference>(ParametrizedFeatureRefs.WeaponFocus.ToString())],
            skillFocus: weaponFocus,
            fxSize: FxSize);
    }
}