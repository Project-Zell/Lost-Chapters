using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Parts;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon;

namespace LostChapters.Modules.GraySisterhood.Components;

internal class SupremeCommander : UnitFactComponentDelegate
{
    public override void OnTurnOn()
    {
        var abilities = new BlueprintAbilityReference[]
        {
            BlueprintTool.Get<BlueprintAbility>(StrategyFeature.Ability.Guid).ToReference<BlueprintAbilityReference>(),
            BlueprintTool.Get<BlueprintAbility>(ActAsOneFeature.Ability.Guid).ToReference<BlueprintAbilityReference>(),
            AbilityRefs.CavalierLionsCallAbility.Reference.Get().ToReference<BlueprintAbilityReference>(),
        };

        foreach (var blueprintAbilityReference in abilities)
        {
            var newEntry = new UnitPartAbilityModifiers.ActionEntry(base.Fact, UnitCommand.CommandType.Swift, blueprintAbilityReference);
            base.Owner.Ensure<UnitPartAbilityModifiers>().AddEntry(newEntry);
        }
    }

    public override void OnTurnOff()
    {
        base.Owner.Ensure<UnitPartAbilityModifiers>().RemoveEntry(base.Fact);
    }
}
