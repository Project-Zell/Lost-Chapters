using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.GraySisterhood.Feats.Selection
{
    internal class HellknightDisciplineSelection
    {
        public static string Guid => FeatureSelectionGuid;

        private static readonly string FeatureSelection = "HellknightDiscipline";
        private static readonly string FeatureSelectionGuid = "98675166-8857-41d9-82c2-b69557c5976e";

        private static readonly string FeatureSelectionDisplayName = "HellknightDiscipline.Name";
        private static readonly string FeatureSelectionDescription = "HellknightDiscipline.Description";

        public static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureSelection, FeatureSelectionGuid)
                .AddToAllFeatures([
                    FeatureRefs.IronWill.ToString(),
                    FeatureRefs.IronWillImproved.ToString(),
                    FeatureRefs.GreatFortitude.ToString(),
                    FeatureRefs.GreatFortitudeImproved.ToString(),
                    FeatureRefs.LightningReflexes.ToString(),
                    FeatureRefs.LightningReflexesImproved.ToString()])
                .SetDisplayName(FeatureSelectionDisplayName)
                .SetDescription(FeatureSelectionDescription)
                .Configure();
        }
    }
}
