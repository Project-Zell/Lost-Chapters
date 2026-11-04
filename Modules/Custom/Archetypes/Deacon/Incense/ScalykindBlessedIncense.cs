using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class ScalykindBlessedIncense
{
    private static readonly string BaseName = "ScalykindBlessedIncense";
    private static readonly string Domain = FeatureRefs.ScalykindDomainAllowed.ToString();

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        var minorAllyBuffContainer = (MinorFeature.AllyBuff.Guid, DeaconInsenceHelper.TargetType.Ally);
        var majorAllyBuffContainer = (MajorFeature.AllyBuff.Guid, DeaconInsenceHelper.TargetType.Ally);

        var minorEnemyBuffContainer = (MinorFeature.EnemyBuff.Guid, DeaconInsenceHelper.TargetType.Enemy);
        var majorEnemyBuffContainer = (MajorFeature.EnemyBuff.Guid, DeaconInsenceHelper.TargetType.Enemy);

        DeaconInsenceHelper.CreateInsence(
            baseName: BaseName,
            domainGuid: Domain,
            minorFeatureGuid: MinorFeature.Guid,
            majorFeatureGuid: MajorFeature.Guid,
            extraIncenceGuid: ExtraIncenseProgression.Guid,
            minorBuffs: [minorAllyBuffContainer, minorEnemyBuffContainer],
            majorBuffs: [majorAllyBuffContainer, majorEnemyBuffContainer]);
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{89d9d8c3-1dc7-4b33-956e-b6b4d1b1b5f7}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{a1b57ffb-06b1-480e-91e9-781d0e8f6fb6}";

            private static readonly string BuffName = $"{BaseName}AllyMinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Dexterity, value: 2)
                    .Configure();
            }
        }

        internal class EnemyBuff
        {
            public static readonly string Guid = "{18294d54-aee2-406d-b945-a6d8d27ee8f4}";

            private static readonly string BuffName = $"{BaseName}EnemyMinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Poison, value: -2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{5ac329e1-2077-42ae-b26c-77e2afbca8be}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{9c5fbf68-5d4a-4b38-813e-8e2e7adc0f9d}";

            private static readonly string BuffName = $"{BaseName}AllyMajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Dexterity, value: 4)
                    .Configure();
            }
        }

        internal class EnemyBuff
        {
            public static readonly string Guid = "{d4fb8268-4e0d-4fc1-9236-cfbe84472770}";

            private static readonly string BuffName = $"{BaseName}EnemyMajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Poison, value: -4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{781cfed1-061d-46ed-b816-75314b2f9ffd}";
    }
}