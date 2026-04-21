using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.HellknightCodex.Components;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class DominationFeature
{
    public static readonly string Guid = "{73a71821-5e7b-4d1f-ac15-85b6e4a7bf4d}";

    private static readonly string FeatureName = "DominationFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddPrerequisiteFeature(feature: HellknightObidienceFeature.Guid)
            .AddComponent(new HellknightDisciplineStatScaler() { Stat = StatType.Constitution })
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
