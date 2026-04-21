using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class BackgroundSentryGuard
{
    public static readonly string Guid = "{a7947071-7df9-49d6-ad96-e89c016172a8}";

    private static readonly string FeatureName = "BackgroundSentryGuard";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddClassSkill(StatType.SkillPerception)
            .AddBackgroundClassSkill(StatType.SkillPerception)
            .AddFacts([FeatureRefs.LightCrossbowProficiency.ToString(), FeatureRefs.Alertness.ToString()])
            .AddBackgroundWeaponProficiency(WeaponCategory.LightCrossbow)
            .AddBackgroundWeaponProficiency(WeaponCategory.HeavyCrossbow)
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsWarriorSelection.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}