using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Tools;

internal static class MythicHelper
{
    internal static void AddFeatureToMythicAbilities(string guid)
    {
        FeatureSelectionConfigurator.For(FeatureSelectionRefs.MythicAbilitySelection.ToString())
            .AddToAllFeatures(guid)
            .Configure();

        FeatureSelectionConfigurator.For(FeatureSelectionRefs.ExtraMythicAbilityMythicFeat.ToString())
            .AddToAllFeatures(guid)
            .Configure();
    }
}