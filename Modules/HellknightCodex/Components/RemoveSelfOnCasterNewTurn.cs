using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class RemoveSelfOnCasterNewTurn : UnitBuffComponentDelegate, ISubscriber, IInitiatorRulebookSubscriber, IUnitNewCombatRoundHandler, IUnitCombatHandler
    {
        public void HandleNewCombatRound(UnitEntityData unit) => RemoveBuff(unit);
        public void HandleUnitJoinCombat(UnitEntityData unit) => RemoveBuff(unit);
        public void HandleUnitLeaveCombat(UnitEntityData unit) => RemoveBuff(unit);

        public void RemoveBuff(UnitEntityData unit)
        {
            if (unit == Context.MaybeCaster)
            {
                var buffs = Context.MaybeOwner.Buffs;
                foreach (var buff in buffs)
                {
                    if (buff.Context.MaybeCaster == unit && buff.Blueprint == Context.AssociatedBlueprint)
                    {
                        buff.Remove();
                        break;
                    }
                }
            }
        }
    }
}
