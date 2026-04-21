using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.HellknightsCodex.Backgrounds;

internal class HellknightAspirantBackground
{
    public static readonly string Guid = "{e266d5bc-1957-414b-9c6b-e0469c9e40ed}";

    private static readonly string FeatureName = "HellknightAspirantBackground";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddClassSkill(StatType.SkillKnowledgeArcana)
            .AddBackgroundClassSkill(StatType.SkillKnowledgeArcana)
            .AddStatBonus(stat: StatType.SkillKnowledgeArcana, value: 2)
            .AddArmorClassBonusAgainstAlignment(bonus: 2, alignment: AlignmentComponent.Chaotic, descriptor: ModifierDescriptor.Dodge)
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsRegionalSelection.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}