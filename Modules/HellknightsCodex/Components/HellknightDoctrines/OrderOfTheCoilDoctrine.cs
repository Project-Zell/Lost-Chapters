using BlueprintCore.Utils;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;

internal class OrderOfTheCoilDoctrine : UnitFactComponentDelegate, ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, ITargetRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        if (evt.Weapon.Blueprint.FighterGroup.Contains(WeaponFighterGroup.Natural))
        {
            var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
            var bonus = Owner.HasFact(buff) ? 4 : 2;

            evt.Target.Stats.AC.AddModifierUnique(bonus, Runtime, ModifierDescriptor.None);
        }
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
        evt.Target.Stats.AC.RemoveModifiersFrom(Runtime);
    }
}
