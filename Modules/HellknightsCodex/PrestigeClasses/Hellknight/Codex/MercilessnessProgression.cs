using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using UnityEngine;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Codex;

internal class MercilessnessProgression
{
    public static readonly string Guid = "{86242abe-58b2-42f0-b14a-04984cb732d3}";

    private static readonly string FeatureName = "Mercilessness";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        CapstoneSelection.Configure();

        ProgressionConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(FeatureRefs.SneakAttack.ToString())
            .SetClasses([CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
            .AddToLevelEntry(level: 01, features: FeatureRefs.SneakAttack.ToString())
            .AddToLevelEntry(level: 05, features: FeatureRefs.SneakAttack.ToString())
            .AddToLevelEntry(level: 10, features: CapstoneSelection.Guid)
            .SetRanks(3)
            .AddToUIGroups([FeatureRefs.SneakAttack.ToString(), CapstoneSelection.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}

internal class CapstoneSelection
{
    public static readonly string Guid = "{e6e614a9-bfcb-4190-a5fc-0c13d57fdabf}";

    private static readonly string SelectionName = "Mercilessness.CapstoneSelection";
    private static readonly string DisplayName = $"{SelectionName}.DisplayName";
    private static readonly string Description = $"{SelectionName}.Description";

    private static readonly Sprite Icon = AbilityRefs.TricksterInvisibilityAlmostGreater.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureSelectionConfigurator.New(SelectionName, Guid)
            .SetAllFeatures(
                FeatureRefs.FocusingAttackConfused.ToString(),
                FeatureRefs.FocusingAttackShaken.ToString(),
                FeatureRefs.FocusingAttackSickened.ToString(),
                FeatureRefs.SlowReactions.ToString(),
                FeatureRefs.WeakeningWoundFeature.ToString(),
                FeatureRefs.BlindingStrike.ToString(),
                FeatureRefs.ConfoundingBlades.ToString(),
                FeatureRefs.CripplingStrike.ToString(),
                FeatureRefs.DispellingAttack.ToString(),
                FeatureRefs.WearyingStrike.ToString(),
                FeatureRefs.ExecutionerPainfulStrike.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
