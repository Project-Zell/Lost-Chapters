using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class ActAsOne : BlueprintComponent, IAbilityOnCastLogic
{
    private static readonly ContextDurationValue _duration = ContextDuration.FixedDice(DiceType.Zero, bonus: 1);

    public void OnCast(AbilityExecutionContext context)
    {
        foreach (UnitEntityData unit in GameHelper.GetTargetsAround(context.MaybeCaster.Position, 30.Feet()))
        {
            if (unit.IsAlly(context.MaybeCaster))
            {
                unit.AddBuff(blueprint: BlueprintTool.Get<BlueprintBuff>(ActAsOneFeature.Buff.Guid), caster: context.MaybeCaster, _duration.Calculate(context).Seconds);
            }
        }
    }
}
