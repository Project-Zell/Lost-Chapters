using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

internal class CowledPilgrimArchetype
{
    public static readonly string Guid = "{1d962362-6495-4f75-be4d-19d450996c2e}";

    public static readonly string BaseName = "CowledPilgrim";

    private static readonly string ArchetypeName = $"{BaseName}Archetype";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description = $"{ArchetypeName}.Description";

    public static void Configure()
    {
        //Progression Feats
        CrossroadsAmbushFeature.Configure();
        EndlessStrideFeature.Configure();
        LoneWandererFeature.Configure();
        LostInSightFeature.Configure();
        NoRespiteFeature.Configure();
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
                .AddEntry(level: 01, features: LoneWandererFeature.Guid)
                .AddEntry(level: 03, features: CrossroadsAmbushFeature.Guid)
                .AddEntry(level: 04, features: LoneWandererFeature.FeatureSelection.Guid)
                .AddEntry(level: 05, features: NoRespiteFeature.Guid)
                .AddEntry(level: 07, features: LostInSightFeature.Guid)
                .AddEntry(level: 10, features: LoneWandererFeature.FeatureSelection.Guid)
                .AddEntry(level: 11, features: UnseenPathFeature.Guid)
                .AddEntry(level: 13, features: FeatureRefs.Camouflage.ToString())
                .AddEntry(level: 14, features: RoutekeeperFeature.Guid)
                .AddEntry(level: 16, features: LoneWandererFeature.FeatureSelection.Guid)
                .AddEntry(level: 20, features: EndlessStrideFeature.Guid);

        var classSkills = new StatType[]
{
            StatType.SkillPersuasion,
            StatType.SkillAthletics,
            StatType.SkillMobility,
            StatType.SkillStealth,
        };

        ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.CavalierClass)
            .SetReplaceClassSkills(true)
            .SetClassSkills(classSkills)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.CavalierProgression)
            .AddToUIGroups([
                LoneWandererFeature.Guid,
                LoneWandererFeature.FeatureSelection.Guid,
                FeatureRefs.Camouflage.ToString()])
            .Configure();
    }
}