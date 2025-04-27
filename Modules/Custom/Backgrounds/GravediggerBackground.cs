using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Backgrounds;

internal class GravediggerBackground
{
    public static readonly string Guid = "{222e009f-89ab-4472-9b38-7c5363a9bd6e}";

    private static readonly string BackgroundName = "GravediggerBackground";
    private static readonly string DisplayName = "GravediggerBackground.Name";
    private static readonly string Description = "GravediggerBackground.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(BackgroundName, Guid)
            .AddClassSkill(StatType.SkillAthletics)
            .AddBackgroundClassSkill(StatType.SkillAthletics)
            .AddFacts([FeatureRefs.Toughness.ToString()])
            .AddStatBonus(stat: StatType.SaveFortitude, value: 1, descriptor: ModifierDescriptor.UntypedStackable)
            .AddToFeatureSelection(FeatureSelectionRefs.BackgroundsCraftsmanSelection.ToString())
            .SetIsClassFeature()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
