using BlueprintCore.Blueprints.References;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class LawBlessedIncense
{
    private static readonly string BaseName = "LawBlessedIncense";
    private static readonly string Domain = FeatureRefs.LawDomainAllowed.ToString();

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
        public static readonly string Guid = "{ffa3bba7-c1c0-4c99-8f7d-e34e7e7aff60}";
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{bbb7e838-f4cf-4a64-a9bb-5c8b7b0143e1}";
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{8e0b4026-0fbe-4e1a-8a09-978beb6a57dd}";
    }
}
