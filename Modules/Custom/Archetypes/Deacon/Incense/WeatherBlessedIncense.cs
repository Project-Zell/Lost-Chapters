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
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class WeatherBlessedIncense
{
    private static readonly string BaseName = "WeatherBlessedIncense";
    private static readonly string Domain = FeatureRefs.WeatherDomainAllowed.ToString();
    private static readonly DamageEnergyType EnergyType = DamageEnergyType.Sonic;

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        var minorBuffContainer = (MinorFeature.Buff.Guid, DeaconInsenceHelper.TargetType.Ally);
        var majorBuffContainer = (MajorFeature.Buff.Guid, DeaconInsenceHelper.TargetType.Ally);

        DeaconInsenceHelper.CreateInsence(
            baseName: BaseName,
            domainGuid: Domain,
            minorFeatureGuid: MinorFeature.Guid,
            majorFeatureGuid: MajorFeature.Guid,
            extraIncenceGuid: ExtraIncenseProgression.Guid,
            minorBuffs: [minorBuffContainer],
            majorBuffs: [majorBuffContainer]);
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{60ff2aba-9e8b-4fec-b8de-c5593ceb2a95}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{10f6e343-84ef-4290-8de3-61a4fa486740}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

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
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{43140c33-991f-4a2c-911b-f109da15db36}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{327f0ac3-fa40-46bf-b6ec-3b4ef8c77cba}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

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
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{e039411b-9e21-4fa2-b130-d210dfa7184f}";
    }
}
