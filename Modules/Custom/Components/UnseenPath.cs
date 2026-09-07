using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.ActivatableAbilities.Restrictions;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Parts;
using LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

namespace LostChapters.Modules.Custom.Components;

internal class UnseenPath : UnitFactComponentDelegate, IUnitCombatHandler
{
    public override void OnTurnOn()
    {
        base.OnTurnOn();
        base.Owner.State.Features.ImmuneToArmorSpeedPenalty.Retain();

        if (RestrictionsHelper.CheckHasArmor(base.Owner))
        {
            base.Owner.Body.Armor.Armor.RecalculateStats();
        }
    }

    public override void OnTurnOff()
    {
        base.OnTurnOff();
        base.Owner.State.Features.ImmuneToArmorSpeedPenalty.Release();

        if (RestrictionsHelper.CheckHasArmor(base.Owner))
        {
            base.Owner.Body.Armor.Armor.RecalculateStats();
        }
    }
    public void HandleUnitJoinCombat(UnitEntityData unit)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting))
        {
           Owner.AddBuff(BlueprintTool.Get<BlueprintBuff>(UnseenPathFeature.Buff.Guid), Owner);
        }
    }

    public void HandleUnitLeaveCombat(UnitEntityData unit) { }
}