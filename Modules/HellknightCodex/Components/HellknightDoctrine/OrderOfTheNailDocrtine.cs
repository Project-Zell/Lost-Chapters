using BlueprintCore.Utils;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightCodex.Components.HellknightDoctrine;

internal class OrderOfTheNailDocrtine : UnitFactComponentDelegate, ITargetRulebookHandler<RuleCalculateCMD>, IRulebookHandler<RuleCalculateCMD>, ISubscriber, ITargetRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleCalculateCMD evt)
    {
        if (evt.Type is not CombatManeuver.Grapple)
            return;

        var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
        var bonus = evt.Initiator.HasFact(buff) ? 4 : 2;

        evt.AddModifier(bonus, base.Fact, ModifierDescriptor.None);
    }

    public void OnEventDidTrigger(RuleCalculateCMD evt) { }
}
