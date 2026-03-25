using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class NoRespiteFeature
{
    public static readonly string Guid = "{ffb2f064-4919-44f6-8c98-a55000658ecc}";

    private static readonly string FeatureName = "NoRespite";
    private static readonly string DisplayName = "NoRespite.Name";
    private static readonly string Description = "NoRespite.Description";

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
