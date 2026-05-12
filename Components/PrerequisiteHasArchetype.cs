using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using LostChapters.Modules.Custom.Archetypes.Demonologist;
using LostChapters.Tools;

namespace LostChapters.Components;

public class PrerequisiteHasArchetype(string classGuid, string archetypeGuid) : Prerequisite
{
    public BlueprintCharacterClassReference CharacterClass = BlueprintTool.GetRef<BlueprintCharacterClassReference>(classGuid);
    public BlueprintArchetypeReference Archetype = BlueprintTool.GetRef<BlueprintArchetypeReference>(archetypeGuid);

    public override bool CheckInternal(FeatureSelectionState selectionState, UnitDescriptor unit, LevelUpState state)
    {
        ClassData classData = unit.Progression.GetClassData(CharacterClass?.Get());
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
