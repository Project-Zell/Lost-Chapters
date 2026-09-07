using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using System.Collections.Generic;
using static LostChapters.Modules.Custom.Archetypes.Demonologist.Tools.SummonDemonVisual;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

internal class DemonologistSummonAbilityHelper
{
    internal enum SummonCountType { Single, d3, d4plus1 }

    internal static void CreateSummonAbility(string guid, string name, string displayName, string description, string icon, string summonUnitID, SummonCountType countType, FxSize fxSize)
    {
        var contextValue = ContextValues.Rank();
        var duration = ContextDuration.Variable(value: contextValue);

        var superiorSummoningBonus = ContextValues.Rank(AbilityRankType.ProjectilesCount);

        ContextDiceValue count = countType switch
        {
            SummonCountType.d3 => new() { DiceType = DiceType.D3, DiceCountValue = ContextValues.Constant(1), BonusValue = superiorSummoningBonus },
            SummonCountType.d4plus1 => new() { DiceType = DiceType.D4, DiceCountValue = ContextValues.Constant(1), BonusValue = superiorSummoningBonus },
            _ => new() { DiceCountValue = 0, BonusValue = 1 },
        };

        var action = GetSummonActions(fxSize: fxSize);

        var spawnAction = ActionsBuilder.New()
            .SpawnMonsterUsingSummonPool(
                monster: summonUnitID,
                summonPool: DemonologistSummonPool.Guid,
                afterSpawn: action,
                countValue: count,
                durationValue: duration)
            .Conditional(ConditionsBuilder.New().CasterHasFact(CallOfTheAbyssFeature.Buff.Guid),
                ifTrue: ActionsBuilder.New().RemoveBuff(toCaster: true, onlyFromCaster: true, buff: CallOfTheAbyssFeature.Buff.Guid));

        var durationConfig = ContextRankConfigs.CasterLevel(min: 0, max: 20);

        AbilityConfigurator.New(name, guid)
            .AddContextRankConfig(durationConfig)
            .AddAbilityEffectRunAction(spawnAction)
            .SetType(AbilityType.Spell)
            .SetRange(AbilityRange.Close)
            .AddSpellComponent(SpellSchool.Conjuration)
            .AddSpellDescriptorComponent(SpellDescriptor.Summoning)
            .SetActionType(UnitCommand.CommandType.Standard)
            .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Point)
            .SetCanTargetSelf(true)
            .SetCanTargetPoint(true)
            .SetIsFullRoundAction(true)
            .SetAvailableMetamagic([Metamagic.Extend, Metamagic.Quicken, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal])
            .SetLocalizedDuration("6250ccf0-1ed0-460f-8ce7-094c2da7e198")
            .SetDisplayName(displayName)
            .SetDescription(description)
            .SetIcon(icon)
            .Configure();

        if (countType is SummonCountType.Single)
            return;

        ContextRankConfig summonConfig;
        if (countType is SummonCountType.d3)
            summonConfig = ContextRankConfigs.FeatureList(features: [FeatureRefs.SuperiorSummoning.ToString(), FeatureRefs.BloodlineAbyssalAddedSummonings.ToString()], type: AbilityRankType.ProjectilesCount, min: 0, max: 2);
        else
            summonConfig = ContextRankConfigs.FeatureList(features: [FeatureRefs.SuperiorSummoning.ToString(), FeatureRefs.BloodlineAbyssalAddedSummonings.ToString()], type: AbilityRankType.ProjectilesCount, min: 0, max: 3).WithOnePlusDiv2Progression();

