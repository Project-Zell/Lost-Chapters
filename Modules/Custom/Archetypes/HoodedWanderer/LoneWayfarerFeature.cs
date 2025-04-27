using Kingmaker.Blueprints.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.GraySisterhood;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class LoneWayfarerFeature
{
    public static readonly string Guid = "{3cc07ae6-d3c5-40c6-a159-d2ff3e960069}";

    private static readonly string FeatureName = "LoneWayfarer";
    private static readonly string DisplayName = "LoneWayfarer.Name";
    private static readonly string Description = "LoneWayfarer.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/lonewanderer.png";

    internal static void Configure()
    {
        FeatureSelection.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<LoneWayfarer>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class FeatureSelection
    {
        public static readonly string Guid = "{0cd48cf4-b99a-4b50-8b4f-fc6eef9c5545}";

        private static readonly string FeatureName = "HoodedWanderer.TerrainMastery";
        private static readonly string DisplayName = "HoodedWanderer.TerrainMastery.Name";
        private static readonly string Description = "HoodedWanderer.TerrainMastery.Description";

        internal static void Configure()
        {
            var icon = FeatureSelectionRefs.TerrainMastery.Reference.Get().Icon;

            FeatureSelectionConfigurator.New(FeatureName, Guid)
                .SetAllFeatures([
                    FeatureRefs.FavoriteTerrainAbyss.ToString(),
                    FeatureRefs.FavoriteTerrainDesert.ToString(),
                    FeatureRefs.FavoriteTerrainForest.ToString(),
                    FeatureRefs.FavoriteTerrainHighlands.ToString(),
                    FeatureRefs.FavoriteTerrainUnderground.ToString(),
                    FeatureRefs.FavoriteTerrainUrban.ToString()])
                .SetMode(SelectionMode.OnlyNew)
                .SetReapplyOnLevelUp(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(icon)
                .Configure();
        }
    }
}
