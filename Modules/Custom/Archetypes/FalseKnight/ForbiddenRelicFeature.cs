using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.HellknightsCodex;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight;

internal class ForbiddenRelicFeature
{
    public static readonly string Guid = "{5355c8b7-56d7-461c-be2c-f7e0a62632e6}";

    private static readonly string BaseName = "ForbiddenRelic";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/forbiddenrelic.png";

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
