using Kingmaker.Blueprints.Area;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using Kingmaker.UnitLogic.Parts;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.Custom.Components;

internal class LoneWayfarer : UnitFactComponentDelegate, ISubscriber, IGlobalSubscriber, IAreaActivationHandler, IUnitLevelUpHandler
{
    public override void OnTurnOn()
    {
        UpdateModifiers();
    }

    public override void OnTurnOff()
    {
        UpdateModifiers();
    }

    public void UpdateModifiers()
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting))
        {
            ActivateModifier();
        }
        else
        {
            DeactivateModifier();
        }
    }

    public void ActivateModifier()
    {
        Owner.Stats.Speed.RemoveModifiersFrom(Runtime);
        var bonusSpeed = Toolbox.GetFavoriteTerrainCount(Owner) * 10;
        Owner.Stats.Speed.AddModifierUnique(value: Mathf.Min(bonusSpeed, 30), source: Runtime);
    }

    public void DeactivateModifier()
    {
        Owner.Stats.Speed.RemoveModifiersFrom(Runtime);
    }

    public void OnAreaActivated()
    {
        UpdateModifiers();
    }
    public void HandleUnitAfterLevelUp(UnitEntityData unit, LevelUpController controller)
    {
        UpdateModifiers();
    }

    public void HandleUnitBeforeLevelUp(UnitEntityData unit) { }
}
