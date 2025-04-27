using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Kingmaker.Blueprints.Classes.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.Selection
{
    internal class CapellanIncenseSelector
    {
        public static string Guid => FeatureSelectionSelectorGuid;

        private static readonly string FeatureSelection = "CapellanIncenseSelector";
        private static readonly string FeatureSelectionSelectorGuid = "519a7060-4fc0-40d9-a862-0b339cf1110e";

        private static readonly string FeatureSelectionDisplayName = "CapellanIncenseSelector.BuffName";
        private static readonly string FeatureSelectionDescription = "CapellanIncenseSelector.Description";

        public static BlueprintFeatureSelection Configure()
        {
            return FeatureSelectionConfigurator.New(FeatureSelection, FeatureSelectionSelectorGuid)
                .SetDisplayName(FeatureSelectionDisplayName)
                .SetDescription(FeatureSelectionDescription)
                .Configure();
        }
    }
}
