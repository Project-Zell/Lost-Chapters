using BlueprintCore.Blueprints.References;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class ChaosBlessedIncense
{
    private static readonly string BaseName = "ChaosBlessedIncense";
    private static readonly string Domain = FeatureRefs.ChaosDomainAllowed.ToString();

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
        public static readonly string Guid = "{e33beb8b-3854-4d29-957c-1be491279f16}";
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{b5fb86a1-e239-4f4c-824b-ce4fd17aa105}";
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{11ae643f-2117-404c-965d-c208738df4b4}";
    }
}