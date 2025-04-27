using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Bastion;

internal class BarricadeFeature
{
    public static readonly string Guid = "{fe60928f-7dbd-4c88-b6fa-daf5ccdac3eb}";

    private static readonly string FeatureName = "Barricade";
    private static readonly string DisplayName = "Barricade.Name";
    private static readonly string Description = "Barricade.Description";

    internal static void Configure()
    {
        Rank.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.FavoriteTerrainUrban.ToString()])
            .AddComponent<Barricade>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Rank
    {
        public static readonly string Guid = "{72fe7f27-20c7-406e-add5-5ebd4dc40727}";

        private static readonly string FeatureName = "Barricade.Rank";
        private static readonly string DisplayName = "Barricade.Rank.Name";
        private static readonly string Description = "Barricade.Rank.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetIsClassFeature(true)
                .SetRanks(4)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
