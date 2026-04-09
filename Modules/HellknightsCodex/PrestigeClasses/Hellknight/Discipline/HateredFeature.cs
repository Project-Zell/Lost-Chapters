using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.HellknightCodex.Components;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class HateredFeature
{
    public static readonly string Guid = "{09256b87-872b-49a0-aaec-0bea82b40bce}";

    private static readonly string FeatureName = "HateredFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddPrerequisiteFeature(feature: HellknightObidienceFeature.Guid)
            .AddComponent(new HellknightDisciplineStatScaler() { Stat = StatType.Charisma})
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
