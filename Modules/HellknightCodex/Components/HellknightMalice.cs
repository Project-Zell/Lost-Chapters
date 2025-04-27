using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline;
using System;

namespace LostChapters.Modules.GraySisterhood.Components
{
    internal class HellknightMalice : UnitFactComponentDelegate, IUnitGainFactHandler, IUnitLostFactHandler
    {
        public void HandleUnitGainFact(EntityFact fact)
        {
            if (fact.Blueprint != HellknightObidienceBuff.GetReference()) return;

            var hellknightLevels = Owner.Progression.GetClassLevel(CharacterClassRefs.HellknightClass.Reference)
                     + Owner.Progression.GetClassLevel(CharacterClassRefs.HellknightSigniferClass.Reference);

            var baseAttackCap = Owner.Progression.CharacterLevel - Owner.Stats.BaseAttackBonus;
            var bonus = Math.Min(baseAttackCap, hellknightLevels);

            Owner.Stats.GetStat(StatType.BaseAttackBonus).AddModifierUnique(bonus, Runtime, ModifierDescriptor.Other);
        }

        public void HandleUnitLostFact(EntityFact fact)
        {
            if (fact.Blueprint != HellknightObidienceBuff.GetReference()) return;
            Owner.Stats.GetStat(StatType.BaseAttackBonus).RemoveModifiersFrom(Runtime);
        }
    }
}
