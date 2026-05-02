using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistArchetype
{
    public static readonly string Guid = "{836a4435-0f42-42d7-b413-d566a9ae0f7d}";

    private static readonly string ArchetypeName = "DemonologistArchetype";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    internal static void Configure()
    {
        DemonologyFeature.Configure();
        DemonologistSummons.Configure();
        CallOfTheAbyssFeature.Configure();
        DemonologistExploitSelection.Configure();

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
            .AddEntry(level: 19, features: FeatureSelectionRefs.ArcanistExploitSelection.ToString());

        var addFeaturesEntryBuilder = LevelEntryBuilder.New()
            .AddEntry(level: 01, features: SummonDemonIFeature.Guid)
            .AddEntry(level: 03, features: SummonDemonIIFeature.Guid)
            .AddEntry(level: 01, features: DemonologyFeature.Guid)
            .AddEntry(level: 03, features: CallOfTheAbyssFeature.Guid)
            .AddEntry(level: 05, features: DemonologistExploitSelection.Guid)
            .AddEntry(level: 07, features: DemonologistExploitSelection.Guid)
            .AddEntry(level: 09, features: DemonologistExploitSelection.Guid)
            .AddEntry(level: 11, features: DemonologistExploitSelection.Guid)
            .AddEntry(level: 13, features: DemonologistExploitSelection.Guid)
            .AddEntry(level: 15, features: DemonologistExploitSelection.Guid)
            .AddEntry(level: 17, features: DemonologistExploitSelection.Guid)
            .AddEntry(level: 19, features: DemonologistExploitSelection.Guid)
            ;

        var classSkills = new StatType[]
        {
            
        };

        //Lvl 1: Gain demon spellbook, and reduce own will by 1 for each summoned demon.
        //Lvl 1: When selecting arcanist exploit, demonolog might select barbarian rage power instead.
        //Lvl 3: By expeling arcanist point, next summoned demons can benefits of the barbarian rage.

        //Lvl 1: 1d3 Drench 
        //Lvl 2:
        //Lvl 3: 1d3 Babau

        ArchetypeConfigurator.New(ArchetypeName, Guid, parentClass)
            .SetReplaceClassSkills(true)
            .SetClassSkills(classSkills)
            .SetAddFeatures(addFeaturesEntryBuilder)
            .SetRemoveFeatures(removeFeaturesEntryBuilder)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(Description)
            .Configure();
    }
}
