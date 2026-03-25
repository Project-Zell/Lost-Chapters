using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Components;

internal class NoRespite : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting) is false)
            return;

        if (evt.Reason.Context != null && (evt.Reason.Context.SpellDescriptor == SpellDescriptor.Fatigue || evt.Reason.Context.SpellDescriptor == SpellDescriptor.Exhausted))
            evt.AddTemporaryModifier(evt.Initiator.Stats.SaveFortitude.AddModifier(2, Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}
