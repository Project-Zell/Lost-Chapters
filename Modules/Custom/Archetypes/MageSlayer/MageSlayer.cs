using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UI.MVVM._PCView.CharGen;
using Kingmaker.UI.MVVM._PCView.CharGen.Phases.Class;
using Kingmaker.UI.MVVM._PCView.ServiceWindows.CharacterInfo.Sections.Progression.Main;
using Kingmaker.UI.MVVM._VM.ServiceWindows.CharacterInfo.Sections.Progression.Main;
using LostChapters._logger;
using LostChapters.Modules.Custom.Archetypes.BlackKnight;

namespace LostChapters.Modules.Custom.Archetypes.MageSlayer;

internal class MageSlayer
{
    public static readonly string Guid = "{5c7fbe29-a872-49a4-9841-1f46a82e9517}";

    private static readonly string ArchetypeName = "MageSlayer";
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

        var e = ProgressionConfigurator.For(ProgressionRefs.SlayerProgression)
            .AddToUIGroups([JawStrikeFeature.Guid, JawStrikeUpgradeFeature.Guid])
            .Configure();



        var g = ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.SlayerClass)
            .SetClassSkills([StatType.SkillMobility, StatType.SkillPerception, StatType.SkillAthletics, StatType.SkillPersuasion, StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld, StatType.SkillStealth])
            .SetReplaceClassSkills(true)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();


        Logger.Message(typeof(MageSlayer), $"LevelEntries Lenght is {e.LevelEntries.Length}");

        for (int i = 0; i < e.LevelEntries.Length; i++)
        {
            var group = e.LevelEntries[i];

            if(group is not null)
            {
                var feature = FeatureConfigurator.For(group.m_Features[0].Guid).Configure();

                Logger.Message(typeof(MageSlayer), $"The UI Group of {feature?.name} has index of {i}");
            }

        }
    }
}
