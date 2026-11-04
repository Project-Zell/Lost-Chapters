using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class HealingBlessedIncense
{
    private static readonly string BaseName = "HealingBlessedIncense";
    private static readonly string Domain = FeatureRefs.HealingDomainAllowed.ToString();

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
        public static readonly string Guid = "{413ce19b-775f-46d7-8e56-101d1ecce843}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{7870faa5-2c09-478c-b233-ff8842a6bf6c}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddEffectFastHealing(heal: 2)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{2e896e0d-b2be-4b29-9de9-223a58ef305b}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{1a4bd3a2-0c98-4975-9d53-1fa4948519cd}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                var value = ContextValues.Rank();
                var rankConfig = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.WarpriestClass.ToString()]).WithDiv2Progression();

                BuffConfigurator.New(BuffName, Guid)
                    .AddEffectContextFastHealing(bonus: value)
                    .AddContextRankConfig(rankConfig)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{f04a5e55-5727-456d-947f-473fec5c1a81}";
    }
}