using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters._templates;

internal class ArchetypeTemplate
{
    public static readonly string Guid = "";

    private static readonly string ArchetypeName = "";
    private static readonly string LocalizedName = $"{ArchetypeName}.Name";
    private static readonly string Description   = $"{ArchetypeName}.Description";

    internal static void Configure()
    {
        BlueprintCharacterClass parentClass = null;

        var removeFeaturesEntryBuilder = LevelEntryBuilder.New();

        var addFeaturesEntryBuilder = LevelEntryBuilder.New();

        var classSkills = new StatType[]
        {

        };

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
