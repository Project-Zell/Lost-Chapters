using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class BlackrotFeature
{
    public static readonly string Guid = "{aede104c-f1f8-444e-9add-aab3c4f10a91}";

    private static readonly string FeatureName = "Blackrot";
    private static readonly string DisplayName = "Blackrot.Name";
    private static readonly string Description = "Blackrot.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/blackrot.png";
    public static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetRanks(5)
            .SetIcon(Icon)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}