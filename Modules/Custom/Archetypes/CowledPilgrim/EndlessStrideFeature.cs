using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Archetypes.CowledPilgrim.Components;

namespace LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

internal class EndlessStrideFeature
{
    public static readonly string Guid = "{7da33913-665d-4685-a672-05f2d0b20e82}";

    private static readonly string BaseName = "EndlessStride";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/{CowledPilgrimArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<EndlessStride>()
            .SetIsClassFeature(true)
            .SetReapplyOnLevelUp(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
