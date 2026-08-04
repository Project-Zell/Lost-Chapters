using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

internal class NoRespiteFeature
{
    public static readonly string Guid = "{ffb2f064-4919-44f6-8c98-a55000658ecc}";

    private static readonly string BaseName = "NoRespite";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddArmorSpeedPenaltyRemoval()
            .AddComponent<NoRespite>()
            .SetIsClassFeature(true)
            .SetReapplyOnLevelUp(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
