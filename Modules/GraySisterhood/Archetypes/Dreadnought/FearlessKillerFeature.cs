using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class FearlessKillerFeature
{
    public static readonly string Guid = "{378d70ab-0c14-4238-a24d-ae2c652a3b02}";

    private static readonly string FeatureName = "FearlessKiller";
    private static readonly string DisplayName = "FearlessKiller.Name";
    private static readonly string Description = "FearlessKiller.Description";

    private static readonly Sprite Icon = AbilityRefs.SacredNimbus.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.FearlessRageFeature.ToString()])
            .SetIsClassFeature(true)
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
