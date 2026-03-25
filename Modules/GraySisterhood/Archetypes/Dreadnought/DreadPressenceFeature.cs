using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class DreadPressenceFeature
{
    public static readonly string Guid = "{b90d95d0-87f4-435c-a536-9384388b13ba}";

    private static readonly string FeatureName = "DreadPressence";
    private static readonly string DisplayName = "DreadPressence.Name";
    private static readonly string Description = "DreadPressence.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/dreadpressence.png";

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
