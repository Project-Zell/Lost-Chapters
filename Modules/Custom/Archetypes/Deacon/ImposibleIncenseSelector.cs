using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class ImposibleIncenseSelector
{
    public static readonly string Guid = "{3f9df65e-26b1-4fb4-b2df-770c360ef931}";

    public static readonly string BaseName = "ImposibleIncense";

    private static readonly string FeatureName = $"{BaseName}Selection";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();

        FeatureSelectionConfigurator.For(FeatureSelectionRefs.MythicAbilitySelection.ToString())
            .AddToAllFeatures(Guid)
            .Configure();
    }
}
