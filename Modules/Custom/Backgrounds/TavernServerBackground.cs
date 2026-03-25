using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class TavernServerBackground
{
    public static readonly string Guid = "{5a3fb7b7-3420-4abc-ba34-948f4d545b12}";

    private static readonly string BackgroundName = "TavernServerBackground";
    private static readonly string DisplayName = "TavernServerBackground.Name";
    private static readonly string Description = "TavernServerBackground.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(BackgroundName, Guid)
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
