using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class BlessedIncenseSelector
{
    public static readonly string Guid = "{d57ac7dd-66e9-4044-a102-6b832c06b964}";

    private static readonly string FeatureName = "BlessedIncenseSelector";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        ConfigureIncenseAbilityAreaRunAction();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .SetMode(SelectionMode.OnlyNew)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal static void ConfigureIncenseAbilityAreaRunAction()
    {
        var duration = ContextDuration.VariableDice(DiceType.D4, diceCount: 1, bonus: 0);
        var minorBuffAction = ActionsBuilder.New()
            .ApplyBuff(buff: BuffRefs.IncenseFogSickenedBuff.ToString(), durationValue: duration, asChild: true);

        var majorBuffAction = ActionsBuilder.New()
            .ApplyBuff(buff: BuffRefs.IncenseFogNauseatedBuff.ToString(), durationValue: duration, asChild: true)
            .ApplyBuff(buff: BuffRefs.IncenseFogSickenedBuff.ToString(), durationValue: duration, asChild: true);

        var action = ActionsBuilder.New()
            //Chaos Domain
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(ChaosDomainIncense.MinorFeature.Guid).Alignment(AlignmentComponent.Lawful),
                    ifTrue: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
                        onResult: ActionsBuilder.New().ConditionalSaved(
                            failed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(ChaosDomainIncense.MajorFeature.Guid),
                                ifTrue: majorBuffAction,
                                ifFalse: minorBuffAction),
                            succeed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(ChaosDomainIncense.MajorFeature.Guid),
                                ifTrue: minorBuffAction))))
            //Evil Domain
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(EvilDomainIncense.MinorFeature.Guid).Alignment(AlignmentComponent.Good),
                    ifTrue: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
                        onResult: ActionsBuilder.New().ConditionalSaved(
                            failed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(EvilDomainIncense.MajorFeature.Guid),
                                ifTrue: majorBuffAction,
                                ifFalse: minorBuffAction),
                            succeed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(EvilDomainIncense.MajorFeature.Guid),
                                ifTrue: minorBuffAction))))

            //Good Domain
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(GoodDomainIncense.MinorFeature.Guid).Alignment(AlignmentComponent.Evil),
                    ifTrue: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
                        onResult: ActionsBuilder.New().ConditionalSaved(
                            failed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(GoodDomainIncense.MajorFeature.Guid),
                                ifTrue: majorBuffAction,
                                ifFalse: minorBuffAction),
                            succeed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(GoodDomainIncense.MajorFeature.Guid),
                                ifTrue: minorBuffAction))))

            //Law Domain
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(LawDomainIncense.MinorFeature.Guid).Alignment(AlignmentComponent.Chaotic),
                    ifTrue: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
                        onResult: ActionsBuilder.New().ConditionalSaved(
                            failed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(LawDomainIncense.MajorFeature.Guid),
                                ifTrue: majorBuffAction,
                                ifFalse: minorBuffAction),
                            succeed: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(LawDomainIncense.MajorFeature.Guid),
                                ifTrue: minorBuffAction))))

            //Madness Domain
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(MadnessDomainIncense.MinorFeature.Guid).HasFact(MadnessDomainIncense.CooldownBuff.Guid, negate: true),
                    ifTrue: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
                        onResult: ActionsBuilder.New().ConditionalSaved(
                            failed: ActionsBuilder.New()
                                .Conditional(ConditionsBuilder.New().CasterHasFact(MadnessDomainIncense.MajorFeature.Guid),
                                    ifTrue: ActionsBuilder.New().ApplyBuff(
                                        buff: BuffRefs.Confusion.ToString(),
                                        durationValue: ContextDuration.Fixed(value: 1)),
                                    ifFalse: ActionsBuilder.New().ApplyBuff(
                                        buff: BuffRefs.Confusion.ToString(),
                                        durationValue: ContextDuration.FixedDice(diceType: DiceType.D3)))
                                .ApplyBuff(
                                    buff: MadnessDomainIncense.CooldownBuff.Guid, 
                                    durationValue: ContextDuration.Fixed(value: 1, rate: DurationRate.Days),
                                    asChild: true,
                                    isNotDispelable: true))))

            //Trickery Domain
            .Conditional(
                ConditionsBuilder.New().CasterHasFact(TrickeryDomainIncense.MinorFeature.Guid).HasFact(TrickeryDomainIncense.CooldownBuff.Guid, negate: true),
                    ifTrue: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
                        onResult: ActionsBuilder.New().ConditionalSaved(
                            failed: ActionsBuilder.New()
                                .Conditional(ConditionsBuilder.New().CasterHasFact(TrickeryDomainIncense.MajorFeature.Guid),
                                    ifTrue: ActionsBuilder.New().ApplyBuff(
                                        buff: BuffRefs.Blind.ToString(),
                                        durationValue: ContextDuration.Fixed(value: 1)),
                                    ifFalse: ActionsBuilder.New().ApplyBuff(
                                        buff: BuffRefs.Blind.ToString(),
                                        durationValue: ContextDuration.FixedDice(diceType: DiceType.D4)))
                                .ApplyBuff(
                                    buff: TrickeryDomainIncense.CooldownBuff.Guid,
                                    durationValue: ContextDuration.Fixed(value: 1, rate: DurationRate.Days),
                                    asChild: true,
                                    isNotDispelable: true))))
            ;

        var enemyCondition = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsEnemy(), ifTrue: action);

        AbilityAreaEffectConfigurator.For(CenserBurnerFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectRunAction(unitEnter: enemyCondition, mergeBehavior: ComponentMerge.Replace)
            .Configure();
    }
}
