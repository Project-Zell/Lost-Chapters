using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.Localization;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;

namespace LostChapters.Components;

internal class AbilityTargetIsSummonedUnit : BlueprintComponent, IAbilityTargetRestriction
{
    private static readonly string CombatLogMessageDefault = "AbilityTargetIsSummonedUnit.UIText";
    private static readonly string CombatLogMessageByCaster = "AbilityTargetIsSummonedUnit.ByCaster.UIText";

    public bool CasterIsUnitSummoner;
    public BlueprintUnitFactReference CheckedFact = null;
    public string MessageOverride = string.Empty;

    public bool IsTargetRestrictionPassed(UnitEntityData caster, TargetWrapper target)
    {
        if (target == null || target.Unit == null || target.Unit.IsSummoned() is false || target.Unit.State.IsDead)
            return false;

        var buff = BlueprintTool.Get<BlueprintBuff>(BuffRefs.SummonedUnitBuff.ToString());

        var isCasterSummoner = target.Unit.Buffs.GetBuff(buff).Context.MaybeCaster == caster;
        var casterConditionIsValid = CasterIsUnitSummoner is false || isCasterSummoner;

        var checkFact = CheckedFact is not null;
        var factConditionIsValid = true;

        if (checkFact)
        {   
            var fact = BlueprintTool.Get<BlueprintBuff>(CheckedFact.ToString());
            factConditionIsValid = target.Unit.HasFact(fact);
        }

        if (casterConditionIsValid && factConditionIsValid)
            return true;

        return false;
    }

    public string GetAbilityTargetRestrictionUIText(UnitEntityData caster, TargetWrapper target)
    {
        var localizedText = MessageOverride != string.Empty ? MessageOverride : CasterIsUnitSummoner ? CombatLogMessageByCaster : CombatLogMessageDefault;
        return LocalizationManager.CurrentPack.GetText(localizedText);
    }
}