using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

internal class DemonologistSpellbookHelper
{
    internal static void CreateSpellbookForPrestiegeClass(string guid, string name, string descriptionKey, int requiredSpellLevel, string classSpellbookGuid,
        BlueprintFeatureReplaceSpellbook spellbookToRestrict, FeatureGroup featureGroup, string spellbookDisplayName)
    {
        var characterClass = CharacterClassRefs.ArcanistClass.ToString();
        var demonologistGuid = DemonologistArchetype.Guid;

        FeatureReplaceSpellbookConfigurator.For(spellbookToRestrict)
            .AddPrerequisiteNoArchetype(
                characterClass: characterClass,
                archetype: demonologistGuid)
            .Configure();

        var spellbook = FeatureReplaceSpellbookConfigurator.New(name, guid)
            .AddPrerequisiteArchetypeLevel(characterClass: characterClass, archetype: demonologistGuid, level: 1)
            .AddPrerequisiteClassSpellLevel(characterClass: characterClass, requiredSpellLevel: requiredSpellLevel)
            .SetSpellbook(DemonologistSpellbook.Guid)
            .SetGroups(featureGroup)
            .SetHideInUI(true)
            .SetHideNotAvailibleInUI(true)
            .SetIsClassFeature(true)
            .SetDisplayName(spellbookDisplayName)
            .SetDescription(descriptionKey)
            .Configure();

        FeatureSelectionConfigurator.For(classSpellbookGuid)
            .AddToAllFeatures([spellbook])
            .Configure();
    }
}