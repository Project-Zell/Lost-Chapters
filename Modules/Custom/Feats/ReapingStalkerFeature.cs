using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Feats;

internal class ReapingStalkerFeature
{
    public static readonly string Guid = "{934deea7-7467-444e-b75e-3ab6444364bb}";

    private static readonly string FeatureName = "ReapingStalkerFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.SlayerTalent)
            .AddToFeatureSelection([FeatureSelectionRefs.SlayerTalentSelection10.ToString()])
            .AddPrerequisiteFeature(FeatureRefs.AdvanceTalents.ToString())
            .AddWeaponSizeChange(category: WeaponCategory.Scythe, checkWeaponCategory: true, sizeCategoryChange: 1)
            .AddWeaponSizeChange(category: WeaponCategory.Sickle, checkWeaponCategory: true, sizeCategoryChange: 1)
            .AddWeaponTypeCriticalEdgeIncrease(weaponType: WeaponTypeRefs.Scythe.Reference.GetBlueprint())
            .AddWeaponTypeCriticalEdgeIncrease(weaponType: WeaponTypeRefs.Sickle.Reference.GetBlueprint())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .AddFeatureTagsComponent(FeatureTag.Attack | FeatureTag.Critical | FeatureTag.Melee)
            //.SetIcon(Icon)
            .Configure();
    }
}
