using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Components;
using Kingmaker.UnitLogic;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class EquipmentRestrictionHasFact : EquipmentRestriction
{
    public BlueprintFeature CheckedFact;

    public override bool CanBeEquippedBy(UnitDescriptor unit)
    {
        return unit.HasFact(CheckedFact);
    }
}
