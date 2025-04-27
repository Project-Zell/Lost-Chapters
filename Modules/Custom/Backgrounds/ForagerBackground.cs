using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class ForagerBackground
{
    public static readonly string Guid = "{7b6e6f97-5fb0-4869-ae6a-a5fe75d30f40}";

    private static readonly string BackgroundName = "ForagerBackground";
    private static readonly string DisplayName = "ForagerBackground.Name";
    private static readonly string Description = "ForagerBackground.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(BackgroundName, Guid)
            .AddClassSkill(StatType.SkillPerception)
            .AddBackgroundClassSkill(StatType.SkillPerception)
            .AddFacts([FeatureRefs.SickleProficiency.ToString()])
            .AddBackgroundWeaponProficiency(WeaponCategory.Sickle)
            .AddStatBonus(stat: StatType.Initiative, value: 2, descriptor: ModifierDescriptor.UntypedStackable)
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsCraftsmanSelection.ToString())
            .SetIsClassFeature()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
