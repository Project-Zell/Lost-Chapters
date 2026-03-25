using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.Utility;
using LostChapters.Modules.Custom.Feats;

namespace LostChapters.Modules.Custom.Components;

internal class ScarredLegion : UnitFactComponentDelegate, IInitiatorRulebookHandler<RuleSavingThrow>, IRulebookHandler<RuleSavingThrow>, ISubscriber, IInitiatorRulebookSubscriber
{
    public int Radius = 30;

    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        int num = 0;
        foreach (UnitEntityData item in GameHelper.GetTargetsAround(Owner.Position, Radius.Feet().Meters))
        {

            if ((item.Descriptor.HasFact(BlueprintTool.Get<BlueprintFeature>(ScarredLegionFeature.Guid)) || (bool)Owner.State.Features.SoloTactics) && !item.IsEnemy(Owner) && item != Owner)
            {
                num = 2;

            }
        }

        if (num > 0)
        {
            foreach (var buff in evt.Reason.Caster.Buffs)
            {
                if (buff.Blueprint.SpellDescriptor.HasAnyFlag(SpellDescriptor.Fear))
                {
                    num = 4;
                    break;
                }
            }
        }

        evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(num, Runtime));
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}
