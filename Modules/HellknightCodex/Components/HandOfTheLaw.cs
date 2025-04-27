using Kingmaker.EntitySystem;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class HandOfTheLaw : EntityFactComponentDelegate, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
        {
            if (evt.Target.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic))
            {
                int charisma = evt.Initiator.Stats.Charisma;
                int charismaBonus = charisma >= 12 ? Mathf.FloorToInt(charisma - 10) / 2 : 0;

                if (charismaBonus <= 0) return;
                evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalDamage.AddModifier(evt.Initiator.Stats.Charisma, Fact, ModifierDescriptor.UntypedStackable));
            }
        }

        public void OnEventDidTrigger(RuleAttackWithWeapon evt) { }
    }
}
