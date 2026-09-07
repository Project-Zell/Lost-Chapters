using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistArchetype
{
    public static readonly string Guid = "{836a4435-0f42-42d7-b413-d566a9ae0f7d}";

    public static readonly string BaseName = "Demonologist";

    private static readonly string ArchetypeName = $"{BaseName}Archetype";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    internal static void Configure()
    {
        DemonologistSpellbook.Configure();
        DemonologistSummonPool.Configure();

        DemonicStudiesFeature.Configure();
        DemonologistSummons.Configure();
        CallOfTheAbyssFeature.Configure();
        DemonologistExploitsSelection.Configure();
        HellsWhisperFeature.Configure();
        DemonizationFeature.Configure();
        FrenzyingCircleFeature.Configure();

        var parentClass = CharacterClassRefs.ArcanistClass;

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 03, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 05, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 07, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 09, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 11, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 13, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 15, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 17, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 19, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString())
            .AddEntry(level: 20, features: FeatureRefs.ArcanistMagicalSupremacy.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: DemonicStudiesFeature.Guid)
            .AddEntry(level: 01, features: HellsWhisperFeature.Guid)
            .AddEntry(level: 03, features: CallOfTheAbyssFeature.Guid)
            .AddEntry(level: 05, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 07, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 09, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 11, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 13, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 15, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 17, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 19, features: DemonologistExploitsSelection.Guid)
            .AddEntry(level: 20, features: DemonizationFeature.Guid);

        ArchetypeConfigurator.New(ArchetypeName, Guid, parentClass)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetReplaceSpellbook(DemonologistSpellbook.Guid)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();
    }
}