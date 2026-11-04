using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight;

internal class FalseKnightArchetype
{
    public static readonly string Guid = "{a6b94a55-60d2-42f8-ba5c-4e105bc3fa48}";

    public static readonly string BaseName = "FalseKnight";

    private static readonly string ArchetypeName = $"{BaseName}Archetype";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";
        
    internal static void Configure()
    {
        VersatileTacticsFeature.Configure();
        ForgottenInsigniaFeature.Configure();
        ForbiddenInsigniaFeature.Configure();
        FallenOrderProgression.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierMountSelection.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierOrderSelection.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 01, features: FeatureRefs.CavalierTacticianFeature.ToString())
            .AddEntry(level: 05, features: FeatureRefs.CavalierBanner.ToString())
            .AddEntry(level: 09, features: FeatureRefs.CavalierTacticianGreater.ToString())
            .AddEntry(level: 09, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 14, features: FeatureRefs.CavalierBannerGreater.ToString())
            .AddEntry(level: 17, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FallenOrderProgression.Guid)
            .AddEntry(level: 01, features: ForgottenInsigniaFeature.Guid)
            .AddEntry(level: 01, features: VersatileTacticsFeature.Guid)
            .AddEntry(level: 01, features: VersatileTacticsFeature.FeatureSelection.Guid)
            .AddEntry(level: 05, features: FeatureSelectionRefs.CavalierMountSelection.ToString())
            .AddEntry(level: 05, features: VersatileTacticsFeature.FeatureSelection.Guid)
            .AddEntry(level: 10, features: VersatileTacticsFeature.FeatureSelection.Guid)
            .AddEntry(level: 14, features: ForbiddenInsigniaFeature.Guid)
            .AddEntry(level: 15, features: VersatileTacticsFeature.FeatureSelection.Guid)
            .AddEntry(level: 20, features: VersatileTacticsFeature.FeatureSelection.Guid);

        ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.CavalierClass)
            .SetClassSkills([StatType.SkillPersuasion, StatType.SkillAthletics, StatType.SkillMobility, StatType.SkillStealth])
            .SetReplaceClassSkills(true)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.CavalierProgression)
            .AddToUIDeterminatorsGroup([FallenOrderProgression.Guid])
            .Configure();
    }
}
