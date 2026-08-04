using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Selection;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

internal class LoneWandererFeature
{
    public static readonly string Guid = "{3cc07ae6-d3c5-40c6-a159-d2ff3e960069}";

    private static readonly string BaseName = "LoneWanderer";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/{CowledPilgrimArchetype.BaseName}/{BaseName}.png".ToLower();

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

        private static readonly string SelectionName = $"{BaseName}FeatureSelection";
        private static readonly string DisplayName = $"{SelectionName}.Name";

        internal static void Configure()
        {
            var icon = FeatureSelectionRefs.TerrainMastery.Reference.Get().Icon;

            FeatureSelectionConfigurator.New(SelectionName, Guid)
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