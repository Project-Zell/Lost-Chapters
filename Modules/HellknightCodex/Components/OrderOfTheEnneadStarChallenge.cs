using BlueprintCore.Blueprints.References;
using Kingmaker.ElementsSystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Mechanics;
using System.Linq;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class OrderOfTheEnneadStarChallenge : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttackBonus>, IRulebookHandler<RuleCalculateAttackBonus>, IInitiatorRulebookHandler<RuleSkillCheck>, IRulebookHandler<RuleSkillCheck>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateAttackBonus evt)
        {
            if (evt.Target.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic) is false)
                return;

            var buffs = evt.Target.GetFacts(BuffRefs.CavalierChallengeBuffTarget.Reference);
            if (buffs == null || buffs.Count() == 0)
                return;

            foreach (var buff in buffs)
            {
                if (buff.MaybeContext?.MaybeCaster == Owner)
                {
                    var bonusValue = 1 + Owner.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;
                    evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(bonusValue, Fact, ModifierDescriptor.Morale));
                    break;
                }
            }
        }

        public void OnEventAboutToTrigger(RuleSkillCheck evt)
        {
            MechanicsContext mechanicsContext = ContextData<MechanicsContext.Data>.Current?.Context;

            if (mechanicsContext.MainTarget.Unit.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic) is false)
                return;

            var buffs = mechanicsContext.MainTarget.Unit.GetFacts(BuffRefs.CavalierChallengeBuffTarget.Reference);
            if (buffs == null || buffs.Count() == 0)
                return;

            foreach (var buff in buffs)
            {
                if (buff.MaybeContext?.MaybeCaster == Owner && evt.StatType == StatType.CheckIntimidate)
                {
                    var bonusValue = 1 + evt.Initiator.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 4;
                    evt.AddTemporaryModifier(evt.Initiator.Stats.CheckIntimidate.AddModifier(bonusValue, Fact, ModifierDescriptor.Other));
                    break;
                }
            }
        }

        public void OnEventDidTrigger(RuleCalculateAttackBonus evt) { }

        public void OnEventDidTrigger(RuleSkillCheck evt) { }
    }
}
