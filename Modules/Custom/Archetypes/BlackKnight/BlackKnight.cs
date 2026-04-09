using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class BlackKnight
{
    //Thorns
    //Flail

    public static readonly string Guid = "{a6b94a55-60d2-42f8-ba5c-4e105bc3fa48}";

    private static readonly string ArchetypeName = "BlackKnight";
    private static readonly string LocalizedName = "BlackKnight.Name";
    private static readonly string Description   = "BlackKnight.Description";

    public static void Configure()
    {
        BlackKnightTeamworkFeatSelection.Configure();
        ForgottenInsigniaFeature.Configure();
        ForbiddenInsigniaFeature.Configure();
        FallenOrderFeature.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierMountSelection.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierOrderSelection.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 01, features: FeatureRefs.CavalierTacticianFeature.ToString())
            .AddEntry(level: 03, features: FeatureRefs.CavalierCharge.ToString())
            .AddEntry(level: 05, features: FeatureRefs.CavalierBanner.ToString())
            .AddEntry(level: 09, features: FeatureRefs.CavalierTacticianGreater.ToString())
            .AddEntry(level: 09, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 14, features: FeatureRefs.CavalierBannerGreater.ToString())
            .AddEntry(level: 17, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FallenOrderFeature.Guid)
            .AddEntry(level: 01, features: ForgottenInsigniaFeature.Guid)
            .AddEntry(level: 01, features: BlackKnightTeamworkFeatSelection.Guid)
            .AddEntry(level: 03, features: FeatureRefs.SoloTactics.ToString())
            .AddEntry(level: 05, features: FeatureRefs.CavalierCharge.ToString())
            .AddEntry(level: 05, features: FeatureSelectionRefs.CavalierMountSelection.ToString())
            .AddEntry(level: 07, features: BlackKnightTeamworkFeatSelection.Guid)
            .AddEntry(level: 13, features: BlackKnightTeamworkFeatSelection.Guid)
            .AddEntry(level: 14, features: ForbiddenInsigniaFeature.Guid)
            .AddEntry(level: 19, features: BlackKnightTeamworkFeatSelection.Guid);

        ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.CavalierClass)
            .SetClassSkills([StatType.SkillPersuasion, StatType.SkillAthletics, StatType.SkillMobility, StatType.SkillStealth])
            .SetReplaceClassSkills(true)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.CavalierProgression)
            .AddToUIGroups([BlackKnightTeamworkFeatSelection.Guid])
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.CavalierProgression)
            .AddToUIDeterminatorsGroup([FallenOrderFeature.Guid])
            .Configure();
    }
}
