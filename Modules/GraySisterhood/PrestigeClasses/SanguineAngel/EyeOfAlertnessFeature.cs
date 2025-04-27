using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Visual.Animation.Kingmaker.Actions;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;

internal class EyeOfAlertnessFeature
{
    public static readonly string Guid = "{0201ffec-9e6a-4fdb-9bcb-d6a4eab89a2c}";

    private static readonly string FeatureName = "EyeOfAlertness";
    private static readonly string DisplayName = "EyeOfAlertness.Name";
    private static readonly string Description = "EyeOfAlertness.Description";

    internal static void Configure()
    {
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.Alertness.ToString(), Ability.Guid])
            .AddSavingThrowBonusAgainstSchool(school: SpellSchool.Illusion, value: 4, modifierDescriptor: ModifierDescriptor.Profane)
            .AddAbilityResources(resource: Ability.ResourceGuid, restoreAmount: true)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{8825c3b9-4bc7-4c59-8dc5-cf9f929c44a5}";
        public static readonly string ResourceGuid = "{7422fc64-6113-4cd2-ad0f-db0f31409b57}";

        private static readonly string AbilityName = "EyeOfAlertness.Ability";
        private static readonly string DisplayName = "EyeOfAlertness.Ability.Name";
        private static readonly string Description = "EyeOfAlertness.Ability.Description";

        private static readonly string ResourceName = "EyeOfAlertness.Resource";

        internal static void Configure()
        {
            var resource = AbilityResourceConfigurator.New(ResourceName, ResourceGuid)
                .SetMaxAmount(builder: ResourceAmountBuilder.New(1))
                .Configure();

            var rankConfig = ContextRankConfigs.ClassLevel([SanguineAngelClass.Guid]);
            var duration = ContextDuration.Variable(ContextValues.Rank(), rate: DurationRate.Minutes);

            var diceValue = new ContextDiceValue()
            {
                DiceType = DiceType.D4,
                DiceCountValue = 1,
            };

            var applyBuff = ActionsBuilder.New()
                .ApplyBuff(BuffRefs.TrueSeeingBuff.ToString(), duration)
                .DealDamageToAbility(abilityType: StatType.Charisma, value: diceValue);
                

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(applyBuff)
                .AddAbilityResourceLogic(requiredResource: resource, isSpendResource: true, amount: 1)
                .AddContextRankConfig(rankConfig)
                .SetType(AbilityType.Supernatural)
                .SetCanTargetSelf(true)
                .SetCanTargetFriends(false)
                .SetShouldTurnToTarget(false)
                .SetIgnoreSpellResistanceForAlly(true)
                .SetCanTargetPoint(false)
                .SetRange(AbilityRange.Personal)
                .SetActionType(UnitCommand.CommandType.Swift)
                .SetAnimation(UnitAnimationActionCastSpell.CastAnimationStyle.Omni)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
