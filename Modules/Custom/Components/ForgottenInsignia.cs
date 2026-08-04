using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using LostChapters.Modules.Custom.Archetypes.FalseKnight;

namespace LostChapters.Modules.Custom.Components;

internal class ForgottenInsignia : UnitBuffComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAC>, IRulebookHandler<RuleCalculateAC>, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, IInitiatorRulebookHandler<RuleCalculateCMD>, IRulebookHandler<RuleCalculateCMD>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        var spellDescriptor = new SpellDescriptorWrapper(SpellDescriptor.Fear | SpellDescriptor.Frightened | SpellDescriptor.Shaken);

        if (evt.Reason.Context is null || (evt.Reason.Context.SpellDescriptor & spellDescriptor) is SpellDescriptor.None)
            return;

        var bonus = 2 + base.Context.MaybeCaster.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 5;
        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(-bonus, Fact, ModifierDescriptor.Morale));
    }

    public void OnEventAboutToTrigger(RuleCalculateCMD evt)
    {
        var bonus = 1 + base.Context.MaybeCaster.Progression.GetClassLevel(CharacterClassRefs.CavalierClass.Reference) / 5;
        evt.AddModifier(-bonus, base.Fact, ModifierDescriptor.Morale);
    }

    public void OnEventAboutToTrigger(RuleCalculateAC evt)
    {
        if (base.Context.MaybeCaster.HasFact(BlueprintTool.Get<BlueprintFeature>(ForbiddenRelicFeature.Guid)))
        {
            evt.AddModifier(-2, base.Fact, ModifierDescriptor.Morale);
        }
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }

    public void OnEventDidTrigger(RuleCalculateCMD evt) { }

    public void OnEventDidTrigger(RuleCalculateAC evt) { }
}
