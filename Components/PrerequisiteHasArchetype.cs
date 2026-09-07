using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using LostChapters.Tools;

namespace LostChapters.Components;

public class PrerequisiteHasArchetype : Prerequisite
{
    public BlueprintCharacterClassReference CharacterClass;
    public BlueprintArchetypeReference Archetype;

    public override bool CheckInternal(FeatureSelectionState selectionState, UnitDescriptor unit, LevelUpState state)
    {
        var classData = unit.Progression.GetClassData(CharacterClass?.Get());
        if (classData != null)
        {
            return classData.Archetypes.Contains(Archetype?.Get());
        }

        return true;
    }

    public override string GetUITextInternal(UnitDescriptor unit)
    {
        return $"{Tooltips.HasArchetype}: {Archetype.Get().Name}";
    }
}
