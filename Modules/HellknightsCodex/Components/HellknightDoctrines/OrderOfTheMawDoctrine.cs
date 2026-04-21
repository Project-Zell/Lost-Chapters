using BlueprintCore.Utils;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;

internal class OrderOfTheMawDoctrine : UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>, ITargetRulebookHandler<RuleAttackRoll>, IRulebookHandler<RuleAttackRoll>, ISubscriber, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleCalculateAC>, IRulebookHandler<RuleCalculateAC>
{
    public void OnEventAboutToTrigger(RuleAttackRoll evt)
    {
        var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
        var bonus = Owner.HasFact(buff) ? 4 : 2;

        Size size = Size.Fine;
        Size size2 = base.Owner.State.Size;

        if (size - size2 == 1 || size - size2 == 2)
        {
            base.Data.ACModifier = bonus;
            base.Data.Initiator = evt.Initiator;
        }
    }

    public void OnEventAboutToTrigger(RuleCalculateAC evt)
    {
        if (base.Data.Initiator != null && evt.Initiator == base.Data.Initiator)
        {
            evt.AddModifier(base.Data.ACModifier, base.Fact, ModifierDescriptor.None);
        }
    }

    public void OnEventDidTrigger(RuleAttackRoll evt)
    {
        Data.Clear();
    }

    public void OnEventDidTrigger(RuleCalculateAC evt) { }
}
