using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class HoodedWandererArchetype
{
    public static readonly string Guid = "{1d962362-6495-4f75-be4d-19d450996c2e}";

    private static readonly string ArchetypeName = "HoodedWanderer";
    private static readonly string LocalizedName = "HoodedWanderer.Name";
    private static readonly string Description = "HoodedWanderer.Description";

    public static void Configure()
    {
        CrossroadsAmbushFeature.Configure();
        EndlessStrideFeature.Configure();
        NoRespiteFeature.Configure();
        OneWithTheRoadFeature.Configure();
        LostInSightFeature.Configure();
        LoneWayfarerFeature.Configure();
        RoutekeeperFeature.Configure();
        UnseenPathFeature.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
                .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierMountSelection.ToString())
                .AddEntry(level: 03, features: FeatureRefs.CavalierCharge.ToString())
                .AddEntry(level: 05, features: FeatureRefs.CavalierBanner.ToString())
                .AddEntry(level: 11, features: FeatureRefs.CavalierMightyCharge.ToString())
                .AddEntry(level: 14, features: FeatureRefs.CavalierBannerGreater.ToString())
                .AddEntry(level: 20, features: FeatureRefs.CavalierSupremeCharge.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
                .AddEntry(level: 01, features: LoneWayfarerFeature.Guid)
                .AddEntry(level: 03, features: CrossroadsAmbushFeature.Guid)
                .AddEntry(level: 04, features: LoneWayfarerFeature.FeatureSelection.Guid)
                .AddEntry(level: 05, features: NoRespiteFeature.Guid)
                .AddEntry(level: 07, features: OneWithTheRoadFeature.Guid)
                .AddEntry(level: 10, features: LoneWayfarerFeature.FeatureSelection.Guid)
                .AddEntry(level: 11, features: UnseenPathFeature.Guid)
                .AddEntry(level: 13, features: LostInSightFeature.Guid)
                .AddEntry(level: 14, features: RoutekeeperFeature.Guid)
                .AddEntry(level: 16, features: LoneWayfarerFeature.FeatureSelection.Guid)
                .AddEntry(level: 20, features: EndlessStrideFeature.Guid);

        ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.CavalierClass)
            .SetClassSkills([StatType.SkillPersuasion, StatType.SkillAthletics, StatType.SkillMobility, StatType.SkillStealth])
            .SetReplaceClassSkills(true)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.CavalierProgression)
            .AddToUIGroups(new Blueprint<BlueprintFeatureBaseReference>[] {
                                LoneWayfarerFeature.Guid,
                                LoneWayfarerFeature.FeatureSelection.Guid,
                                OneWithTheRoadFeature.Guid,
                                LostInSightFeature.Guid})
            .Configure();
    }
}
