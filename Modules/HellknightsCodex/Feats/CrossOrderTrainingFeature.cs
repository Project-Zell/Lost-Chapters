using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightsCodex.Feats;

internal class CrossOrderTrainingFeature
{
    public static readonly string Guid = "{c57ae2ab-bc86-458b-b0a0-b566621fa787}";

    private static readonly string FeatureName = "CrossOrderTrainingFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureSelectionConfigurator.New(FeatureName, Guid, FeatureGroup.Feat)
            .AddPrerequisiteFeature(HellknightOrderSelectionFeature.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();

        FeatureSelectionConfigurator.For(FeatureSelectionRefs.BasicFeatSelection.ToString())
            .AddToAllFeatures(Guid)
            .Configure();
    }
}
