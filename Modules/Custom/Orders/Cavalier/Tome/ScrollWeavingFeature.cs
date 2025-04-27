using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Tome
{
    internal class ScrollWeavingFeature
    {
        public static readonly string Guid = "{310948c9-a22f-4095-bc7f-b58880b72ccf}";

        private static readonly string FeatureName = "ScrollWeaving";
        private static readonly string DisplayName = "ScrollWeaving.Name";
        private static readonly string Description = "ScrollWeaving.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddComponent<ScrollWeaving>()
                .SetReapplyOnLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
