using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class RequiemFeature
{
    public static readonly string Guid = "{e4276544-600a-429e-be77-26457563840e}";

    private static readonly string FeatureName = "RequiemFeature";
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
