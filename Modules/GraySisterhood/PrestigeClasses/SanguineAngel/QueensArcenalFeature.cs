using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Components;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

internal class QueensArcenalFeature
{
    public static readonly string Guid = "{32862c2c-2a55-4fc4-9e86-9403137fcaff}";

    private static readonly string FeatureName = "QueensSword";
    private static readonly string DisplayName = "QueensSword.Name";
    private static readonly string Description = "QueensSword.Description";

    private static readonly Sprite Icon = FeatureSelectionRefs.WeaponTrainingSelection.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<QueensArcenal>()
            .SetRanks(3)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
