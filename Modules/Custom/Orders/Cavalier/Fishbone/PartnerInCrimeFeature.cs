using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Fishbone
{
    internal class PartnerInCrimeFeature
    {
        public static readonly string Guid = "{c826a5f4-be03-4287-9c2f-fd6304c9dd64}";

        private static readonly string FeatureName = "PartnerInCrime";
        private static readonly string DisplayName = "PartnerInCrime.Name";
        private static readonly string Description = "PartnerInCrime.Description";

        internal static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureName, Guid, FeatureGroup.Familiar)
                .AddToAllFeatures([
                    FeatureRefs.CatFamiliarBondFeature.ToString(),
                    FeatureRefs.CentipedeFamiliarBondFeature.ToString(),
                    FeatureRefs.ChickenFamiliarBondFeature.ToString(),
                    FeatureRefs.DogFamiliarBondFeature.ToString(),
                    FeatureRefs.DuckFamiliarBondFeature.ToString(),
                    FeatureRefs.HareFamiliarBondFeature.ToString(),
                    FeatureRefs.JerboaFamiliarBondFeature.ToString(),
                    FeatureRefs.LizardFamiliarBondFeature.ToString(),
                    FeatureRefs.MonkeyFamiliarBondFeature.ToString(),
                    FeatureRefs.RabbitFamiliarBondFeature.ToString(),
                    FeatureRefs.RatFamiliarBondFeature.ToString(),
                    FeatureRefs.TarantulaFamiliarBondFeature.ToString(),
                    FeatureRefs.ViperFamiliarBondFeature.ToString(),
                    FeatureRefs.RavenFamiliarBondFeature.ToString()])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
