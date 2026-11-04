using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class CharmBlessedIncense
{
    private static readonly string BaseName = "CharmBlessedIncense";
    private static readonly string Domain = FeatureRefs.CharmDomainAllowed.ToString();

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
        public static readonly string Guid = "{1e0414e5-907d-4ad8-a0f2-d7c0a8896866}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{2bfd380f-6003-4698-a43c-e8568c28f4eb}";

            private static readonly string BuffName = $"{BaseName}MinorAllyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Charisma, value: 2)
                    .Configure();
            }
        }
        internal class EnemyBuff
        {
            public static readonly string Guid = "{92599e7d-cbe8-419a-9277-da2da21714de}";

            private static readonly string BuffName = $"{BaseName}MinorEnemyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Charm, value: -2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{57955b3a-2563-4468-9cfc-79e987eaf2c9}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{cf872af6-a970-460f-8288-2fe143b6eb2c}";

            private static readonly string BuffName = $"{BaseName}MajorAllyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Charisma, value: 4)
                    .Configure();
            }
        }

        internal class EnemyBuff
        {
            public static readonly string Guid = "{83de1d72-62a3-4625-84d2-8cd6658d6045}";

            private static readonly string BuffName = $"{BaseName}MajorEnemyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Charm, value: -4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{4215bbd0-8bae-4038-ae9d-fce2f4f857f2}";
    }
}