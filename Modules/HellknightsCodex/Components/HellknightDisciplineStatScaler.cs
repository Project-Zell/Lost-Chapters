using BlueprintCore.Utils;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;
using LostChapters.Tools;

namespace LostChapters.Modules.HellknightCodex.Components;

internal class HellknightDisciplineStatScaler : UnitBuffComponentDelegate, IUnitGainFactHandler, IUnitSubscriber, ISubscriber, IUnitLostFactHandler
{
    public StatType Stat;

    public void HandleUnitGainFact(EntityFact fact)
    {
        if (fact.Blueprint == BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid))
        {
            var owner = base.Owner;
            var bonus = 1 + Toolbox.GetHellknightDisciplineCount(owner);
            owner.Stats.GetStat(Stat).AddModifierUnique(bonus, base.Runtime, ModifierDescriptor.Morale);
        }
    }

    public void HandleUnitLostFact(EntityFact fact)
    {
        if (fact.Blueprint == BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid))
        {
            base.Owner.Stats.GetStat(Stat).RemoveModifiersFrom(base.Runtime);
        }
    }
}
