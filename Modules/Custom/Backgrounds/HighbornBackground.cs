using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class HighbornBackground
{
    public static readonly string Guid = "{c11fdac3-96af-4553-a8ec-8f88c9a2d79f}";

    private static readonly string BackgroundName = "HighbornBackground";
    private static readonly string DisplayName = "HighbornBackground.Name";
    private static readonly string Description = "HighbornBackground.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(BackgroundName, Guid)
            .AddClassSkill(StatType.SkillPersuasion)
            .AddBackgroundClassSkill(StatType.SkillPersuasion)
            .AddFacts([FeatureRefs.DuelingSwordProficiency.ToString()])
            .AddBackgroundWeaponProficiency(WeaponCategory.DuelingSword)
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsNobleSelection.ToString())
            .SetIsClassFeature()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
