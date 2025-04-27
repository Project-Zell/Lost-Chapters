using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.AVEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Facts;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class DeadCalmFeature
{
    public static readonly string Guid = "{fb76cc07-608a-4f25-bc2c-ee792b3e87c0}";

    private static readonly string FeatureName = "DeadCalm";
    private static readonly string DisplayName = "DeadCalm.Name";
    private static readonly string Description = "DeadCalm.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/deadcalm.png";

    internal static void Configure()
    {
        Cooldown.Configure();
        Resource.Configure();
        RageBuff.Configure();
        Ability.Configure();
        RageFact.Configure();
        ExtraDeadCalmFeature.Configure();

        var feature = FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid, RageFact.Guid])
            .SetIsClassFeature(true)
            .SetIsPrerequisiteFor(ExtraDeadCalmFeature.Guid)
            .SetHideInCharacterSheetAndLevelUp(true)
            .SetIcon(Icon)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        FeatureConfigurator.For(FeatureRefs.LimitlessRage)
            .EditComponent(delegate (PrerequisiteFeaturesFromList prerequisite)
            {
                prerequisite.m_Features = CommonTool.Append(prerequisite.m_Features, feature.ToReference<BlueprintFeatureReference>());
            })
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{87ad9b29-9edc-4403-9977-c476a49aa408}";

        private static readonly string AbilityName = "DeadCalm.Ability";
        private static readonly string Description = "DeadCalm.Ability.Description";
        internal static void Configure()
        {
            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .AddActivatableAbilityResourceLogic(
                    requiredResource: Resource.Guid,
                    spendType: ActivatableAbilityResourceLogic.ResourceSpendType.NewRound,
                    freeBlueprint: FeatureRefs.LimitlessRage.ToString())
                .AddRestrictionHasFact(feature: Cooldown.Guid, not: true)
                .AddActionPanelLogic(priority: 3)
                .SetGroup(ActivatableAbilityGroup.Rage)
                .SetBuff(RageBuff.Guid)
                .SetWeightInGroup(1)
                .SetIsOnByDefault(true)
                .SetDeactivateIfCombatEnded(true)
                .SetDeactivateImmediately(true)
                .SetDeactivateIfOwnerUnconscious(true)
                .SetActivationType(AbilityActivationType.Immediately)
                .SetActivateWithUnitCommand(UnitCommand.CommandType.Free)
                .SetActivateOnUnitAction(AbilityActivateOnUnitActionType.Attack)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class RageBuff
    {
        public static readonly string Guid = "{a66dc70f-5ba4-40fb-9983-fda8949db375}";

        private static readonly string BuffName = "DeadCalm.RageBuff";
        private static readonly string Description = "DeadCalm.RageBuff.Description";

        internal static void Configure()
        {
            var contextValue = ContextValues.Rank(type: AbilityRankType.StatBonus);
            var rankConfig = ContextRankConfigs.FeatureList([PursuerFeature.Guid, DreadPressenceFeature.Guid], type: AbilityRankType.StatBonus).WithLinearProgression(1, 1, startingBaseValue: 0);

            var recklessStanceCondition = ConditionsBuilder.New().HasFact(BuffRefs.RecklessStanceSwitchBuff.ToString());
            var recklessStanceAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.RecklessStanceEffectBuff.ToString(), asChild: true);

            var inspireFerocityCondition = ConditionsBuilder.New().HasFact(BuffRefs.RecklessStanceSwitchBuff.ToString()).HasFact(BuffRefs.InspireFerocityBaseBuff.ToString());
            var inspireFerocityAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.InspireFerocityRageBuff.ToString(), asChild: true);

            var animalFuryCondition = ConditionsBuilder.New().HasFact(FeatureRefs.AnimalFuryFeature.ToString());
            var animalFuryAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.AnimalFuryRageBuff.ToString(), asChild: true);

            var swiftFootCondition = ConditionsBuilder.New().HasFact(FeatureRefs.SwiftFootFeature.ToString());
            var swiftFootAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.SwiftFootRageBuff.ToString(), asChild: true);

            var internalFortitudeCondition = ConditionsBuilder.New().HasFact(FeatureRefs.InternalFortitudeFeature.ToString());
            var internalFortitudeAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.InternalFortitudeRageBuff.ToString(), asChild: true);

            var lethalStanceCondition = ConditionsBuilder.New().HasFact(BuffRefs.LethalStanceSwitchBuff.ToString());
            var lethalStanceAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.LethalStanceEffectBuff.ToString(), asChild: true);

            var beastTotemLesserCondition = ConditionsBuilder.New().HasFact(FeatureRefs.BeastTotemLesserFeature.ToString());
            var beastTotemLesserAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.BeastTotemLesserRageBuff.ToString(), asChild: true);

            var beastTotemCondition = ConditionsBuilder.New().HasFact(FeatureRefs.BeastTotemFeature.ToString());
            var beastTotemAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.BeastTotemRageBuff.ToString(), asChild: true);

            var beastTotemGreaterCondition = ConditionsBuilder.New().HasFact(FeatureRefs.BeastTotemGreaterFeature.ToString());
            var beastTotemGreaterAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.BeastTotemGreaterRageBuff.ToString(), asChild: true);

            var fearlessRageCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FearlessRageFeature.ToString());
            var featlessRageAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FearlessRageRageBuff.ToString(), asChild: true);

            var guardedStanceCondition = ConditionsBuilder.New().HasFact(BuffRefs.GuardedStanceSwitchBuff.ToString());
            var guardedStanceAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.GuardedStanceEffectBuff.ToString(), asChild: true);

            var scentCondition = ConditionsBuilder.New().HasFact(FeatureRefs.ScentFeature.ToString());
            var scentAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.ScentRageBuff.ToString(), asChild: true);

            var fiendTotemLesserCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FiendTotemLesserFeature.ToString());
            var fiendTotemLesserAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FiendTotemLesserRageBuff.ToString(), asChild: true);

            var fiendTotemCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FiendTotemFeature.ToString());
            var fiendTotemAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FiendTotemRageBuff.ToString(), asChild: true);

            var fiendTotemGreaterCondition = ConditionsBuilder.New().HasFact(FeatureRefs.FiendTotemGreaterFeature.ToString());
            var fiendTotemGreaterAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.FiendTotemGreaterRageBuff.ToString(), asChild: true);

            var clearMindCondition = ConditionsBuilder.New().HasFact(FeatureRefs.ClearMindFeature.ToString());
            var clearMindAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.ClearMindBuff.ToString(), asChild: true);

            var comeAndGetMeCondition = ConditionsBuilder.New().HasFact(BuffRefs.ComeAndGetMeSwitchBuff.ToString());
            var comeAndGetMeAction = ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.ComeAndGetMeEffectBuff.ToString(), asChild: true);

            var contextSharedValue = ContextValues.Constant(2);

            var onDeactivate = ActionsBuilder.New()
                .RemoveBuff(BuffRefs.RecklessStanceEffectBuff.ToString())
                .RemoveBuff(BuffRefs.InspireFerocityRageBuff.ToString())
                .RemoveBuff(buff: BuffRefs.LethalStanceEffectBuff.ToString())
                .RemoveBuff(BuffRefs.GuardedStanceEffectBuff.ToString())
                .RemoveBuff(buff: BuffRefs.ScentRageBuff.ToString())
                .RemoveBuff(buff: BuffRefs.FiendTotemLesserRageBuff.ToString())
                .RemoveBuff(buff: BuffRefs.FiendTotemLesserRageBuff.ToString())
                .RemoveBuff(buff: BuffRefs.FiendTotemGreaterRageBuff.ToString())
                .RemoveBuff(buff: BuffRefs.ClearMindBuff.ToString())
                .RemoveBuff(buff: BuffRefs.ComeAndGetMeEffectBuff.ToString())
                .Conditional(ConditionsBuilder.New().HasFact(InstantDispassionFeature.Guid, negate: true),
                    ifTrue: ActionsBuilder.New().ApplyBuff(Cooldown.Guid, ContextDuration.Fixed(1, rate: DurationRate.Minutes)));

            var onActivate = ActionsBuilder.New()
                .OnContextCaster(ActionsBuilder.New().SpawnFx("a536a9fb639035140b8771b2e3a21ffd"))
                .ChangeSharedValueAddTo(addValue: contextSharedValue, sharedValue: AbilitySharedValue.Duration)
                .Conditional(conditions: recklessStanceCondition, ifTrue: recklessStanceAction)
                .Conditional(conditions: inspireFerocityCondition, ifTrue: inspireFerocityAction)
                .Conditional(conditions: animalFuryCondition, ifTrue: animalFuryAction)
                .Conditional(conditions: swiftFootCondition, ifTrue: swiftFootAction)
                .Conditional(conditions: internalFortitudeCondition, ifTrue: internalFortitudeAction)
                .Conditional(conditions: lethalStanceCondition, ifTrue: lethalStanceAction)
                .Conditional(conditions: beastTotemLesserCondition, ifTrue: beastTotemLesserAction)
                .Conditional(conditions: beastTotemCondition, ifTrue: beastTotemAction)
                .Conditional(conditions: beastTotemGreaterCondition, ifTrue: beastTotemGreaterAction)
                .Conditional(conditions: fearlessRageCondition, ifTrue: featlessRageAction)
                .Conditional(conditions: guardedStanceCondition, ifTrue: guardedStanceAction)
                .Conditional(conditions: scentCondition, ifTrue: scentAction)
                .Conditional(conditions: fiendTotemLesserCondition, ifTrue: fiendTotemLesserAction)
                .Conditional(conditions: fiendTotemCondition, ifTrue: fiendTotemAction)
                .Conditional(conditions: fiendTotemGreaterCondition, ifTrue: fiendTotemGreaterAction)
                .Conditional(conditions: clearMindCondition, ifTrue: clearMindAction)
                .Conditional(conditions: comeAndGetMeCondition, ifTrue: comeAndGetMeAction);

            var onNewRound = ActionsBuilder.New().ChangeSharedValueAddTo(addValue: contextSharedValue, sharedValue: AbilitySharedValue.Duration);

            BuffConfigurator.New(BuffName, Guid)
                .AddBuffParticleEffectPlay(playOnActivate: true)
                .AddContextRankConfig(rankConfig)
                .AddTemporaryHitPointsPerLevel(
                    descriptor: ModifierDescriptor.Rage,
                    hitPointsPerLevel: 1,
                    limitlessRage: true,
                    limitlessRageBlueprint: FeatureRefs.LimitlessRage.ToString(),
                    limitlessRageResource: Resource.Guid,
                    value: contextValue)
                .AddSpellDescriptorComponent(SpellDescriptor.TemporaryHP)
                .AddContextStatBonus(stat: StatType.SaveWill, value: contextValue)
                .AddContextStatBonus(stat: StatType.CheckIntimidate, value: contextValue)
                .AddWeaponAttackTypeDamageBonus(type: WeaponRangeType.Melee, attackBonus: 1, value: contextValue)
                .AddAttackTypeAttackBonus(type: WeaponRangeType.Melee, attackBonus: 1, value: contextValue)
                .AddWeaponGroupDamageBonus(weaponGroup: WeaponFighterGroup.Thrown, damageBonus: 1, additionalValue: contextValue)
                .AddContextCalculateSharedValue(
                    valueType: AbilitySharedValue.Duration,
                    modifier: 1)
                .AddFactContextActions(
                    activated: onActivate,
                    deactivated: onDeactivate,
                    newRound: onNewRound)
                .SetFxOnStart("53c86872d2be80b48afc218af1b204d7")
                .SetIsClassFeature(true)
                .AddToFlags(BlueprintBuff.Flags.StayOnDeath)
                .SetStacking(StackingType.Replace)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();

            BuffConfigurator.For(BuffRefs.RecklessStanceSwitchBuff.ToString())
                .AddFactContextActions(
                    activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(Guid),
                        ifTrue: recklessStanceAction),
                    deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.RecklessStanceEffectBuff.ToString()))
                .Configure();

            BuffConfigurator.For(BuffRefs.LethalStanceSwitchBuff.ToString())
                .AddFactContextActions(
                    activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(Guid),
                        ifTrue: lethalStanceAction),
                    deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.LethalStanceEffectBuff.ToString()))
                .Configure();

            BuffConfigurator.For(BuffRefs.GuardedStanceSwitchBuff.ToString())
                .AddFactContextActions(
                    activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(Guid),
                        ifTrue: guardedStanceAction),
                    deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.GuardedStanceEffectBuff.ToString()))
                .Configure();

            BuffConfigurator.For(BuffRefs.ComeAndGetMeSwitchBuff.ToString())
                .AddFactContextActions(
                    activated: ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(Guid),
                        ifTrue: comeAndGetMeAction),
                    deactivated: ActionsBuilder.New().RemoveBuff(BuffRefs.ComeAndGetMeEffectBuff.ToString()))
                .Configure();

            BuffConfigurator.For(BuffRefs.PowerfulStanceSwitchBuff.ToString())
                .AddBuffExtraEffects(checkedBuff: Guid, extraEffectBuff: BuffRefs.PowerfulStanceEffectBuff.ToString())
                .Configure();

            FeatureConfigurator.For(FeatureRefs.CelestialTotemFeature)
                .AddBuffExtraEffects(checkedBuff: Guid, extraEffectBuff: BuffRefs.CelestialTotemAreaBuff.ToString())
                .Configure();

            FeatureConfigurator.For(FeatureRefs.CelestialTotemGreaterFeature)
                .AddBuffExtraEffects(checkedBuff: Guid, extraEffectBuff: BuffRefs.CelestialTotemGreaterBuff.ToString())
                .Configure();

            FeatureConfigurator.For(FeatureRefs.CelestialTotemLesserFeature)
                .AddBuffExtraEffects(checkedBuff: Guid, extraEffectBuff: BuffRefs.CelestialTotemLesserBuff.ToString())
                .Configure();

            FeatureConfigurator.For(FeatureRefs.DaemonTotemFeature)
                .AddBuffExtraEffects(checkedBuff: Guid, extraEffectBuff: BuffRefs.DaemonTotemBuff.ToString())
                .Configure();

            FeatureConfigurator.For(FeatureRefs.DaemonTotemGreaterFeature)
                .AddBuffExtraEffects(checkedBuff: Guid, extraEffectBuff: BuffRefs.DaemonTotemGreaterBuff.ToString())
                .Configure();

            FeatureConfigurator.For(FeatureRefs.DaemonTotemLesserFeature)
                .AddBuffExtraEffects(checkedBuff: Guid, extraEffectBuff: BuffRefs.DaemonTotemLesserBaseBuff.ToString())
                .Configure();

            AbilityConfigurator.For(AbilityRefs.ChargeAbility)
                .AddAbilityCasterHasNoFacts([Guid])
                .Configure();
        }
    }

    internal class Cooldown
    {
        public static readonly string Guid = "{0497070a-f6b6-4889-bd7d-ba0454377fdf}";

        private static readonly string BuffName = "DeadCalm.CooldownBuff";
        private static readonly string DisplayName = "DeadCalm.CooldownBuff.Name";
        private static readonly string Description = "DeadCalm.CooldownBuff.Description";

        private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/deadcalmcooldown.png";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddToFlags(BlueprintBuff.Flags.RemoveOnRest)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{1a0935f4-efd5-4f80-af99-c7435288ab19}";
        
        private static readonly string ResourceName = "DeadCalm.Resource";

        internal static void Configure()
        {
            var resourceBuilder = ResourceAmountBuilder.New(2)
                .IncreaseByLevel(classes: [CharacterClassRefs.BarbarianClass.ToString()], bonusPerLevel: 2)
                .IncreaseByStat(StatType.Constitution);

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(builder: resourceBuilder)
                .Configure();
        }
    }

    internal class RageFact
    {
        public static readonly string Guid = "{9ad82ac5-fbac-4729-a668-b814a41f8968}";

        private static readonly string FactName = "DeadCalm.RageFact";

        internal static void Configure()
        {
            UnitFactConfigurator.New(FactName, Guid)
                .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
                .Configure();
        }
    }
}
