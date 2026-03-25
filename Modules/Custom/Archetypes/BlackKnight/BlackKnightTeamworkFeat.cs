using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class BlackKnightTeamworkFeat
{
    public static readonly string Guid = "{71731a4d-e8d6-46fa-a815-93490a6be18f}";

    private static readonly string FeatureName = "BlackKnightTeamworkFeat";
    private static readonly string DisplayName = "BlackKnightTeamworkFeat.Name";
    private static readonly string Description = "BlackKnightTeamworkFeat.Description";

    public static void Configure()
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