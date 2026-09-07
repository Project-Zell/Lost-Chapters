using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.Custom.Archetypes.Magistrate;
using LostChapters.Modules.Other;
using System;

namespace LostChapters.Modules.Custom.Archetypes.Magistrate.Components;

internal static class MagistrateVerdictAbilityVariantConfigurator
{
    internal static void CreateAbility(string abilityName, string abilityGuid, string buffGuid, string displayName, string description)
    {
        var value = ContextValues.CustomProperty(TargetWillProperty.Guid);
        var applyBuff = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasFact(buffGuid, negate: true),
            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: buffGuid, asChild: true));

        var action = ActionsBuilder.New().SkillCheck(stat: StatType.CheckIntimidate, customDC: value,
            failure: ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(fact: CollectiveGuiltFeature.Guid),
                ifFalse: applyBuff,
                ifTrue: ActionsBuilder.New().OnRandomTargetsAround(actions: applyBuff, onEnemies: true, numberOfTargets: 30, radius: 20.Feet())));

        AbilityConfigurator.New(abilityName, abilityGuid)
            .AddAbilityEffectRunAction(actions: action)
            .AddAbilityTargetHasFact(checkedFacts: [CourtTrialFeature.Buff.Guid], fromCaster: true)
            .AddAbilityTargetHasFact(checkedFacts: [buffGuid], inverted: true, fromCaster: true)
            .AddAbilityResourceLogic(isSpendResource: true, amount: 1, requiredResource: VerdictAbility.Resource.Guid)
            .SetType(AbilityType.Extraordinary)
            .SetRange(AbilityRange.Long)
            .SetCanTargetEnemies(true)
            .SetShouldTurnToTarget(true)
            .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
            .SetActionType(UnitCommand.CommandType.Swift)
            .AddToAvailableMetamagic(Metamagic.Heighten | Metamagic.CompletelyNormal)
            .SetDisplayName(displayName)
            .SetDescription(description)
            .Configure();
    }
}