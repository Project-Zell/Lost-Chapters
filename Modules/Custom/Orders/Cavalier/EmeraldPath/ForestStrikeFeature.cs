using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.EmeraldPath
{
    internal class ForestStrikeFeature
    {
        public static readonly string Guid = "{766dd237-1666-40af-8014-6e68b964d1a6}";

        private static readonly string FeatureName = "ForestStrike";
        private static readonly string DisplayName = "ForestStrike.Name";
        private static readonly string Description = "ForestStrike.Description";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddComponent<ForestStrike>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
