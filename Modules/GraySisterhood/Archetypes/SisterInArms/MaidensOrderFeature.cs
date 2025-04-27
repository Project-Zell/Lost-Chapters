using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class MaidensOrderFeature
{
    public static readonly string Guid = "{b5195a32-9538-46d8-8943-b39fcfe87735}";

    private static readonly string FeatureName = "MaidensOrder";
    private static readonly string DisplayName = "MaidensOrder.Name";
    private static readonly string Description = "MaidensOrder.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
