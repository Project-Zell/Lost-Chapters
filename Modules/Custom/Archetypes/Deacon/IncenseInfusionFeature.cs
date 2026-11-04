using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class IncenseInfusionFeature
{
    public static readonly string Guid = "{525e0aff-442c-4a6c-99ef-81ef79933a7d}";

    private static readonly string BaseName = "IncenseInfusion";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        var feature = FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        TooltipConfigurator.CreateFeatureTooltip(key: $"LC_{BaseName}", feature: feature);
    }
}
