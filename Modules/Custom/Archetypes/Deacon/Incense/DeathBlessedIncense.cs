using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class DeathBlessedIncense
{
    private static readonly string BaseName = "DeathBlessedIncense";
    private static readonly string Domain = FeatureRefs.DeathDomainAllowed.ToString();

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
        public static readonly string Guid = "{4e0b1ada-dedd-4e92-a370-6ec472afd7d6}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{073165a8-3869-43a2-a003-99d96b24b285}";

            private static readonly string BuffName = $"{BaseName}MinorAllyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Death, bonus: 2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }

        internal class EnemyBuff
        {
            public static readonly string Guid = "{de8c0f0d-6d37-4bc7-98a8-6ac9ed9c2bf7}";

            private static readonly string BuffName = $"{BaseName}MinorEnemyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Fear, bonus: -2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{9317dab9-05d0-4397-90ab-cfae796c70d7}";

        internal static void Configure()
        {
            AllyBuff.Configure();
            EnemyBuff.Configure();
        }

        internal class AllyBuff
        {
            public static readonly string Guid = "{d0316a0c-b6ff-4f9d-8b31-e16e07bce3be}";

            private static readonly string BuffName = $"{BaseName}MajorAllyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Death, bonus: 4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }

        internal class EnemyBuff
        {
            public static readonly string Guid = "{9d6fae95-e787-4e1d-9b80-5ffc0ae519cc}";

            private static readonly string BuffName = $"{BaseName}MajorEnemyBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Fear, bonus: -4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{0bccca45-e5f8-4714-86ef-bbbe25ee9023}";
    }
}