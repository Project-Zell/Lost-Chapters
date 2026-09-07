using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using LostChapters.Components;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class FrenzyingCircleFeature
{
    public static readonly string Guid = "{70daec02-0fc7-4672-8229-3659a2a9c517}";

    private static readonly string BaseName = "FrenzyingCircle";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly Sprite Icon = FeatureRefs.SpecializationSchoolEvocation.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.ArcanistExploit)
            .AddComponent<PrerequisiteHasArchetype>(prerequisite =>
            {
                prerequisite.CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(CharacterClassRefs.ArcanistClass.ToString());
                prerequisite.Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(DemonologistArchetype.Guid);
            })
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();

        RageHelper.AddFactGateToRageLevelProperty(Guid);
    }
}