using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class AnimalDomainIncense
{
    private static readonly string IncenceName = "SavageBreath";
    private static readonly string Domain = FeatureRefs.AnimalDomainAllowed.ToString();
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";
    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        AbilityAreaEffectConfigurator.For(DeaconIncenseFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectBuff(
                buff: MinorBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid, negate: true))
            .AddAbilityAreaEffectBuff(
                buff: MajorBuff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{6c8becb8-a7b6-4018-a96a-2aa7607a85de}";

        private static readonly string FeatureName = $"{IncenceName}.MinorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MinorBuff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class MinorBuff
    {
        public static readonly string Guid = "{d44f5eb7-e857-4b9e-ad83-f41e425915d7}";

        private static readonly string BuffName = $"{IncenceName}.MinorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var duration = ContextDuration.FixedDice(diceType: DiceType.Zero ,bonus: 5, rate: DurationRate.Rounds);

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsEnemy(),
                ifTrue: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Bleed1d6Buff.ToString(), durationValue: duration, asChild: true));

            BuffConfigurator.New(BuffName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(action: action, onlyOnFirstAttack: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{f31e63ce-6092-4bce-b9e6-b8a3059b89f0}";

        private static readonly string FeatureName = $"{IncenceName}.MajorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            MajorBuff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .AddPrerequisiteFeature(MinorFeature.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class MajorBuff
    {
        public static readonly string Guid = "{a017314d-46db-444e-a1ca-c90416f15e40}";

        private static readonly string BuffName = $"{IncenceName}.MajorBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var duration = ContextDuration.FixedDice(diceType: DiceType.Zero, bonus: 5, rate: DurationRate.Rounds);

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsEnemy(),
                ifTrue: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Bleed2d6Buff.ToString(), durationValue: duration, asChild: true));

            BuffConfigurator.New(BuffName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(action: action, onlyOnFirstAttack: true)
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.Pounce)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
