using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components;

internal class HellknightDedication : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, IInitiatorRulebookSubscriber
{
    public WeaponCategory WeaponType;

    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        var fact = BlueprintTool.Get<BlueprintFeature>(HellknighDedicationFeature.Guid);

        if (Owner.HasFact(fact) is false || Owner != evt.Initiator)
            return;

        if (evt.Weapon != null && evt.Weapon.Blueprint.Category == WeaponType && evt.Target.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic))
        {
            var bonus = Owner.Progression.GetClassLevel(CharacterClassRefs.HellknightClass.Reference) + Owner.Progression.GetClassLevel(CharacterClassRefs.HellknightSigniferClass.Reference);
            var reason = Owner.GetFact(fact);
            evt.AddTemporaryModifier(evt.Initiator.Stats.AdditionalDamage.AddModifier(bonus, reason, ModifierDescriptor.UntypedStackable));
        }
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt) { }
}
