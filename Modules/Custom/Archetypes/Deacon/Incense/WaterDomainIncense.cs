using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class WaterDomainIncense
{
    private static readonly string BaseName = "ChillingFume";
    private static readonly string Domain = FeatureRefs.WaterDomainAllowed.ToString();
    private static readonly DamageEnergyType EnergyType = DamageEnergyType.Cold;
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        AbilityAreaEffectConfigurator.For(CenserBurnerFeature.AbilityArea.Guid)
            .AddAbilityAreaEffectBuff(
                buff: MinorFeature.Buff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid, negate: true))
            .AddAbilityAreaEffectBuff(
                buff: MajorFeature.Buff.Guid,
                condition: ConditionsBuilder.New().IsAlly().CasterHasFact(MinorFeature.Guid).CasterHasFact(MajorFeature.Guid))
            .Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{f25fc5cf-86a0-4dbb-b719-4ae123134af5}";

        private static readonly string FeatureName = $"{BaseName}MinorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{c37ec836-fb92-4503-b52c-ecb31d76a00a}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                var diceValue = new ContextDiceValue
                {
                    DiceType = DiceType.D6,
                    DiceCountValue = 1,
                    BonusValue = 0
                };

                var damageType = new DamageTypeDescription
                {
                    Type = DamageType.Energy,
                    Energy = EnergyType
                };

                BuffConfigurator.New(BuffName, Guid)
                    .AdditionalDiceOnAttack(value: diceValue, damageType: damageType)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{9010835b-441e-4002-9d9f-f39e32c8a6a3}";

        private static readonly string FeatureName = $"{BaseName}MajorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .AddPrerequisiteFeature(MinorFeature.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{124a3f5c-d6ae-4969-8e68-5fb6127b3499}";

            private static readonly string BuffName = $"{FeatureName}Buff";
            private static readonly string DisplayName = $"{BuffName}.Name";
            private static readonly string Description = $"{BuffName}.Description";

            internal static void Configure()
            {
                var diceValue = new ContextDiceValue
                {
                    DiceType = DiceType.D6,
                    DiceCountValue = 2,
                    BonusValue = 0
                };

                var damageType = new DamageTypeDescription
                {
                    Type = DamageType.Energy,
                    Energy = EnergyType
                };

                var value = ContextValues.Rank();
                var config = ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()], min: 10, max: 30).WithBonusValueProgression(10);

                BuffConfigurator.New(BuffName, Guid)
                    .AdditionalDiceOnAttack(value: diceValue, damageType: damageType)
                    .AddDamageResistanceEnergy(type: EnergyType, value: value)
                    .AddContextRankConfig(config)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
