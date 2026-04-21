using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class BackgroundPrisoner
{
    public static readonly string Guid = "{bfbf69a3-c589-4404-a988-f7f5e9c38fae}";

    private static readonly string FeatureName = "BackgroundPrisoner";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        //WIP
        FeatureConfigurator.New(FeatureName, Guid)
            .AddClassSkill(StatType.SkillPerception)
            .AddBackgroundClassSkill(StatType.SkillPerception)
            .AddFacts([FeatureRefs.FastLearner.ToString()])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
