using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class DispelChaosFeature
{
    public static readonly string Guid = "{34d812b8-fb19-461a-8306-dfb9d14f13bd}";

    private static readonly string FeatureName = "DispelChaosFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .AddPrerequisiteFeature(FeatureRefs.SmiteChaosFeature.ToString())
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        var action = ActionsBuilder.New()
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(Guid).Alignment(AlignmentComponent.Chaotic),
                ifTrue: ActionsBuilder.New().DispelMagic(
                    buffType: ContextActionDispelMagic.BuffType.FromSpells,
                    checkType: RuleDispelMagic.CheckType.CasterLevel,
                    maxSpellLevel: 0,
                    countToRemove: 3,
                    oneRollForAll: false))
            .Build();

        AbilityConfigurator.For(AbilityRefs.SmiteChaosAbility.ToString())
            .AddAbilityExecuteActionOnCast(actions: action)
            .Configure();
    }
}
