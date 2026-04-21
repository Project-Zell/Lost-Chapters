using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class HellknightDevotionFeature
{
    public static readonly string Guid = "{7b0e7205-6fa8-4f11-b04d-bc707547206d}";

    private static readonly string FeatureName = "HellknightDevotionFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
