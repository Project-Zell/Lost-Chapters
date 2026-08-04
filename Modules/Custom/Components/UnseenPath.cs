using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Parts;
using LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

namespace LostChapters.Modules.Custom.Components;

internal class UnseenPath : UnitFactComponentDelegate, IUnitCombatHandler
{
    public void HandleUnitJoinCombat(UnitEntityData unit)
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting))
        {
            Owner.AddBuff(BlueprintTool.Get<BlueprintBuff>(UnseenPathFeature.Buff.Guid), Owner);
        }
    }

    public void HandleUnitLeaveCombat(UnitEntityData unit) { }
}