using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace LostChapters.Modules.HellknightCodex.Components
{
    internal class HellknightDevotion : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IRulebookHandler<RuleCalculateWeaponStats>, ISubscriber, IInitiatorRulebookSubscriber
    {
        public BlueprintWeaponType WeaponType;
        public Blueprint<BlueprintUnitFactReference> OrderBlueprint;

        public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
        {
            if (evt.Weapon != null && evt.Weapon.Blueprint.Type == WeaponType && evt.Initiator.HasFact(OrderBlueprint.Reference))
            {
                evt.AdditionalCriticalMultiplier.Add(new Modifier(1, base.Fact, ModifierDescriptor.UntypedStackable));
            }
        }

        public void OnEventDidTrigger(RuleCalculateWeaponStats evt) { }
    }
}
