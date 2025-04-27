using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.Shield
{
    internal class ResoluteFeature
    {
        public static readonly string Guid = "{deeffe2e-06d3-446e-88dc-f4b4e01a9c64}";

        private static readonly string FeatureName = "Resolute";
        private static readonly string DisplayName = "Resolute.Name";
        private static readonly string Description = "Resolute.Description";

        public static void Configure()
        {
            Rank.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Rank.Guid])
                .AddFactsToPet(facts: [Rank.Guid], allPets: true)
                .SetRanks(5)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Rank
        {
            public static readonly string Guid = "{0103de96-db46-4426-859e-88410bf22300}";

            private static readonly string FeatureName = "Resolute.Rank";

            public static void Configure()
            {
                var value = ContextValues.Rank();
                var rank = ContextRankConfigs.FeatureRank(Guid, min: 1, max: 5);

                FeatureConfigurator.New(FeatureName, Guid)
                    .AddContextRankConfig(rank)
                    .AddDamageResistancePhysical(material: PhysicalDamageMaterial.Adamantite, value: value, minEnhancementBonus: 1)
                    .SetRanks(5)
                    .SetIsClassFeature(true)
                    .Configure();
            }
        }
    }
}
