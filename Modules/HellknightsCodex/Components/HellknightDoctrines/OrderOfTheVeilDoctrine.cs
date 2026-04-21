using BlueprintCore.Utils;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

namespace LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;

internal class OrderOfTheVeilDoctrine : UnitFactComponentDelegate, IRulebookHandler<RuleDispelMagic>, IInitiatorRulebookHandler<RuleDispelMagic>, IInitiatorRulebookSubscriber, ISubscriber
{
    public void OnEventAboutToTrigger(RuleDispelMagic evt)
    {
        if (evt.Target.Descriptor.Alignment.ValueRaw.HasComponent(AlignmentComponent.Chaotic) is false)
            return;

        var buff = BlueprintTool.Get<BlueprintBuff>(HellknightObidienceFeature.Buff.Guid);
        var bonus = Owner.HasFact(buff) ? 4 : 2;

        evt.Bonus += bonus;
    }

    public void OnEventDidTrigger(RuleDispelMagic evt) { }
}
