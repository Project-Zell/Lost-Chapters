using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class LostInSightFeature
{
    public static readonly string Guid = "{08592d65-737c-4649-a543-6696345cd4b1}";

    private static readonly string FeatureName = "LostInSight";
    private static readonly string DisplayName = "LostInSight.Name";
    private static readonly string Description = "LostInSight.Description";

    private static readonly Sprite Icon = FeatureRefs.Camouflage.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.Camouflage.ToString()])
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
