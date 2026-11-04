using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class MagicBlessedIncense
{
    private static readonly string BaseName = "MagicBlessedIncense";
    private static readonly string Domain = FeatureRefs.MagicDomainAllowed.ToString();

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
        public static readonly string Guid = "{5d3f85c6-c3c2-47f3-8aba-e35b35c7e78c}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{f631ad0a-81b7-4774-883c-d21a1c352b80}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSpellPenetrationBonus(value: 1, descriptor: ModifierDescriptor.Alchemical)
                    .AddSpellResistance(value: 10)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{ddc07e61-cd48-444b-9c46-56156e051bae}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{b7c327d1-546e-48af-a63c-c78cde9b9c45}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                var value = ContextValues.Rank();
                var config = ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()], min: 10, max: 30).WithBonusValueProgression(10);

                BuffConfigurator.New(BuffName, Guid)
                    .AddSpellPenetrationBonus(value: 2, descriptor: ModifierDescriptor.Alchemical)
                    .AddSpellResistance(value: value)
                    .AddContextRankConfig(config)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{c1132bf4-dd7d-4f42-8ae2-6a8266b2b53f}";
    }
}