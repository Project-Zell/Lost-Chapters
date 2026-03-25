using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class KinslayerFeature
    {
        public static readonly string Guid = "{dc88b418-7978-47a4-a29e-9f507aeb138e}";

        private static readonly string FeatureName = "Kinslayer";
        private static readonly string DisplayName = "Kinslayer.Name";
        private static readonly string Description = "Kinslayer.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([
                    FeatureRefs.FavoriteEnemyDwarfs.ToString(),
                    FeatureRefs.FavoriteEnemyElfs.ToString(),
                    FeatureRefs.FavoriteEnemyGnome.ToString(),
                    FeatureRefs.FavoriteEnemyGoblins.ToString(),
                    FeatureRefs.FavoriteEnemyHalfling.ToString(),
                    FeatureRefs.FavoriteEnemyHuman.ToString()])
                .SetReapplyOnLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}