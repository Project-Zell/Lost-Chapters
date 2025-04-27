using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;

namespace LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

internal class Dreadnought
{
    public static readonly string Guid = "{091980c4-8feb-42a8-ba7f-975261906361}";

    private static readonly string ArchetypeName = "Dreadnought";
    private static readonly string LocalizedName = "Dreadnought.Name";
    private static readonly string Description   = "Dreadnought.Description";

    internal static void Configure()
    {
        DeadCalmFeature.Configure();
        SteadyGaitFeature.Configure();
        FearlessKillerFeature.Configure();
        DreadPressenceFeature.Configure();
        InstantDispassionFeature.Configure();
        PursuerFeature.Configure();

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
               .AddEntry(level: 01, features: FeatureRefs.RageFeature.ToString())
               .AddEntry(level: 01, features: FeatureRefs.FastMovement.ToString())
               .AddEntry(level: 11, features: FeatureRefs.GreaterRageFeature.ToString())
               .AddEntry(level: 14, features: FeatureRefs.IndomitableWill.ToString())
               .AddEntry(level: 17, features: FeatureRefs.TirelessRage.ToString())
               .AddEntry(level: 20, features: FeatureRefs.MightyRage.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
                .AddEntry(level: 01, features: DeadCalmFeature.Guid)
                .AddEntry(level: 01, features: SteadyGaitFeature.Guid)
                .AddEntry(level: 11, features: DreadPressenceFeature.Guid)
                .AddEntry(level: 14, features: FearlessKillerFeature.Guid)
                .AddEntry(level: 17, features: InstantDispassionFeature.Guid)
                .AddEntry(level: 20, features: PursuerFeature.Guid);

        ArchetypeConfigurator.New(ArchetypeName, Guid, CharacterClassRefs.BarbarianClass)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();

        ProgressionConfigurator.For(ProgressionRefs.BarbarianProgression)
            .AddToUIGroups(new Blueprint<BlueprintFeatureBaseReference>[] {
                    DeadCalmFeature.Guid,
                    DreadPressenceFeature.Guid,
                    InstantDispassionFeature.Guid,
                    PursuerFeature.Guid})
            .Configure();
    }
}
