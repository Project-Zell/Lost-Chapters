using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class BrutalityFeature
{
    public static readonly string Guid = "{aaa6e7b7-617a-4590-bfbc-8c56416832b5}";

    private static readonly string FeatureName = "Brutality";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddPrerequisiteFeature(feature: HellknightObidienceFeature.Guid)
            .AddComponent(new HellknightDisciplineStatScaler() { Stat = StatType.Strength })
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
