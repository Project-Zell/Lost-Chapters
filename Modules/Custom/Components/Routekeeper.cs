using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Components;

internal class Routekeeper : UnitFactComponentDelegate, IAreaActivationHandler, IGlobalSubscriber, IUnitLevelUpHandler
{
    public override void OnTurnOn()
    {
        UpdateModifiers();
    }

    public override void OnTurnOff()
    {
        RemoveModifiers();
    }

    public void UpdateModifiers()
    {
        RemoveModifiers();
        var bonus = Toolbox.GetFavoriteTerrainCount(Owner);
        Owner.Stats.Initiative.AddModifierUnique(bonus, Runtime, Kingmaker.Enums.ModifierDescriptor.UntypedStackable);
    }

    private void RemoveModifiers()
    {
        Owner.Stats.Initiative.RemoveModifiersFrom(Runtime);
    }

    public void OnAreaActivated()
    {
        UpdateModifiers();
    }

    public void HandleUnitBeforeLevelUp(UnitEntityData unit) { }

    public void HandleUnitAfterLevelUp(UnitEntityData unit, LevelUpController controller)
    {
        UpdateModifiers();
    }
}
