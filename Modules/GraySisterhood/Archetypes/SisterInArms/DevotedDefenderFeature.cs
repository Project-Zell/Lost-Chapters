using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class DevotedDefenderFeature
{
    public static readonly string Guid = "{382f878c-f79a-4472-a856-57831be7dacb}";

    private static readonly string FeatureName = "DevotedDefender";
    private static readonly string DisplayName = "DevotedDefender.Name";
    private static readonly string Description = "DevotedDefender.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([BodyguardFeature.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
