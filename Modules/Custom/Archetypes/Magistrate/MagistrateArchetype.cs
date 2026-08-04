using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.Archetypes.Magistrate;

internal class MagistrateArchetype
{
    public static readonly string Guid = "{4052bfa3-3f1b-4aa5-8f96-6784704ae3ac}";

    private static readonly string ArchetypeName = "Magistrate";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description = $"{ArchetypeName}.Description";

    private static readonly BlueprintCharacterClass Class = CharacterClassRefs.CavalierClass.Reference;

    internal static void Configure()
    {
        CodeOfLawsFeature.Configure();
        CourtTrialFeature.Configure();
        CollectiveGuiltFeature.Configure();
        ReprimandFeature.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureRefs.CavalierChallengeFeature.ToString())
            .AddEntry(level: 01, features: FeatureRefs.CavalierTacticianFeature.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 09, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 09, features: FeatureRefs.CavalierTacticianGreater.ToString())
            .AddEntry(level: 12, features: FeatureRefs.CavalierDemandingChallenge.ToString())
            .AddEntry(level: 17, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 20, features: FeatureRefs.CavalierSupremeCharge.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: CourtTrialFeature.Guid)
            .AddEntry(level: 01, features: CodeOfLawsFeature.Guid)
            .AddEntry(level: 01, features: FeatureRefs.JudgmentFeature.ToString())
            .AddEntry(level: 04, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 07, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 08, features: FeatureRefs.SecondJudgment.ToString())
            .AddEntry(level: 10, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 12, features: ReprimandFeature.Guid)
            .AddEntry(level: 13, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 16, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 16, features: FeatureRefs.ThirdJudgment.ToString())
            .AddEntry(level: 19, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 20, features: CollectiveGuiltFeature.Guid);

        var classSkills = new StatType[]
        {
            StatType.SkillPersuasion,
            StatType.SkillAthletics,
            StatType.SkillMobility,
            StatType.SkillKnowledgeWorld,
        };

        ArchetypeConfigurator.New(ArchetypeName, Guid, Class)
            .SetReplaceClassSkills(true)
            .SetClassSkills(classSkills)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.CavalierProgression)
            .AddToUIGroups([FeatureRefs.JudgmentFeature.ToString(), FeatureRefs.JudgmentAdditionalUse.ToString()])
            .Configure();
    }
}
