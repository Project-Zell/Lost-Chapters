using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes;

namespace LostChapters.Modules.GraySisterhood.Feats;

internal class HelpfulFeature
{
    public static readonly string Guid = "{f5fcf1f0-7f52-45f1-8b50-d04df176fb64}";

    private static readonly string FeatureName = "Helpful";
    private static readonly string DisplayName = "Helpful.Name";
    private static readonly string Description = "Helpful.Description";

    public static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
