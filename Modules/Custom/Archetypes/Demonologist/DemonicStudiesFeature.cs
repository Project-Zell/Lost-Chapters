using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonicStudiesFeature
{
    public static readonly string Guid = "{8fd31e84-38db-42c4-9d9d-16e93e22cbc7}";

    private static readonly string BaseName = "DemonicStudies";

    private static readonly string FeatureName = $"{BaseName}Feature";
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
