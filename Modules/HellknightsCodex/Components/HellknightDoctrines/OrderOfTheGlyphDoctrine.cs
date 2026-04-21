using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;

internal class OrderOfTheGlyphDoctrine : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, ISubscriber, IInitiatorRulebookSubscriber
{
    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        var modifierDescriptor = ModifierDescriptor.None;

        var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
        var bonus = Owner.HasFact(buff) ? 4 : 2;

        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(bonus, Runtime, modifierDescriptor));
        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveReflex.AddModifier(bonus, Runtime, modifierDescriptor));
        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveFortitude.AddModifier(bonus, Runtime, modifierDescriptor));
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}
