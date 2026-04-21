using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components;

internal class HellknightDevotion : UnitFactComponentDelegate, IRulebookHandler<RuleCalculateWeaponStats>, IInitiatorRulebookHandler<RuleCalculateWeaponStats>, IInitiatorRulebookSubscriber, ISubscriber
{
    public WeaponCategory WeaponType;

    public void OnEventAboutToTrigger(RuleCalculateWeaponStats evt)
    {
        if (Owner.HasFact(BlueprintTool.Get<BlueprintFeature>(HellknightDevotionFeature.Guid)) is false)
            return;

        if (evt.Weapon != null && evt.Weapon.Blueprint.Category == WeaponType)
        {
            evt.DoubleCriticalEdge = true;
        }
    }

    public void OnEventDidTrigger(RuleCalculateWeaponStats evt) { }
}
