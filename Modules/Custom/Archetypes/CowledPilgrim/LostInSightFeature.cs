using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

internal class LostInSightFeature
{
    public static readonly string Guid = "{d7b525f7-3029-4eab-b412-596290003b24}";
    
    private static readonly string BaseName = "LostInSight";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/{CowledPilgrimArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFullSpeedInStealth()
            .AddComponent<LostInSight>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
