using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class OneWithTheRoadFeature
{
    public static readonly string Guid = "{d7b525f7-3029-4eab-b412-596290003b24}";

    private static readonly string FeatureName = "OneWithTheRoad";
    private static readonly string DisplayName = "OneWithTheRoad.Name";
    private static readonly string Description = "OneWithTheRoad.Description";

    private static readonly Sprite Icon = FeatureRefs.FastStealth.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.FastStealth.ToString()])
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
