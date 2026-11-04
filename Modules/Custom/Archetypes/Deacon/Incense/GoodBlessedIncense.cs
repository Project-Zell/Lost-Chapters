using BlueprintCore.Blueprints.References;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class GoodBlessedIncense
{
    private static readonly string BaseName = "GoodBlessedIncense";
    private static readonly string Domain = FeatureRefs.GoodDomainAllowed.ToString();

    internal static void Configure()
    {
        DeaconInsenceHelper.CreateInsence(
            baseName: BaseName,
            domainGuid: Domain,
            minorFeatureGuid: MinorFeature.Guid,
            majorFeatureGuid: MajorFeature.Guid,
            extraIncenceGuid: ExtraIncenseProgression.Guid,
            minorBuffs: [],
            majorBuffs: []);
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{6c1da305-f74f-4c03-8c1d-0d2fb2a10883}";
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{bb69dbdb-100c-4e02-bb31-2c8dd7bc73c3}";
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{0a236a3a-68e0-4d9a-a50e-50c711ca8483}";
    }
}
