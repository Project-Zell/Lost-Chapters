using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using UnityEngine;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class AuraOfLawFeature
{
    public static readonly string Guid = "{354bc8ea-ccdf-413c-bd70-6600dc58f7ca}";

    private static readonly string FeatureName = "";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .AddFacts([Ability.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{0e714f63-f965-49e4-ba96-66fe41a4af45}";

        private static readonly string AbilityName = "";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        private static readonly Sprite Icon = AbilityRefs.Command.Reference.Get().Icon;

        internal static void Configure()
        {
            Buff.Configure();

            var buffDuration = ContextDuration.Fixed(1, DurationRate.Minutes);
            var action = ActionsBuilder.New().Conditional(conditions: 
                ConditionsBuilder.New().Alignment(AlignmentComponent.Chaotic).HasBuff(Buff.Guid, negate: true),
                    ifTrue: ActionsBuilder.New().ApplyBuff(Buff.Guid, durationValue: buffDuration));

            var damageValue = ContextDice.Value(diceType: DiceType.Zero, bonus: ContextValues.Rank(type: AbilityRankType.DamageBonus));
            var damageConfig = ContextRankConfigs.ClassLevel(
                    type: AbilityRankType.DamageBonus,
                    classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()]);

            var attackValue = ContextDice.Value(diceType: DiceType.Zero, bonus: ContextValues.Rank(type: AbilityRankType.StatBonus));
            var attackConfig = ContextRankConfigs.StatBonus(type: AbilityRankType.StatBonus, stat: StatType.Charisma);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AddContextCalculateSharedValue(value: damageValue, valueType: AbilitySharedValue.DamageBonus)
                .AddContextCalculateSharedValue(value: attackValue, valueType: AbilitySharedValue.StatBonus)
                .AddContextRankConfig(damageConfig)
                .AddContextRankConfig(attackConfig)
                .AddAbilityResourceLogic(requiredResource: AbilityResourceRefs.SmiteChaosResource.ToString(), isSpendResource: true, amount: 2)
                .AddAbilitySpawnFx(prefabLink: "6e799a804a9ce4044a70eba38890cf5a", anchor: AbilitySpawnFxAnchor.SelectedTarget)
                .SetType(AbilityType.Supernatural)
                .SetRange(AbilityRange.Medium)
                .SetCanTargetEnemies(true)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Immediate)
                .SetEffectOnEnemy(AbilityEffectOnUnit.Harmful)
                .SetActionType(UnitCommand.CommandType.Swift)
                .AddToResourceAssetIds(["6e799a804a9ce4044a70eba38890cf5a", "5b4cdc22715305949a1bd80fab08302b"])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{382ae553-2c0e-45b7-b83b-ec984e4f14e1}";

        private static readonly string BuffName = "";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";
        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackBonusAgainstTarget(
                    value: ContextValues.Shared(AbilitySharedValue.StatBonus),
                    checkCaster: false,
                    checkCasterFriend: true,
                    descriptor: ModifierDescriptor.UntypedStackable)
                .AddACBonusAgainstTarget(
                    value: ContextValues.Shared(AbilitySharedValue.StatBonus),
                    checkCaster: false,
                    checkCasterFriend: true,
                    descriptor: ModifierDescriptor.Deflection)
                .AddDamageBonusAgainstTarget(
                    value: ContextValues.Shared(AbilitySharedValue.DamageBonus),
                    checkCaster: false,
                    checkCasterFriend: true,
                    applyToSpellDamage: true)
                .AddIgnoreTargetDR(checkCasterFriend: true)
                .AddUniqueBuff()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetFxOnStart("5b4cdc22715305949a1bd80fab08302b")
                .Configure();
        }
    }
}
