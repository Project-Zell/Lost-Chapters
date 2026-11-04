using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense
{
    internal class ProtectionBlessedIncense
    {
        private static readonly string BaseName = "ProtectionBlessedIncense";
        private static readonly string Domain = FeatureRefs.ProtectionDomainAllowed.ToString();

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
            public static readonly string Guid = "{5758f80b-0249-4d6d-ae7a-99cabec0fcc3}";

            internal static void Configure()
            {
                Buff.Configure();
            }

            internal class Buff
            {
                public static readonly string Guid = "{8d161665-9032-4835-94f4-509eee8a6797}";

                private static readonly string BuffName = $"{BaseName}MinorBuff";

                internal static void Configure()
                {
                    BuffConfigurator.New(BuffName, Guid)
                        .AddStatBonus(stat: StatType.AC, value: 2, descriptor: ModifierDescriptor.Alchemical)
                        .Configure();
                }
            }
        }

        internal class MajorFeature
        {
            public static readonly string Guid = "{c5178e09-9c49-4705-b06b-d35c9bc0978f}";

            internal static void Configure()
            {
                Buff.Configure();
            }

            internal class Buff
            {
                public static readonly string Guid = "{69ffe6c4-eb8b-4fd0-a08e-8e7b0b4759cd}";

                private static readonly string BuffName = $"{BaseName}MajorBuff";

                internal static void Configure()
                {
                    BuffConfigurator.New(BuffName, Guid)
                        .AddStatBonus(stat: StatType.AC, value: 4, descriptor: ModifierDescriptor.Alchemical)
                        .Configure();
                }
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{371a43b8-7eec-445d-ab83-446adf9756ce}";
    }
}