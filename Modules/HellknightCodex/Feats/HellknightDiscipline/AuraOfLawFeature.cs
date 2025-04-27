using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class AuraOfLawFeature
    {
        private static readonly string FeatName = "AuraOfLaw";
        private static readonly string FeatGuid = "ec105e11-103d-42ef-88aa-d03f2480fbd8";
        private static readonly string FeatDisplayName = "AuraOfLaw.BuffName";
        private static readonly string FeatDescription = "AuraOfLaw.LocalizedDescription";

        private static readonly string AbilityName = "AuraOfLaw.Ability";
        private static readonly string AbilityGuid = "ae47af67-db78-4388-ba55-d840c1d6946e";
        private static readonly string AbilityDisplayName = "AuraOfLaw.Ability.BuffName";
        private static readonly string AbilityDescription = "AuraOfLaw.Ability.LocalizedDescription";
        private static readonly string AbilityDuration = "AuraOfLaw.Ability.Duration";

        private static readonly string BuffName = "AuraOfLaw.EnchantGuid";
        private static readonly string BuffGuid = "4e87bee9-58e2-4d91-a585-b2218224b6c4";
        private static readonly string BuffDisplayName = "AuraOfLaw.EnchantGuid.BuffName";
        private static readonly string BuffDescription = "AuraOfLaw.EnchantGuid.LocalizedDescription";

        public static void Configure()
        {
            var buff = BuffConfigurator.New(BuffName, BuffGuid)
                .AddDamageBonusAgainstTarget(
                    value: ContextValues.Shared(AbilitySharedValue.DamageBonus),
                    checkCaster: false,
                    checkCasterFriend: true,
                    applyToSpellDamage: true)
                .AddUniqueBuff()
                .SetDisplayName(BuffDisplayName)
                .SetDescription(BuffDescription)
                .SetFxOnStart("5b4cdc22715305949a1bd80fab08302b")
                .Configure();

            var buffDuration = ContextDuration.Fixed(1, DurationRate.Minutes);

            var action = ActionsBuilder.New().ApplyBuff(BuffGuid, durationValue: buffDuration);

            var ability = AbilityConfigurator.New(AbilityName, AbilityGuid)
                .AddAbilityEffectRunAction(action)
                .AddContextCalculateSharedValue(
                    valueType: AbilitySharedValue.DamageBonus,
                    modifier: 2,
                    value: ContextDice.Value(
                        diceType: DiceType.Zero,
                        bonus: ContextValues.Rank(type: AbilityRankType.DamageBonus)))
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(
                    type: AbilityRankType.DamageBonus,
                    classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()]))
                .AddAbilityResourceLogic(requiredResource: AbilityResourceRefs.SmiteChaosResource.ToString(), isSpendResource: true, amount: 2)

                .AddAbilitySpawnFx(prefabLink: "6e799a804a9ce4044a70eba38890cf5a", anchor: AbilitySpawnFxAnchor.SelectedTarget)
                .SetDisplayName(AbilityDisplayName)
                .SetDescription(AbilityDescription)
                .SetIcon(AbilityRefs.Command.Reference.Get().Icon)
                .SetType(AbilityType.Supernatural)
                .SetRange(AbilityRange.Medium)
                .SetCanTargetEnemies(true)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Immediate)
                .SetEffectOnEnemy(AbilityEffectOnUnit.Harmful)
                .SetActionType(UnitCommand.CommandType.Swift)
                .AddToResourceAssetIds(["6e799a804a9ce4044a70eba38890cf5a", "5b4cdc22715305949a1bd80fab08302b"])
                .Configure();

            FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddFacts([ability])
                .SetDisplayName(FeatDisplayName)
                .SetDescription(FeatDescription)
                .Configure();
        }
    }
}
