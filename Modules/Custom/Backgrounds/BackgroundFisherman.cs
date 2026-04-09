using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class BackgroundFisherman
{
    public static readonly string Guid = "{2920c257-c647-45fa-b298-19dec2f08ee7}";

    private static readonly string FeatureName = "BackgroundFisherman";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddClassSkill(StatType.SkillPerception)
            .AddBackgroundClassSkill(StatType.SkillPerception)
            .AddClassSkill(StatType.SkillMobility)
            .AddBackgroundClassSkill(StatType.SkillMobility)
            .AddFacts([FeatureRefs.DeftHands.ToString()])
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsCraftsmanSelection.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
