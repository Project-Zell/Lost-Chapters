using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;
using static Kingmaker.EntitySystem.EntityDataBase;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class MadnessBlessedIncense
{
    private static readonly string BaseName = "MadnessBlessedIncense";
    private static readonly string Domain = FeatureRefs.MadnessDomainAllowed.ToString();

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
        public static readonly string Guid = "{bc5a397e-4fdf-41aa-85ab-2c07f320743e}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{21589c57-b32e-40f7-99c6-7789a1ae775e}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSecondaryAttacks(weapon: ItemWeaponRefs.Bite1d6.ToString())
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{ea2540f4-fc46-4c7c-8d12-6f883979a7b3}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{98ae9a97-cf59-42c1-97f6-c4b81eb0553c}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddSecondaryAttacks(weapon: ItemWeaponRefs.Bite2d6.ToString())
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{336dcc35-a1bf-4ddf-b8cd-8b1e1767c480}";
    }
}