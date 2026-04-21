using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class UnyieldingDevotionFeature
{
    public static readonly string Guid = "{87693bd2-0891-4f44-a298-e78bb29b4231}";

    private static readonly string FeatureName = "UnyieldingDevotionFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        //Black Knight calls to his fallen order brothers spirits. One time per day, he can summon 3 ghost knights for 10 minutes.
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
