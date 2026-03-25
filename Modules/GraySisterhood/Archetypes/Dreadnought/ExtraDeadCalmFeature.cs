using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class ExtraDeadCalmFeature
{
    public static readonly string Guid = "{d937b282-bb2f-4839-aa25-3f5af2462cb8}";

    private static readonly string FeatureName = "ExtraDeadCalm";
    private static readonly string DisplayName = "ExtraDeadCalm.Name";
    private static readonly string Description = "ExtraDeadCalm.Description";

    private static readonly Sprite Icon = FeatureRefs.ExtraRage.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat)
            .AddPrerequisiteFeature(DeadCalmFeature.Guid)
            .AddIncreaseResourceAmount(resource: DeadCalmFeature.Resource.Guid, value: 6)
            .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
            .SetRanks(10)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
