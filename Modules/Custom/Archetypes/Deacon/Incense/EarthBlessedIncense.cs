using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class EarthBlessedIncense
{
    private static readonly string BaseName = "EarthBlessedIncense";
    private static readonly string Domain = FeatureRefs.EarthDomainAllowed.ToString();

    private static readonly DamageEnergyType EnergyType = DamageEnergyType.Acid;

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
        public static readonly string Guid = "{6e1ebd2b-06e7-4e47-8ca2-bee25fac5e12}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{00e938a4-4a81-4520-9773-58ea3d55fb9f}";

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
        public static readonly string Guid = "{3caf5da4-867c-4545-8887-6dbd02a7d6b3}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{52308d39-02a9-466c-83ef-fe6e498c8a0d}";

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
        public static readonly string Guid = "{a8ef1b5d-fe23-451a-8cf2-ac189aa7073e}";
    }
}
