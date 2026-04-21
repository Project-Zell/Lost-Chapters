using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class BackgroundGrayEminence
{
    public static readonly string Guid = "{1395bffc-e8b8-4cbf-843f-f24effb36fc7}";

    private static readonly string FeatureName = "BackgroundGrayEminence";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddClassSkill(StatType.SkillPersuasion)
            .AddBackgroundClassSkill(StatType.SkillPersuasion)
            .AddFacts([FeatureRefs.DaggerProficiency.ToString()])
            .AddBackgroundWeaponProficiency(WeaponCategory.Dagger)
            .AddStatBonus(stat: StatType.Initiative, value: 2)
            .AddStatBonus(stat: StatType.CheckBluff, value: 2)
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsNobleSelection.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}