using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Buffs.Components;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class OrderOfTheDragonChallenge : UnitBuffComponentDelegate, ITargetRulebookHandler<RuleAttackRoll>, IRulebookHandler<RuleAttackRoll>, ISubscriber, ITargetRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleAttackRoll evt)
    {
        if (evt.Reason.SourceUnit == base.Context.MaybeCaster)
            return;

        if (Toolbox.IsTargetHasBuffFromCaster(base.Owner.Buffs, BuffRefs.CavalierChallengeBuffTarget.Reference, base.Context.MaybeCaster))
        {
            var bonus = 1 + base.Context.MaybeCaster.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;
            evt.AddTemporaryModifier(evt.Reason.SourceUnit.Stats.AdditionalAttackBonus.AddModifier(bonus, base.Fact, ModifierDescriptor.Circumstance));
        }
    }

    public void OnEventDidTrigger(RuleAttackRoll evt) { }
}
