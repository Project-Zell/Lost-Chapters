using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.ResourceLinks;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistClass
{
    public static readonly string Guid = "{836a4435-0f42-42d7-b413-d566a9ae0f7d}";

    private static readonly string ArchetypeName = "Demonologist";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    internal static void Configure()
    {
        var parentClass = CharacterClassRefs.ArcanistClass;

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New();

        var addFeaturesEntryBuilder = LevelEntryBuilder.New();

        var classSkills = new StatType[]
        {
            
        };

        //Lvl 1: Gain demon spellbock, and reduce own will by 2
        //Lvl 5: All sommoning demon spell act as if they extended.
        //Lvl 9: Demonologist can expel 1 point of arcane reservoir to give all summoning demon benefets of the Rage spell
        //Lvl 20:






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
