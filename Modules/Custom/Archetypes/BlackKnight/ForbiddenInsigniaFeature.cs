using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class ForbiddenInsigniaFeature
{
    public static readonly string Guid = "{5355c8b7-56d7-461c-be2c-f7e0a62632e6}";

    private static readonly string FeatureName = "ForbiddenInsignia";
    private static readonly string DisplayName = "ForbiddenInsignia.Name";
    private static readonly string Description = "ForbiddenInsignia.Description";

    //private static readonly string Icon = $"{CustomModule.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }
}
