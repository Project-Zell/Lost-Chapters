using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics.Properties;

namespace LostChapters.Components;

internal class SummClassLevelGatedGetter : PropertyValueGetter
{
    public BlueprintCharacterClassReference[] Classes;
    public BlueprintArchetypeReference[] Archetypes;

    public bool UseCharacterLevelIfHasAnyFact = true;
    public BlueprintUnitFactReference[] GatedFacts;

    public override int GetBaseValue(UnitEntityData unit)
    {
        if (UseCharacterLevelIfHasAnyFact && GatedFacts != null)
        {
            foreach (var fact in GatedFacts)
            {
                if (unit.Descriptor.HasFact(fact.Get()))
                    return unit.Descriptor.Progression.CharacterLevel;
            }
        }

        int num = 0;

        foreach (var classData in unit.Descriptor.Progression.Classes)
        {
            if (Classes.HasReference(classData.CharacterClass) is false)
                continue;

            if (Archetypes.Length > 0)
            {
                foreach (var archetype in Archetypes)
                {
                    if (classData.CharacterClass.Archetypes.HasReference(archetype) is false)
                        continue;

                    if (classData.Archetypes.Contains(archetype))
                        num += classData.Level;
                }
            }
            else
            {
                num += classData.Level;
            }
        }

        return num;
    }
}
