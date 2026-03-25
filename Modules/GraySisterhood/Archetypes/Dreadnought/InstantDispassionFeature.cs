using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class InstantDispassionFeature
{
    public static readonly string Guid = "{b71f764a-027f-4e85-8d22-2e1148a63863}";

    private static readonly string FeatureName = "InstantDispassion";
    private static readonly string DisplayName = "InstantDispassion.Name";
    private static readonly string Description = "InstantDispassion.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/instantdispassion.png";
    
    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
