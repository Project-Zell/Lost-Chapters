using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class HellknightZealFeature
{
    public static readonly string Guid = "{3e4715a8-0fad-4ac0-85c1-30dfc453cfb4}";

    private const string FeatureName = "HellknightZeal";
    private const string DisplayName = $"{FeatureName}.Name";
    private const string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddDerivativeStatBonus(baseStat: StatType.Charisma, derivativeStat: StatType.Initiative)
            .AddRecalculateOnStatChange(stat: StatType.Charisma)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
