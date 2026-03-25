using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightCodex.Components.HellknightDoctrine;

internal class OrderOfTheGodclawDoctrine : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        if (evt.Reason.Context is null || evt.Reason.Context.SpellDescriptor.HasAnyFlag(SpellDescriptor.MindAffecting) is false)
            return;

        var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
        var bonus = evt.Initiator.HasFact(buff) ? 4 : 2;

        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(bonus, Fact, ModifierDescriptor.None));
        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveReflex.AddModifier(bonus, Fact, ModifierDescriptor.None));
        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveFortitude.AddModifier(bonus, Fact, ModifierDescriptor.None));
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}
