using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;

namespace LostChapters.Components;

internal class SavingThrowBonusFromSummonPool : UnitFactComponentDelegate, IRulebookHandler<RuleSavingThrow>, IInitiatorRulebookHandler<RuleSavingThrow>, ISubscriber, IInitiatorRulebookSubscriber
{
    public BlueprintSummonPool[] SummonPools;
    public SavingThrowType SavingThrowType = SavingThrowType.Unknown;
    public int BonusMod = 1;

    public void OnEventAboutToTrigger(RuleSavingThrow evt)
    {
        int bonus = 0;
        foreach(var pool in SummonPools)
        {
            foreach (UnitEntityData unit in Game.Instance.SummonPools.GetPool(pool).Units)
            {
                if (unit.State.IsFinallyDead is false)
                {
                    bonus++;
                }
            }
        }
        bonus *= BonusMod;
        
        if(SavingThrowType == SavingThrowType.Unknown || SavingThrowType == SavingThrowType.Will)
            evt.AddTemporaryModifier(evt.Initiator.Stats.SaveWill.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));

        if(SavingThrowType == SavingThrowType.Unknown || SavingThrowType == SavingThrowType.Reflex)
            evt.AddTemporaryModifier(evt.Initiator.Stats.SaveReflex.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));

        if(SavingThrowType == SavingThrowType.Unknown || SavingThrowType == SavingThrowType.Fortitude)
            evt.AddTemporaryModifier(evt.Initiator.Stats.SaveFortitude.AddModifier(bonus, Fact, ModifierDescriptor.UntypedStackable));
    }

    public void OnEventDidTrigger(RuleSavingThrow evt) { }
}
