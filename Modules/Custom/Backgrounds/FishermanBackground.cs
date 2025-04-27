using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.GraySisterhood.Backgrounds;

internal class FishermanBackground
{
    public static readonly string Guid = "{2920c257-c647-45fa-b298-19dec2f08ee7}";

    private static readonly string BackgroundName = "FishermanBackground";
    private static readonly string DisplayName = "FishermanBackground.Name";
    private static readonly string Description = "FishermanBackground.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(BackgroundName, Guid)
            .AddClassSkill(StatType.SkillPerception)
            .AddBackgroundClassSkill(StatType.SkillPerception)
            .AddClassSkill(StatType.SkillMobility)
            .AddBackgroundClassSkill(StatType.SkillMobility)
            .AddFacts([FeatureRefs.DeftHands.ToString()])
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsCraftsmanSelection.ToString())
            .SetIsClassFeature()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
