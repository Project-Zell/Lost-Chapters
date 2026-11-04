using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class RuneBlessedIncense
{
    private static readonly string BaseName = "RuneBlessedIncense";
    private static readonly string Domain = FeatureRefs.RuneDomainAllowed.ToString();

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
        public static readonly string Guid = "{1e8f7aae-fc85-4ad8-a8a0-29fd567796b6}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{db7cfe0f-6434-44ee-ab46-b2ff4936c590}";

            private static readonly string BuffName = $"{BaseName}MinorAllyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddCMDBonusAgainstManeuvers(value: 2, maneuvers: [CombatManeuver.Trip], descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }

        internal class EnemyBuff
        {
            public static readonly string Guid = "{7a56261f-315e-4d60-babd-aa0f981c2bdb}";

            private static readonly string BuffName = $"{BaseName}MinorEnemyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(stat: StatType.SaveWill, value: -1, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveReflex, value: -1, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveFortitude, value: -1, descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }


    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{06a05c69-aa9b-4e61-9500-01f39eb253f6}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{35e11d01-48cc-4e47-92cc-03f4dd3ba2a3}";

            private static readonly string BuffName = $"{BaseName}MajorAllyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddCMDBonusAgainstManeuvers(value: 4, maneuvers: [CombatManeuver.Trip], descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }

        internal class EnemyBuff
        {
            public static readonly string Guid = "{4a0c52a8-5019-4a2a-a0d2-1656df9c4eb7}";

            private static readonly string BuffName = $"{BaseName}MajorEnemyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(stat: StatType.SaveWill, value: -2, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveReflex, value: -2, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveFortitude, value: -2, descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{b22eeb91-9512-4df8-8187-505a339cacee}";
    }
}