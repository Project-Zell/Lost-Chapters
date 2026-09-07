using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;
    
internal class ArtificeDomainIncense
{
    private static readonly string BaseName = "PulverizedSteel";
    private static readonly string Domain = FeatureRefs.ArtificeDomainAllowed.ToString();

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
        public static readonly string Guid = "{2bd1db33-09f2-44e8-a4ed-8e58dcb0d0bb}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{484d04ac-d9a3-42f7-8f68-c31ea1787a23}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddDamageResistancePhysical(value: 2, isStackable: true)
                    .Configure();
            }
        }
    }


    internal class MajorFeature
    {
        public static readonly string Guid = "{04bba21c-7423-4778-bc67-1940aa60d8c9}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{2a5abf75-e5c8-41d4-b4cb-b6ee39c4dc51}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddDamageResistancePhysical(value: 5, isStackable: true)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{038771bc-6c6f-4d3f-a702-f9ba16046803}";
    }
}