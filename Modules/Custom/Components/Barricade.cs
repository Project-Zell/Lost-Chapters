using BlueprintCore.Utils;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using LostChapters.Modules.Custom.Orders.Cavalier.Bastion;

namespace LostChapters.Modules.Custom.Components;

internal class Barricade : UnitFactComponentDelegate, IAreaActivationHandler
{
    public override void OnTurnOn()
    {
        UpdateModifiers();
    }

    public override void OnTurnOff()
    {
        DeactivateModifier();
    }

    public void UpdateModifiers()
    {
        if (Owner.Ensure<UnitPartFavoredTerrain>().HasEntry(AreaService.Instance.CurrentAreaSetting))
        {
            ActivateModifier();
        }
        else
        {
            DeactivateModifier();
        }
    }

    private void ActivateModifier()
    {
        var rankBonus = 0;
        var rankFeature = BlueprintTool.Get<BlueprintFeature>(BarricadeFeature.Rank.Guid);
        if (Owner.HasFact(rankFeature))
            rankBonus = Owner.Descriptor.Progression.Features.GetRank(rankFeature);

        Owner.Stats.AC.AddModifier(rankBonus, Runtime, ModifierDescriptor.UntypedStackable);
        Owner.Stats.SaveReflex.AddModifier(rankBonus, Runtime, ModifierDescriptor.UntypedStackable);
        Owner.Stats.AdditionalAttackBonus.AddModifier(rankBonus, Runtime, ModifierDescriptor.UntypedStackable);
    }

    private void DeactivateModifier()
    {
        Owner.Stats.AC.RemoveModifiersFrom(Runtime);
        Owner.Stats.SaveReflex.RemoveModifiersFrom(Runtime);
        Owner.Stats.AdditionalAttackBonus.RemoveModifiersFrom(Runtime);
    }

    public void OnAreaActivated()
    {
        UpdateModifiers();
    }
}
