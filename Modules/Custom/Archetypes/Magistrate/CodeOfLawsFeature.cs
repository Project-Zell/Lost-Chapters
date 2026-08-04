using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Archetypes.Magistrate;

internal class CodeOfLawsFeature
{
    public static readonly string Guid = "{56121d37-24d8-4cbf-a175-431464290c75}";

    private static readonly string FeatureName = "CodeOfLaws";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/circle.png";

    internal static void Configure()
    {
        var value = ContextValues.Rank();
        var config = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.CavalierClass.ToString()], min: 1, max: 20).WithDiv2Progression();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddContextStatBonus(stat: StatType.CheckIntimidate, value: value, descriptor: ModifierDescriptor.Competence)
            .AddContextStatBonus(stat: StatType.SkillKnowledgeWorld,value: value, descriptor: ModifierDescriptor.Competence)
            .AddContextRankConfig(config)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
