using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class ObsessionFeature
{
    public static readonly string Guid = "{46c0330c-71af-4b31-b7a7-7a93cb56fc38}";

    private static readonly string FeatureName = "ObsessionFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddPrerequisiteFeature(feature: HellknightObidienceFeature.Guid)
            .AddComponent(new HellknightDisciplineStatScaler() { Stat = StatType.Wisdom })
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
