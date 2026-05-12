using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using LostChapters.Components;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistRagePowerSelection
{
    public static readonly string Guid = "{2c868fd5-a649-454f-b910-3941bdd3eceb}";

    private static readonly string FeatureName = "DemonologistRagePowerSelection";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly Sprite Icon = AbilityRefs.Rage.Reference.Get().Icon;

    internal static void Configure()
    {
        var hasArchetypeCondition = new PrerequisiteHasArchetype(classGuid: CharacterClassRefs.ArcanistClass.ToString(), archetypeGuid: DemonologistArchetype.Guid);

        FeatureSelectionConfigurator.New(FeatureName, Guid, FeatureGroup.ArcanistExploit)
            .CopyFrom(FeatureSelectionRefs.RagePowerSelection.ToString())
            .AddComponent(hasArchetypeCondition)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();

        FeatureSelectionConfigurator.For(FeatureSelectionRefs.ArcanistExploitSelection)
            .AddToAllFeatures(Guid)
            .Configure();

        FeatureSelectionConfigurator.For(FeatureSelectionRefs.ExtraArcanistExploitSelection)
            .AddToAllFeatures(Guid)
            .Configure();
    }
}
