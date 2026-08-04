using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.Custom.Components;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

internal class RoutekeeperFeature
{
    public static readonly string Guid = "{33c6facd-c835-4fca-832f-986e7ee13893}";

    private static readonly string BaseName = "Routekeeper";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly Sprite Icon = BuffRefs.LongstriderBuff.Reference.Get().Icon;

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<Routekeeper>()
            .SetReapplyOnLevelUp(true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
