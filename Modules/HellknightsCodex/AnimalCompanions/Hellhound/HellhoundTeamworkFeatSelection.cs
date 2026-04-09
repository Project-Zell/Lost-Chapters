using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.HellknightCodex.AnimalCompanions.Hellhound;
internal class HellhoundTeamworkFeatSelection
{
    public static readonly string Guid = "{0178ecae-e6e7-433b-a187-791434abe749}";

    private static readonly string FeatureName = "HellhoundTeamworkSelection";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddToAllFeatures(
                FeatureRefs.AlliedSpellcaster.ToString(),
                FeatureRefs.BackToBack.ToString(),
                FeatureRefs.CoordinatedDefense.ToString(),
                FeatureRefs.CoordinatedManeuvers.ToString(),
                FeatureRefs.Outflank.ToString(),
                FeatureRefs.PreciseStrike.ToString(),
                FeatureRefs.ShakeItOff.ToString(),
                FeatureRefs.ShieldedCaster.ToString(),
                FeatureRefs.ShieldWall.ToString(),
                FeatureRefs.SiezeTheMoment.ToString(),
                FeatureRefs.TandemTrip.ToString(),
                FeatureRefs.VolleyFireFeature.ToString())
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
