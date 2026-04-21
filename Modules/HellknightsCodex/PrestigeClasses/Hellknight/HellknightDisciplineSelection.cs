using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;
using LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

internal class HellknightDisciplineSelection
{
    public static readonly string Guid = "{23ed25af-b68b-41e0-aca3-6a724368e00e}";

    private static readonly string FeatureName = "HellknightDisciplineSelection";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    public static void Configure()
    {
        //Get two claw attacks while wearing heavy armor

        HellknightObidienceFeature.Configure();
        HellknightZealFeature.Configure();

        SeekingJusticeFeature.Configure();

        BrutalityFeature.Configure();
        HatredFeature.Configure();
        ObsessionFeature.Configure();
        HellknightMalevolenceFeature.Configure();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddToAllFeatures([
                HellknightObidienceFeature.Guid,
                HellknightZealFeature.Guid,

                SeekingJusticeFeature.Guid,
                HellknightMalevolenceFeature.Guid,

                BrutalityFeature.Guid,
                HatredFeature.Guid,
                ObsessionFeature.Guid,
                ])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
