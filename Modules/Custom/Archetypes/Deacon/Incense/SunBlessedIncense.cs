using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class SunBlessedIncense
{
    private static readonly string BaseName = "SunBlessedIncense";
    private static readonly string Domain = FeatureRefs.SunDomainAllowed.ToString();

    internal static void Configure()
    {
        CooldownBuff.Configure();

        DeaconInsenceHelper.CreateInsence(
            baseName: BaseName,
            domainGuid: Domain,
            minorFeatureGuid: MinorFeature.Guid,
            majorFeatureGuid: MajorFeature.Guid,
            extraIncenceGuid: ExtraIncenseProgression.Guid,
            minorBuffs: [],
            majorBuffs: []);
    }

    internal class CooldownBuff
    {
        public static readonly string Guid = "{732ada89-bff0-49d5-b4aa-b17b3b805fe1}";

        private static readonly string BuffName = $"{BaseName}CooldownBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddToFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{3e1cc446-3476-4f90-8d18-541f180ed83e}";
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{322740d9-192b-4338-b4fe-edc5451207b9}";
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{448b5882-850e-4a1e-89af-36bbf8069b5e}";
    }
}