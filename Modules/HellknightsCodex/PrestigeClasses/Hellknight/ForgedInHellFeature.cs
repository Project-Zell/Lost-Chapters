using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using UnityEngine;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

internal class ForgedInHellFeature
{
    public static readonly string Guid = "{dc1fa556-9b8a-404b-8168-850dc22cf11f}";

    private static readonly string FeatureName = "ForgedInHellFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly Sprite Icon = AbilityRefs.ConsumeFear.Reference.Get().Icon;

    internal static void Configure()
    {
        var value = ContextValues.Rank();
        var config = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.HellknightClass.ToString()], min: 1, max: 5).WithDiv2Progression();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddContextStatBonus(stat: StatType.CheckIntimidate, value: value)
            .AddContextRankConfig(config)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
