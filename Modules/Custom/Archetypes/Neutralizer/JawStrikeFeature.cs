using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.Archetypes.Neutralizer;

internal class JawStrikeFeature
{
    public static readonly string Guid = "{ba276bd1-a28b-406a-94b9-6fd483624f77}";

    private static readonly string BaseName = "JawStrike";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        JawStrikeAbility.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([JawStrikeAbility.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
