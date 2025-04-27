using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon
{
    internal class AidAlliesFeature
    {
        public static readonly string Guid = "{b7b61a5b-002a-4070-9580-20589a045401}";

        private static readonly string FeatureName = "AidAllies";
        private static readonly string DisplayName = "AidAllies.Name";
        private static readonly string Description = "AidAllies.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetRanks(4)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
