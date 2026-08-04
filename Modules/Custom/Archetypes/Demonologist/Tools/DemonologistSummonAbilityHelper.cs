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
using static LostChapters.Modules.Custom.Archetypes.Demonologist.SummonDemonVisual;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

internal class DemonologistSummonAbilityHelper
{
    internal enum SummonCountType { Single, d3, d4plus1 }

    internal static void CreateSummonAbility(string guid, string name, string displayName, string description, string icon, string summonUnitID, SummonCountType countType)
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

        var action = GetSummonActions(fxSize: FxSize.Small);

        var spawnAction = ActionsBuilder.New()
            .SpawnMonsterUsingSummonPool(
                monster: summonUnitID,
                summonPool: DemonologistSummonPool.Guid,
                afterSpawn: action,
                countValue: count,
                durationValue: duration);

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
        string guid = fxSize switch
        {
            FxSize.Medium => MediumAppearBuff.Guid,
            FxSize.Big => BigAppearBuff.Guid,
            _ => SmallAppearBuff.Guid,
        };

        return ActionsBuilder.New().ApplyBuffPermanent(guid).Conditional(ConditionsBuilder.New().CasterHasFact(CallOfTheAbyssFeature.Buff.Guid),
            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(DemonSummonRageBuff.Guid).ApplyBuffPermanent(BuffRefs.StandartRageBuff.ToString())
                .RemoveBuff(toCaster: true, onlyFromCaster: true, buff: CallOfTheAbyssFeature.Buff.Guid),
            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(SummonedDemonFx.Guid));
    }
}
