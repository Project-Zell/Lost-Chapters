using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.HellknightCodex.Components;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class HubrisFeature
{
    public static readonly string Guid = "{ed6cb61c-998c-4a9e-81d8-0c931be74b84}";

    private static readonly string FeatureName = "HubrisFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddPrerequisiteFeature(feature: HellknightObidienceFeature.Guid)
            .AddComponent(new HellknightDisciplineStatScaler() { Stat = StatType.Intelligence })
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
