using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon;

internal class ImpossibleIncenseSelector
{
    public static readonly string Guid = "{3f9df65e-26b1-4fb4-b2df-770c360ef931}";

    public static readonly string BaseName = "ImpossibleIncense";
    
    private static readonly string FeatureName = $"{BaseName}Selection";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    
    internal static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        MythicHelper.AddFeatureToMythicAbilities(guid: Guid);
    }
}