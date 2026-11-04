using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Buffs.Components;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.Components;

internal class FalseKnightInsignia : UnitBuffComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        if (evt.Initiator != base.Owner)
            return;

        var spellDescriptor = new SpellDescriptorWrapper(SpellDescriptor.Fear | SpellDescriptor.Frightened | SpellDescriptor.Shaken);

        if (evt.Reason.Context is null || (evt.Reason.Context.SpellDescriptor & spellDescriptor) is SpellDescriptor.None)
            return;

        var bonus = 2 + Context.MaybeCaster.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 5;
        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(-bonus, Fact, ModifierDescriptor.Morale));
    }

    public override void OnTurnOn()
    {
        var bonus = 1 + Context.MaybeCaster.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 8;
        base.Owner.Stats.GetStat(StatType.AC).AddModifier(-bonus, base.Runtime, ModifierDescriptor.Morale);
    }

    public override void OnTurnOff()
    {
        base.Owner.Stats.GetStat(StatType.AC)?.RemoveModifiersFrom(base.Runtime);
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}