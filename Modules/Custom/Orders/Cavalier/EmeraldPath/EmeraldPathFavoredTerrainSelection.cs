using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes;

namespace LostChapters.Modules.Custom.Orders.Cavalier.EmeraldPath
{
    internal class EmeraldPathFavoredTerrainSelection
    {
        public static readonly string Guid = "{96590488-014d-4172-aba0-b90f6a523934}";

        private static readonly string FeatureName = "EmeraldPathFavoredTerrain";
        private static readonly string DisplayName = "EmeraldPathFavoredTerrain.Name";
        private static readonly string Description = "EmeraldPathFavoredTerrain.Description";

        internal static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureName, Guid, FeatureGroup.FavoriteTerrain)
                .SetMode(SelectionMode.OnlyNew)
                .AddToAllFeatures([
                    FeatureRefs.FavoriteTerrainAbyss.ToString(),
                    FeatureRefs.FavoriteTerrainDesert.ToString(),
                    FeatureRefs.FavoriteTerrainForest.ToString(),
                    FeatureRefs.FavoriteTerrainHighlands.ToString(),
                    FeatureRefs.FavoriteTerrainUnderground.ToString(),
                    FeatureRefs.FavoriteTerrainUrban.ToString()])
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
