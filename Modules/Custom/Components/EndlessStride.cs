using Kingmaker.Blueprints.Area;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;

namespace LostChapters.Modules.Custom.Components;

internal class EndlessStride : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttacksCount>, IRulebookHandler<RuleCalculateAttacksCount>, ISubscriber, IInitiatorRulebookSubscriber, IAreaActivationHandler
{
    public override void OnTurnOn()
    {
        UpdateModifiers();
    }

    public override void OnTurnOff()
    {
        DeactivateModifier();
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

    private void ActivateModifier()
    {
        Owner.State.RemoveConditionImmunity(UnitCondition.DifficultTerrain);
        Owner.State.AddConditionImmunity(UnitCondition.DifficultTerrain);
    }

    private void DeactivateModifier()
    {
        Owner.State.RemoveConditionImmunity(UnitCondition.DifficultTerrain);
    }

    public void OnEventAboutToTrigger(RuleCalculateAttacksCount evt)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting))
            evt.AddExtraAttacks(1, false, false);
    }

    public void OnEventDidTrigger(RuleCalculateAttacksCount evt) { }

    public void OnAreaActivated()
    {
        UpdateModifiers();
    }
}
