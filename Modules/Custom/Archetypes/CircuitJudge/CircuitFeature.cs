using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Archetypes.CircuitJudge;

internal class CircuitFeature
{
    public static readonly string Guid = "{56121d37-24d8-4cbf-a175-431464290c75}";

    private static readonly string FeatureName = "CircuitFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        var value = ContextValues.Rank();
        var config = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.CavalierClass.ToString()], min: 1, max: 20).WithDiv2Progression();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddContextStatBonus(stat: StatType.CheckIntimidate, value: value, descriptor: ModifierDescriptor.Morale)
            .AddContextStatBonus(stat: StatType.SkillKnowledgeWorld,value: value, descriptor: ModifierDescriptor.Morale)
            .AddContextRankConfig(config)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
