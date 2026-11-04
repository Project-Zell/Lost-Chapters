using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class WaterBlessedIncense
{
    private static readonly string BaseName = "WaterBlessedIncense";
    private static readonly string Domain = FeatureRefs.WaterDomainAllowed.ToString();
    private static readonly DamageEnergyType EnergyType = DamageEnergyType.Cold;

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
        public static readonly string Guid = "{f25fc5cf-86a0-4dbb-b719-4ae123134af5}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{c37ec836-fb92-4503-b52c-ecb31d76a00a}";

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
        public static readonly string Guid = "{9010835b-441e-4002-9d9f-f39e32c8a6a3}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{124a3f5c-d6ae-4969-8e68-5fb6127b3499}";

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
        public static readonly string Guid = "{54b2d058-df42-4294-a119-5ae71ae0e02d}";
    }
}