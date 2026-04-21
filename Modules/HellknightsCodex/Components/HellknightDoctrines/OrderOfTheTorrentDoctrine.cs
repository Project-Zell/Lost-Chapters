using BlueprintCore.Utils;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;

internal class OrderOfTheTorrentDoctrine : UnitFactComponentDelegate<ACBonusAgainstAttacks.RuntimeData>, ITargetRulebookHandler<RuleAttackWithWeapon>, IRulebookHandler<RuleAttackWithWeapon>, ISubscriber, ITargetRulebookSubscriber, ITargetRulebookHandler<RuleCalculateAC>, IRulebookHandler<RuleCalculateAC>
{
    public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
    {
        if (evt.IsAttackOfOpportunity)
        {
            var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
            var bonus = Owner.HasFact(buff) ? 4 : 2;

            Data.ACModifier = bonus;
            Data.Initiator = evt.Initiator;
        }
    }

    public void OnEventDidTrigger(RuleAttackWithWeapon evt)
    {
        Data.Clear();
    }

    public void OnEventAboutToTrigger(RuleCalculateAC evt)
    {
        if (Data.Initiator != null && evt.Initiator == Data.Initiator)
        {
            evt.AddModifier(Data.ACModifier, Fact, ModifierDescriptor.None);
        }
    }

    public void OnEventDidTrigger(RuleCalculateAC evt) { }
}