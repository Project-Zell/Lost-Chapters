using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class SteadyGaitFeature
{
    public static readonly string Guid = "{7137dfc4-2960-471a-85fa-3e5f42a7e92b}";

    private static readonly string FeatureName = "SteadyGait";
    private static readonly string DisplayName = "SteadyGait.Name";
    private static readonly string Description = "SteadyGait.Description";

    private static readonly Sprite Icon = FeatureRefs.Stability.Reference.Get().Icon;

    internal static void Configure()
    {
        var rankConfig = ContextRankConfigs.ClassLevel([CharacterClassRefs.BarbarianClass.ToString()]).WithDivStepProgression(5);

        FeatureConfigurator.New(FeatureName, Guid)
            .AddSavingThrowBonusAgainstDescriptor(value: 1, bonus: ContextValues.Rank(), spellDescriptor: SpellDescriptor.Trap | SpellDescriptor.Ground | SpellDescriptor.MovementImpairing)
            .AddContextRankConfig(rankConfig)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