        AbilityConfigurator.For(guid)
            .AddContextRankConfig(summonConfig)
            .Configure();
    }

    internal static void CreateBaseAbility(string guid, string name, string displayName, string description, string icon, List<Blueprint<BlueprintAbilityReference>> abilities)
    {
        AbilityConfigurator.New(name, guid)
            .AddAbilityVariants(abilities)
            .SetType(AbilityType.Spell)
            .SetRange(AbilityRange.Close)
            .AddSpellComponent(SpellSchool.Conjuration)
            .AddSpellDescriptorComponent(SpellDescriptor.Summoning)
            .SetActionType(UnitCommand.CommandType.Standard)
            .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Point)
            .SetCanTargetSelf(true)
            .SetCanTargetPoint(true)
            .SetIsFullRoundAction(true)
            .SetShouldTurnToTarget(true)
            .SetAvailableMetamagic([Metamagic.Empower, Metamagic.Maximize, Metamagic.Quicken, Metamagic.Extend, Metamagic.Heighten, Metamagic.Reach, Metamagic.CompletelyNormal])
            .SetLocalizedDuration("6250ccf0-1ed0-460f-8ce7-094c2da7e198")
            .SetDisplayName(displayName)
            .SetDescription(description)
            .SetIcon(icon)
            .Configure();
    }

    internal static ActionsBuilder GetSummonActions(FxSize fxSize)
    {
        var fxGuid = fxSize switch
        {
            FxSize.Medium => MediumAppearBuff.Guid,
            FxSize.Big => BigAppearBuff.Guid,
            FxSize.Giant => GiantAppearBuff.Guid,
            _ => SmallAppearBuff.Guid,
        };

        var recklessStanceAction = ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.RecklessStanceEffectBuff.ToString());
        var recklessStanceCondition = ConditionsBuilder.New().CasterHasFact(BuffRefs.RecklessStanceSwitchBuff.ToString());

        var lethalStanceAction = ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.LethalStanceEffectBuff.ToString());
        var lethalStanceCondition = ConditionsBuilder.New().CasterHasFact(BuffRefs.LethalStanceSwitchBuff.ToString());

        var guardedStanceAction = ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.GuardedStanceEffectBuff.ToString());
        var guardedStanceCondition = ConditionsBuilder.New().CasterHasFact(BuffRefs.GuardedStanceSwitchBuff.ToString());

        var comeAndGetMeAction = ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.ComeAndGetMeEffectBuff.ToString());
        var comeAndGetMeCondition = ConditionsBuilder.New().CasterHasFact(BuffRefs.ComeAndGetMeSwitchBuff.ToString());

        var inspireFerocityAction = ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.InspireFerocityEffectBuff.ToString());
        var inspireFerocityCondition = 
            ConditionsBuilder.New().CasterHasFact(BuffRefs.RecklessStanceSwitchBuff.ToString()).CasterHasFact(BuffRefs.InspireFerocityBaseBuff.ToString());

        var casterHasCallOfTheAbyssCondition = ConditionsBuilder.New().CasterHasFact(CallOfTheAbyssFeature.Buff.Guid);
        var casterHasCallOfTheAbyssAction = 
            ActionsBuilder.New().ApplyBuffPermanent(DemonSummonRageBuff.Guid).ApplyBuffPermanent(BuffRefs.StandartRageBuff.ToString());

        return ActionsBuilder.New()
            .ApplyBuffPermanent(fxGuid)
            .ApplyBuffPermanent(SummonedDemonFx.Guid)
            .Conditional(ConditionsBuilder.New().CasterHasFact(CallOfTheAbyssFeature.Buff.Guid), ifTrue: ActionsBuilder.New()
                .Conditional(conditions: recklessStanceCondition, ifTrue: recklessStanceAction)
                .Conditional(conditions: lethalStanceCondition, ifTrue: lethalStanceAction)
                .Conditional(conditions: guardedStanceCondition, ifTrue: guardedStanceAction)
                .Conditional(conditions: comeAndGetMeCondition, ifTrue: comeAndGetMeAction)
                .Conditional(conditions: inspireFerocityCondition, ifTrue: inspireFerocityAction)
                .Conditional(conditions: casterHasCallOfTheAbyssCondition, ifTrue: casterHasCallOfTheAbyssAction));
    }
}