using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.Components;

internal class VersatileTactics : UnitFactComponentDelegate, ISubscriber, IInitiatorRulebookSubscriber, IRulebookHandler<RuleCalculateCMD>, IRulebookHandler<RuleCalculateCMB>
{
    public void OnEventAboutToTrigger(RuleCalculateCMD evt)
    {
        var bonus = Toolbox.GetTeamworkFeatsCount(base.Owner);
        evt.AddModifier(bonus, base.Fact, ModifierDescriptor.Competence);
    }

    public void OnEventAboutToTrigger(RuleCalculateCMB evt)
    {
        var bonus = Toolbox.GetTeamworkFeatsCount(base.Owner);
        evt.AddModifier(bonus, base.Fact, ModifierDescriptor.Competence);
    }

    public void OnEventDidTrigger(RuleCalculateCMD evt) { }

    public void OnEventDidTrigger(RuleCalculateCMB evt) { }
}