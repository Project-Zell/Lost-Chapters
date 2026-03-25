using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class TyrantsDisciplineFeatureSelection
    {
        public static readonly string Guid = "{dde2f61c-456b-481a-91ce-026bda18edc4}";

        private static readonly string FeatureName = "TyrantsDiscipline";
        private static readonly string DisplayName = "TyrantsDiscipline.Name";
        private static readonly string Description = "TyrantsDiscipline.Description";

        internal static void Configure()
        {
            DevilDanceFeatureSelection.Configure();
            ErinyesFuryFeature.Configure();
            FuriousHuntressFeature.Configure();
            KinslayerFeature.Configure();
            MercilessMassacreFeature.Configure();
            UnyieldingFeature.Configure();

            FeatureSelectionConfigurator.New(FeatureName, Guid)
                .AddToAllFeatures(
                    DevilDanceFeatureSelection.Guid,
                    ErinyesFuryFeature.Guid,
                    FuriousHuntressFeature.Guid,
                    KinslayerFeature.Guid,
                    MercilessMassacreFeature.Guid,
                    UnyieldingFeature.Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}