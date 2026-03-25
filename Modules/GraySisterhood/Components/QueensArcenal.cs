using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class QueensArcenal : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, IRulebookHandler<RuleCalculateAttackBonusWithoutTarget>, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleCalculateAttackBonusWithoutTarget evt)
        {
            if ((base.Owner == evt.Initiator) is false)
                return;

            if (IsConditionMeet())
            {
                var bonus = evt.Initiator.Descriptor.Progression.Features.GetRank(BlueprintTool.Get<BlueprintFeature>(QueensArcenalFeature.Guid));
                evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalAttackBonus.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
            }
        }

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            if (IsConditionMeet())
            {
                var bonus = evt.Initiator.Descriptor.Progression.Features.GetRank(BlueprintTool.Get<BlueprintFeature>(QueensArcenalFeature.Guid));
                evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalDamage.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
                evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
            }
        }

        private bool IsConditionMeet()
        {
            return base.Owner.IsWeaponEquipped(WeaponCategory.Longsword) && 
                   (base.Owner.IsWeaponEquipped(WeaponCategory.WeaponLightShield) || base.Owner.IsWeaponEquipped(WeaponCategory.WeaponHeavyShield));
        }

        public void OnEventDidTrigger(RuleCalculateAttackBonusWithoutTarget evt) { }
        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) { }
    }
}