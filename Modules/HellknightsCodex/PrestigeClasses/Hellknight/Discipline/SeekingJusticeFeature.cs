using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class SeekingJusticeFeature
{
    public static readonly string Guid = "{d54f1ffb-3290-406f-ab73-cd94436bdcfc}";

    private static readonly string FeatureName = "SeekingJustice";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddComponent<SeekingJustice>()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
