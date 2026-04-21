using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon;

internal class DeaconIncenseSelector
{
    public static readonly string Guid = "{d57ac7dd-66e9-4044-a102-6b832c06b964}";

    private static readonly string FeatureName = "CapellanIncenseSelector";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        AirDomainIncense.Configure();
        AnimalDomainIncense.Configure();
        ArtificeDomainIncense.Configure();
        ChaosDomainIncense.Configure();
        CharmDomainIncense.Configure();
        CommunityDomainIncense.Configure();
        DarknessDomainIncense.Configure();
        DeathDomainIncense.Configure();
        DestructionDomainIncense.Configure();
        EarthDomainIncense.Configure();
        EvilDomainIncense.Configure();
        FireDomainIncense.Configure();
        GloryDomainIncense.Configure();
        GoodDomainIncense.Configure();
        HealingDomainIncense.Configure();
        KnowledgeDomainIncense.Configure();
        LawDomainIncense.Configure();
        LiberationDomainIncense.Configure();
        LuckDomainIncense.Configure();
        MadnessDomainIncense.Configure();
        MagicDomainIncense.Configure();
        NobilityDomainIncense.Configure();
        PlantDomainIncense.Configure();
        ProtectionDomainIncense.Configure();
        ReposeDomainIncense.Configure();
        RuneDomainIncense.Configure();
        ScalykindDomainIncense.Configure();
        StrengthDomainIncense.Configure();
        SunDomainIncense.Configure();
        TravelDomainIncense.Configure();
        TrickeryDomainIncense.Configure();
        WarDomainIncense.Configure();
        WaterDomainIncense.Configure();
        WeatherDomainIncense.Configure();

        ConfigureIncenseAbilityAreaRunAction();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddToAllFeatures([
                AirDomainIncense.MinorFeature.Guid,
                AirDomainIncense.MajorFeature.Guid,
                AnimalDomainIncense.MinorFeature.Guid,
                AnimalDomainIncense.MajorFeature.Guid,
                ArtificeDomainIncense.MinorFeature.Guid,
                ArtificeDomainIncense.MajorFeature.Guid,
                ChaosDomainIncense.MinorFeature.Guid,
                ChaosDomainIncense.MajorFeature.Guid,
                CharmDomainIncense.MinorFeature.Guid,
                CharmDomainIncense.MajorFeature.Guid,
                CommunityDomainIncense.MinorFeature.Guid,
                CommunityDomainIncense.MajorFeature.Guid,
                DarknessDomainIncense.MinorFeature.Guid,
                DarknessDomainIncense.MajorFeature.Guid,
                DeathDomainIncense.MinorFeature.Guid,
                DeathDomainIncense.MajorFeature.Guid,
                DestructionDomainIncense.MinorFeature.Guid,
                DestructionDomainIncense.MajorFeature.Guid,
                EarthDomainIncense.MinorFeature.Guid,
                EarthDomainIncense.MajorFeature.Guid,
                EvilDomainIncense.MinorFeature.Guid,
                EvilDomainIncense.MajorFeature.Guid,
                FireDomainIncense.MinorFeature.Guid,
                FireDomainIncense.MajorFeature.Guid,
                GloryDomainIncense.MinorFeature.Guid,
                GloryDomainIncense.MajorFeature.Guid,
                GoodDomainIncense.MinorFeature.Guid,
                GoodDomainIncense.MajorFeature.Guid,
                HealingDomainIncense.MinorFeature.Guid,
                HealingDomainIncense.MajorFeature.Guid,
                KnowledgeDomainIncense.MinorFeature.Guid,
                KnowledgeDomainIncense.MajorFeature.Guid,
                LawDomainIncense.MinorFeature.Guid,
                LawDomainIncense.MajorFeature.Guid,
                LiberationDomainIncense.MinorFeature.Guid,
                LiberationDomainIncense.MajorFeature.Guid,
                LuckDomainIncense.MinorFeature.Guid,
                LuckDomainIncense.MajorFeature.Guid,
                MadnessDomainIncense.MinorFeature.Guid,
                MadnessDomainIncense.MajorFeature.Guid,
                MagicDomainIncense.MinorFeature.Guid,
                MagicDomainIncense.MajorFeature.Guid,
                NobilityDomainIncense.MinorFeature.Guid,
                NobilityDomainIncense.MajorFeature.Guid,
                PlantDomainIncense.MinorFeature.Guid,
                PlantDomainIncense.MajorFeature.Guid,
                ProtectionDomainIncense.MinorFeature.Guid,
                ProtectionDomainIncense.MajorFeature.Guid,
                ReposeDomainIncense.MinorFeature.Guid,
                ReposeDomainIncense.MajorFeature.Guid,
                RuneDomainIncense.MinorFeature.Guid,
                RuneDomainIncense.MajorFeature.Guid,
                ScalykindDomainIncense.MinorFeature.Guid,
                ScalykindDomainIncense.MajorFeature.Guid,
                StrengthDomainIncense.MinorFeature.Guid,
                StrengthDomainIncense.MajorFeature.Guid,
                SunDomainIncense.MinorFeature.Guid,
                SunDomainIncense.MajorFeature.Guid,
                TravelDomainIncense.MinorFeature.Guid,
                TravelDomainIncense.MajorFeature.Guid,
                TrickeryDomainIncense.MinorFeature.Guid,
                TrickeryDomainIncense.MajorFeature.Guid,
                WarDomainIncense.MinorFeature.Guid,
                WarDomainIncense.MajorFeature.Guid,
                WaterDomainIncense.MinorFeature.Guid,
                WaterDomainIncense.MajorFeature.Guid,
                WeatherDomainIncense.MinorFeature.Guid,
                WeatherDomainIncense.MajorFeature.Guid,
                ])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal static void ConfigureIncenseAbilityAreaRunAction()
    {
        var duration = ContextDuration.VariableDice(DiceType.D4, diceCount: 1, bonus: 0);
        var minorBuffAction = ActionsBuilder.New()
            .ApplyBuff(buff: BuffRefs.IncenseFogSickenedBuff.ToString(), durationValue: duration, isNotDispelable: true);

        var majorBuffAction = ActionsBuilder.New()
            .ApplyBuff(buff: BuffRefs.IncenseFogNauseatedBuff.ToString(), durationValue: duration, sameDuration: true, isNotDispelable: true)
            .ApplyBuff(buff: BuffRefs.IncenseFogSickenedBuff.ToString(), durationValue: duration, sameDuration: true, isNotDispelable: true);


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
                                        durationValue: ContextDuration.FixedDice(diceType: DiceType.D4)))
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

        var enemyCondition = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsAlly(negate: true), ifTrue: action);

        AbilityAreaEffectConfigurator.For(DeaconIncenseFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectRunAction(unitEnter: enemyCondition, mergeBehavior: ComponentMerge.Replace)
            .Configure();
    }
}
