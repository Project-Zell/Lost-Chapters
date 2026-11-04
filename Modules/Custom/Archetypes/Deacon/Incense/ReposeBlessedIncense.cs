using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class ReposeBlessedIncense
{
    private static readonly string BaseName = "ReposeBlessedIncense";
    private static readonly string Domain = FeatureRefs.ReposeDomainAllowed.ToString();

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
        public static readonly string Guid = "{5b96043c-4679-478f-8022-d5a0d8e06938}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{1f0fffb4-1ca8-489c-bed0-ff7c90a49a77}";

            private static readonly string BuffName = $"{BaseName}Buff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Wisdom, value: 2)
                    .AddConcentrationBonus(value: 1)
                    .Configure();
            }
        }
    }
    internal class MajorFeature
    {
        public static readonly string Guid = "{3015ff0c-912d-4f44-9a76-0307f3c8c524}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{5e57bea0-942d-42de-85cc-197099017517}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Wisdom, value: 4)
                    .AddConcentrationBonus(value: 2)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{7c439353-7bf8-407f-baac-fcf21765fdd9}";
    }
}