using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats;

internal class HelpfulFeature
{
    public static readonly string Guid = "{f5fcf1f0-7f52-45f1-8b50-d04df176fb64}";

    private static readonly string FeatureName = "Helpful";
    private static readonly string DisplayName = "Helpful.Name";
    private static readonly string Description = "Helpful.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/helpful.png";

    public static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat, FeatureGroup.CombatFeat)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
