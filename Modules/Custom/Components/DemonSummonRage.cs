using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Utility;

namespace LostChapters.Modules.Custom.Components;

internal class DemonSummonRage : UnitBuffComponentDelegate<AddFactsFromCasterData>, IUnitReapplyFeaturesOnLevelUpHandler, IUnitSubscriber, ISubscriber
{
    public void HandleUnitReapplyFeaturesOnLevelUp()
    {
        OnRecalculate();
    }

    public override void OnActivate()
    {
        UnitEntityData unitEntityData = base.Fact.MaybeContext?.MaybeCaster;
        if (unitEntityData == null)
        {
            return;
        }

        var facts = FeatureSelectionRefs.RagePowerSelection.Reference.Get().m_Features;
        foreach (BlueprintUnitFact fact in facts)
        {
            if (unitEntityData.Descriptor.HasFact(fact) && !base.Owner.Descriptor.HasFact(fact))
            {
                base.Data.AppliedFacts.Add(base.Owner.AddFact(fact, base.Context));
            }
        }
    }

    public override void OnDeactivate()
    {
        base.Data.AppliedFacts.ForEach(base.Owner.RemoveFact);
        base.Data.AppliedFacts.Clear();
    }
}
