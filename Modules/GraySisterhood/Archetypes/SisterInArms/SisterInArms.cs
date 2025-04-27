using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class SisterInArms
{
    public static readonly string Guid = "{ddf04e6d-a66d-41e1-937d-3d94a10d1b96}";

    private static readonly string ArchetypeName = "SisterInArms";
    private static readonly string LocalizedName = "SisterInArms.Name";
    private static readonly string Description   = "SisterInArms.Description";

    internal static void Configure()
    {
        DedicatedCommanderFeature.Configure();
        DevotedDefenderFeature.Configure();
        HalfheartedChallengeFeature.Configure();
        MaidensLoyaltyFeature.Configure();
        MaidensOrderFeature.Configure();
        SupremeCommanderFeature.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureRefs.CavalierChallengeFeature.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierOrderSelection.ToString())
            .AddEntry(level: 01, features: FeatureSelectionRefs.CavalierMountSelection.ToString())
            .AddEntry(level: 03, features: FeatureRefs.CavalierCharge.ToString())
            .AddEntry(level: 11, features: FeatureRefs.CavalierMightyCharge.ToString())
            .AddEntry(level: 20, features: FeatureRefs.CavalierSupremeCharge.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: HalfheartedChallengeFeature.Guid)
            .AddEntry(level: 01, features: MaidensOrderFeature.Guid)
            .AddEntry(level: 01, features: CavalierOrderOfTheDragon.Guid)
            .AddEntry(level: 01, features: ProgressionRefs.CavalierOrderOfTheLionProgression.ToString())
            .AddEntry(level: 03, features: DevotedDefenderFeature.Guid)
            .AddEntry(level: 04, features: MaidensLoyaltyFeature.Guid)
            .AddEntry(level: 11, features: DedicatedCommanderFeature.Guid)
            .AddEntry(level: 20, features: SupremeCommanderFeature.Guid);
            
        var archetype = ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.CavalierClass)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.CavalierProgression)
            .AddToUIDeterminatorsGroup([
                MaidensOrderFeature.Guid,
                ProgressionRefs.CavalierOrderOfTheLionProgression.ToString(),
                CavalierOrderOfTheDragon.Guid])
            .Configure();
    }
}