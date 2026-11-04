using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Archetypes.Neutralizer;

internal class NeutralizerArchetype
{
    public static readonly string Guid = "{5c7fbe29-a872-49a4-9841-1f46a82e9517}";

    private static readonly string BaseName = "Neutralizer";

    private static readonly string ArchetypeName = $"{BaseName}Archetype";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    internal static void Configure()
    {
        //Lvl13 - Mage Res?

        CautiosStudyFeature.Configure();
        NeutralizerFeature.Configure();
        JawStrikeFeature.Configure();
        JawStrikeUpgradeFeature.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureRefs.SlayerStudyTargetFeature.ToString())
            .AddEntry(level: 05, features: FeatureRefs.SlayerStudyTargetFeature.ToString())
            .AddEntry(level: 07, features: FeatureRefs.SlayerSwiftStudyTargetFeature.ToString())
            .AddEntry(level: 10, features: FeatureRefs.SlayerStudyTargetFeature.ToString())
            .AddEntry(level: 14, features: FeatureRefs.Quarry.ToString())
            .AddEntry(level: 15, features: FeatureRefs.SlayerStudyTargetFeature.ToString())
            .AddEntry(level: 19, features: FeatureRefs.ImprovedQuarry.ToString())
            .AddEntry(level: 20, features: FeatureRefs.SlayerStudyTargetFeature.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: CautiosStudyFeature.Guid)
            .AddEntry(level: 03, features: JawStrikeFeature.Guid)
            .AddEntry(level: 05, features: CautiosStudyFeature.Guid)
            .AddEntry(level: 06, features: NeutralizerFeature.Guid)
            .AddEntry(level: 07, features: JawStrikeUpgradeFeature.Guid)
            .AddEntry(level: 10, features: CautiosStudyFeature.Guid)
            .AddEntry(level: 15, features: CautiosStudyFeature.Guid)
            .AddEntry(level: 20, features: CautiosStudyFeature.Guid);

        ProgressionConfigurator.For(ProgressionRefs.SlayerProgression)
            .AddToUIGroups([JawStrikeFeature.Guid, JawStrikeUpgradeFeature.Guid])
            .Configure();

        ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.SlayerClass)
            .SetClassSkills([StatType.SkillMobility, StatType.SkillPerception, StatType.SkillAthletics, StatType.SkillPersuasion, StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld, StatType.SkillStealth])
            .SetReplaceClassSkills(true)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();
    }
}
