using Kingmaker.Designers;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class HellknightAegis : UnitFactComponentDelegate, IRulebookHandler<RuleAttackWithWeapon>, ITargetRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
        {
            if (Owner.Body.PrimaryHand.Weapon.Blueprint.IsTwoHanded || Owner.Body.SecondaryHand.Weapon.Blueprint.IsTwoHanded) return;

            int bonus = 0;
            foreach (UnitEntityData item in GameHelper.GetTargetsAround(evt.Target.Position, 20.Feet()))
            {
                if (item.IsEnemy(Owner) && item.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic))
                {
                    bonus++;
                }
            }

            evt.Target.Stats.AC.AddModifierUnique(bonus, Runtime, ModifierDescriptor.Insight);
        }
        public void OnEventDidTrigger(RuleAttackWithWeapon evt)
        {
            evt.Target.Stats.AC.RemoveModifiersFrom(Runtime);
        }
    }
}
