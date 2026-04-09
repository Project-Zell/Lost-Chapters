using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class BackgroundTavernServer
{
    public static readonly string Guid = "{5a3fb7b7-3420-4abc-ba34-948f4d545b12}";

    private static readonly string FeatureName = "BackgroundTavernServer";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddClassSkill(StatType.SkillMobility)
            .AddBackgroundClassSkill(StatType.SkillMobility)
            .AddFacts([FeatureRefs.Dodge.ToString()])
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsCraftsmanSelection.ToString())
            .SetIsClassFeature()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
