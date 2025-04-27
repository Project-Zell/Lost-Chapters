using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Components;
using LostChapters.Modules.GraySisterhood;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class EndlessStrideFeature
{
    public static readonly string Guid = "{7da33913-665d-4685-a672-05f2d0b20e82}";

    private static readonly string FeatureName = "EndlessStride";
    private static readonly string DisplayName = "EndlessStride.Name";
    private static readonly string Description = "EndlessStride.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/endlessstride.png";

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
