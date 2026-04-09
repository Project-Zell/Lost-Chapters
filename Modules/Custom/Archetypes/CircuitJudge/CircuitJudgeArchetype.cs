using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Root;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UI.MVVM._PCView.Tooltip.Bricks;
using Kingmaker.UnitLogic.FactLogic;
using LostChapters.Modules.Custom.Archetypes.BlackKnight;
using System.Linq;

namespace LostChapters.Modules.Custom.Archetypes.CircuitJudge;

internal class CircuitJudgeArchetype
{
    public static readonly string Guid = "{4052bfa3-3f1b-4aa5-8f96-6784704ae3ac}";

    private static readonly string ArchetypeName = "CircuitJudge";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description = $"{ArchetypeName}.Description";

    private static readonly BlueprintCharacterClass Class = CharacterClassRefs.CavalierClass.Reference;

    internal static void Configure()
    {
        CircuitFeature.Configure();
        ConvictionFeature.Configure();

        //Conviction: A circuit judge can choose one target with a chaotic alignment within sight to sentence as a swift action. The circuit judge's melee attacks deal extra damage whenever they are made against the target of his sentence. This extra damage is equal to the cavalier's level.
        //Sentence also includes another effect which is listed in the section describing the cavalier's order.This ability replaces challenge.
        //Judgment: At 1st level, and every three levels thereafter, a circuit judge gain judgment as a bonus ability.
        //Circuit: A circuit judge adds half his cavalier level (minimum 1) on Intimidate and Knowledge(World).
        //Verdict: Upon using sentence against a chaotic enemy, a circuit judge may make a Persuasion (to intimidate) check as a free action to demoralize the sentenced foe.

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureRefs.CavalierChallengeFeature.ToString())
            .AddEntry(level: 01, features: FeatureRefs.CavalierTacticianFeature.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 09, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString())
            .AddEntry(level: 09, features: FeatureRefs.CavalierTacticianGreater.ToString())
            .AddEntry(level: 12, features: FeatureRefs.CavalierDemandingChallenge.ToString())
            .AddEntry(level: 17, features: FeatureSelectionRefs.CavalierTacticianFeatSelection.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: ConvictionFeature.Guid)
            .AddEntry(level: 01, features: CircuitFeature.Guid)
            .AddEntry(level: 01, features: FeatureRefs.JudgmentFeature.ToString())
            .AddEntry(level: 04, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 07, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 08, features: FeatureRefs.SecondJudgment.ToString())
            .AddEntry(level: 10, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 13, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 16, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddEntry(level: 16, features: FeatureRefs.ThirdJudgment.ToString())
            .AddEntry(level: 19, features: FeatureRefs.JudgmentAdditionalUse.ToString());

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
            .AddToAddFeatures()
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
