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
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class DeathDomainIncense
{
    private static readonly string IncenceName = "PerditionHaze";
    private static readonly string Domain = FeatureRefs.DeathDomainAllowed.ToString();
    private static readonly DamageEnergyType EnergyType = DamageEnergyType.NegativeEnergy;
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
        public static readonly string Guid = "{4e0b1ada-dedd-4e92-a370-6ec472afd7d6}";

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
        public static readonly string Guid = "{073165a8-3869-43a2-a003-99d96b24b285}";

        private static readonly string BuffName = $"{IncenceName}.MinorBuff";
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

    internal class MajorFeature
    {
        public static readonly string Guid = "{9317dab9-05d0-4397-90ab-cfae796c70d7}";

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
        public static readonly string Guid = "{d0316a0c-b6ff-4f9d-8b31-e16e07bce3be}";

        private static readonly string BuffName = $"{IncenceName}.MajorBuff";
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
