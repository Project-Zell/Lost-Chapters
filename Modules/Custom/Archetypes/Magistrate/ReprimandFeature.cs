using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.Custom.Archetypes.Magistrate;

internal class ReprimandFeature
{
    public static readonly string Guid = "{78d68d3b-aded-4d18-a18f-c65a68ac8c8a}";

    private static readonly string FeatureName = "ReprimandFeature";
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
