using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Archetypes.MageSlayer;

internal class MageSlayerArchetype
{
    public static readonly string Guid = "{5c7fbe29-a872-49a4-9841-1f46a82e9517}";

    private static readonly string ArchetypeName = "MageSlayerArchetype";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    internal static void Configure()
    {
        //Check mage slayer item

        //3: Jaw strike - swift action unarmed attack that mute the target for 1d3 turns
        //8: Jaw strike can be use as a bonus action
        //5: ??? - can select dispeling strike and slippery mind ignoring prerequisites, also can select evasion
        //1-5-10-15-20: ??? - study target alteration, 1 to attack and damage and get a +1 to saving throws against target spells
        //13: - magic damage reduction

        MindShatterFeature.Configure();
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
            .AddEntry(level: 20, features: FeatureRefs.SlayerStudyTargetFeature.ToString())
            .AddEntry(level: 20, features: FeatureRefs.MasterSlayerFeature.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: MindShatterFeature.Guid)
            .AddEntry(level: 03, features: JawStrikeFeature.Guid)
            .AddEntry(level: 05, features: MindShatterFeature.Guid)
            .AddEntry(level: 06, features: NeutralizerFeature.Guid)
            .AddEntry(level: 07, features: JawStrikeUpgradeFeature.Guid)
            .AddEntry(level: 10, features: MindShatterFeature.Guid)
            //.AddEntry(level: 12, features: MindShatterFeature.Guid)
            .AddEntry(level: 15, features: MindShatterFeature.Guid)
            .AddEntry(level: 20, features: MindShatterFeature.Guid)
            ;

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
