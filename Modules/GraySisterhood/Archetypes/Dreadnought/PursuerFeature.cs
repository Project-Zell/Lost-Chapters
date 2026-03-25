using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class PursuerFeature
{
    public static readonly string Guid = "{493163a9-80e9-4547-8dd4-beb0489627fb}";

    private static readonly string FeatureName = "Pursuer";
    private static readonly string DisplayName = "Pursuer.Name";
    private static readonly string Description = "Pursuer.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/pursuer.png";
    
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
