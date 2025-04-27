using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class HellknightObidienceFeature
    {
        public static readonly string Guid = "233b99e1-4f9c-445f-8501-5c9d6c0ab215";

        private static readonly string FeatName = "HellknightObidience";
        private static readonly string DisplayName = "HellknightObidience.BuffName";
        private static readonly string Description = "HellknightObidience.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddPrerequisiteFeature(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
                .AddPrerequisiteFullStatValue(stat: StatType.SkillKnowledgeArcana, value: 3)
                .AddFacts(facts: [HellknightObidienceAbility.CreateAbility()])
                .AddAbilityResources(resource: HellknightObidienceAbilityResource.Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class HellknightObidienceBuff
    {
        public static readonly string Guid = "01495d90-8a4a-4e0f-8a5c-888bbcc80cc0";

        private const string BuffName = "Hellknight.Reconing.EnchantGuid";
        private const string BuffDisplayName = "Hellknight.Reconing.EnchantGuid.BuffName";
        private const string BuffDescription = "Hellknight.Reconing.EnchantGuid.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        internal static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddContextRankConfig(
                    ContextRankConfigs.ClassLevel(type: Kingmaker.Enums.AbilityRankType.StatBonus,
                        classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
                    .WithCustomProgression((4, 2), (9, 4), (10, 6)))
                .SetDisplayName(BuffDisplayName)
                .SetDescription(BuffDescription)
                .Configure();
        }
    }

    internal class HellknightObidienceAbility
    {
        public static readonly string Guid = "34edf77f-c2be-4b8b-9388-05469020ea5d";

        private const string AbilityName = "Hellknight.Reconing";
        private const string AbilityDisplayName = "Hellknight.Reconing.BuffName";
        private const string AbilityDescription = "Hellknight.Reconing.LocalizedDescription";
        private const string AbilityDuration = "Hellknight.Reconing.Duration";

        public static BlueprintAbility CreateAbility()
        {
            var icon = FeatureRefs.SternGaze.Reference.Get().Icon;

            var duration = ContextDuration.VariableDice(
                diceType: DiceType.One,
                rate: DurationRate.Minutes,
                diceCount: ContextValues.Constant(10),
                bonus: ContextValues.Rank());

            var rankConfig = ContextRankConfigs.ClassLevel(
                classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()],
                max: 10)
                .WithMultiplyByModifierProgression(5);

            var buffAction = ActionsBuilder.New()
                .ApplyBuff(HellknightObidienceBuff.GetReference(), durationValue: duration)
                .ApplyBuffWithDurationSeconds(BuffRefs.Bleed1d6Buff.ToString(), 30)
                .Build();

            return AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(buffAction)
                .AddContextRankConfig(rankConfig)
                .AddAbilityResourceLogic(requiredResource: HellknightObidienceAbilityResource.CreateAbilityResource(), isSpendResource: true)
                .AddAbilityCasterNotPolymorphed()
                .SetType(AbilityType.Special)
                .SetRange(AbilityRange.Personal)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.SelfTouch)
                .AllowTargeting(self: true)
                .AddAbilitySpawnFx(prefabLink: "cbfe312cb8e63e240a859efaad8e467c")
                .SetLocalizedDuration(AbilityDuration)
                .SetDisplayName(AbilityDisplayName)
                .SetDescription(AbilityDescription)
                .SetIcon(icon)
                .Configure();
        }
    }

    internal class HellknightObidienceAbilityResource
    {
        public static readonly string Guid = "6ecf5a61-31a3-42e2-86c2-f587e160a033";

        private const string AbilityResourceName = "Hellknight.Reconing.resource";

        public static BlueprintAbilityResource CreateAbilityResource()
        {
            var resourceAmount = ResourceAmountBuilder.New(1)
                .IncreaseByLevelStartPlusDivStep(
                    bonusPerStep: 1,
                    levelsPerStep: 5,
                    classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
                .Build();

            return AbilityResourceConfigurator.New(AbilityResourceName, Guid)
                .SetMaxAmount(maxAmount: resourceAmount)
                .Configure();
        }
    }
}
