using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Neutralizer;

internal class NeutralizerFeature
{
    public static readonly string Guid = "{39992856-cfb3-4443-b6d8-e9cc046fdcf0}";

    private static readonly string BaseName = "Neutralizer";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid) 
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .AddToIsPrerequisiteFor([FeatureRefs.DispellingAttack.ToString(), FeatureRefs.SlipperyMind.ToString()])
            //.SetIcon(Icon)
            .Configure();

        Toolbox.AddPrerequisiteToList(featureListGuid: FeatureRefs.DispellingAttack.ToString(), featureToAddGuid: Guid);

        var slipperyMind = FeatureRefs.SlipperyMind.ToString();
        Toolbox.ModifyFromPrerequisiteToList(featureGuid: slipperyMind);
        Toolbox.AddPrerequisiteToList(featureListGuid: slipperyMind, featureToAddGuid: Guid);
    }
}
