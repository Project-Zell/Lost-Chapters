using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class HellknightObidienceFeature
{
    public static readonly string Guid = "{d62500b5-4753-4cee-b2b7-e6b37de8bac8}";

    private static readonly string FeatureName = "HellknightObidienceFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(feature: HellknightOrderSelectionFeature.Guid)
            .AddPrerequisiteFullStatValue(stat: StatType.SkillKnowledgeArcana, value: 2)
            .AddFacts(facts: [Ability.Guid])
            .AddAbilityResources(resource: AbilityResource.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{710ba0a0-068f-40be-a5e2-270c6b1ebdca}";

        private static readonly string AbilityName = "ReconingAbility";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";
        
        private static readonly string AbilityDuration = $"{AbilityName}.Duration";

        public static void Configure()
        {
            AbilityResource.Configure();
            Buff.Configure();

            var icon = FeatureRefs.SternGaze.Reference.Get().Icon;

            var duration = ContextDuration.VariableDice(
                diceType: DiceType.One,
                rate: DurationRate.Minutes,
                diceCount: ContextValues.Constant(10),
                bonus: ContextValues.Rank());

            var action = ActionsBuilder.New()
                .ApplyBuff(buff: Buff.Guid, durationValue: duration, asChild: true, isNotDispelable: true)
                .ApplyBuffWithDurationSeconds(BuffRefs.Bleed1d6Buff.ToString(), 30);

            var config = ContextRankConfigs
                .ClassLevel(classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()],min: 0, max: 50)
                .WithMultiplyByModifierProgression(5);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(actions: action)
                .AddAbilityResourceLogic(requiredResource: AbilityResource.Guid, isSpendResource: true)
                .AddContextRankConfig(config)
                .AddAbilityCasterNotPolymorphed()
                .SetType(AbilityType.Special)
                .SetRange(AbilityRange.Personal)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.SelfTouch)
                .AllowTargeting(self: true)
                .AddAbilitySpawnFx(prefabLink: "cbfe312cb8e63e240a859efaad8e467c")
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetLocalizedDuration(AbilityDuration)
                .SetIcon(icon)
                .Configure();
        }
    }

    internal class AbilityResource
    {
        public static readonly string Guid = "{80b6a180-06b4-45a6-818a-7bac9b026ca1}";

        private static readonly string ResourceName = "ReconingAbility.Resource";

        public static void Configure()
        {
            var resourceAmount = ResourceAmountBuilder.New(1)
                .IncreaseByLevelStartPlusDivStep(
                    bonusPerStep: 1,
                    levelsPerStep: 5,
                    classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
                .Build();

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(maxAmount: resourceAmount)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{fd2e3d83-5aa5-4ca0-a044-c24624570cb1}";

        private static readonly string BuffName    = "Reconing.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
