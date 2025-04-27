using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Fishbone
{
    internal class BoneChokeFeature
    {
        public static readonly string Guid = "{57e4c78e-580b-4609-abc8-562b8b3ade51}";

        private static readonly string FeatureName = "BoneChoke";
        private static readonly string DisplayName = "BoneChoke.Name";
        private static readonly string Description = "BoneChoke.Description";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([FeatureRefs.SlowReactions.ToString()])
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
