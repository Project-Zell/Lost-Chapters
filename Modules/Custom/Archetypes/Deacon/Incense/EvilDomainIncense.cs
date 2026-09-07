using BlueprintCore.Blueprints.References;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class EvilDomainIncense
{
    private static readonly string BaseName = "SinisterGrasp";
    private static readonly string Domain = FeatureRefs.EvilDomainAllowed.ToString();

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
        public static readonly string Guid = "{b75e50e2-4169-4431-8add-afb6ff3ad462}";
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{0c6f476a-d56a-40dc-adfc-f86817e24470}";
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{70f27417-1b87-4918-a73e-be8056428e07}";
    }
}