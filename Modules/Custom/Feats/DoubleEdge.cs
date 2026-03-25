using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Feats;

internal class DoubleEdge
{
    public static readonly string Guid = "{393fad64-b8ff-4404-ae8b-c405787fc313}";

    private static readonly string FeatureName = "DoubleEdge";
    private static readonly string DisplayName = "DoubleEdge.Name";
    private static readonly string Description = "DoubleEdge.Description";

    public static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddWeaponSizeChange(category: WeaponCategory.DoubleAxe, checkWeaponCategory: true, sizeCategoryChange: 1)
            .AddWeaponSizeChange(category: WeaponCategory.DoubleSword, checkWeaponCategory: true, sizeCategoryChange: 1)
            .AddWeaponSizeChange(category: WeaponCategory.HookedHammer, checkWeaponCategory: true, sizeCategoryChange: 1)
            .AddWeaponSizeChange(category: WeaponCategory.DwarvenWaraxe, checkWeaponCategory: true, sizeCategoryChange: 1)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .AddToFeatureSelection([
                FeatureSelectionRefs.BasicFeatSelection.ToString(),
                FeatureSelectionRefs.FighterFeatSelection.ToString(),
            ])
            .Configure();
    }
}
