using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules.Abilities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using LostChapters.Modules.Custom.Archetypes.MageSlayer;
using UnityEngine;

namespace LostChapters.Modules.Custom.Components;

internal class MindShatterTarget : UnitBuffComponentDelegate, IInitiatorRulebookHandler<RuleCalculateAbilityParams>, IRulebookHandler<RuleCalculateAbilityParams>, ISubscriber, IInitiatorRulebookSubscriber, IConcentrationBonusProvider
{
    private int Bonus;

    public void OnEventAboutToTrigger(RuleCalculateAbilityParams evt)
    {
        var rankFeature = BlueprintTool.Get<BlueprintFeature>(MindShatterFeature.Guid);
        var caster = evt.Reason.Caster;

        var rankBonus = 0;
        if (caster.HasFact(rankFeature))
            rankBonus = caster.Descriptor.Progression.Features.GetRank(rankFeature);
        Bonus = Mathf.Max(-rankBonus, -5);
        evt.AddBonusConcentration(GetStaticConcentrationBonus());
    }

    public int GetStaticConcentrationBonus()
    {
        return Bonus;
    }

    int IConcentrationBonusProvider.GetStaticConcentrationBonus(EntityFactComponent runtime)
    {
        using (runtime.RequestEventContext())
        {
            return GetStaticConcentrationBonus();
        }
    }

    public void OnEventDidTrigger(RuleCalculateAbilityParams evt) { }
}
