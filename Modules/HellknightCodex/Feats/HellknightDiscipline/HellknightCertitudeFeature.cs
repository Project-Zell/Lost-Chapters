using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.Utility;
using Kingmaker.RuleSystem;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class HellknightCertitudeFeature
    {
        public static readonly string FeatGuid = "72b2bd3f-898a-448f-bf22-7e6648a08e1c";

        private const string FeatName = "HellknightCertitude";
        private const string FeatIcon = "";
        private const string DisplayName = "HellknightCertitude.BuffName";
        private const string Description = "HellknightCertitude.LocalizedDescription";

        private const string CooldownBuffGuid = "";
        private const string CooldownBuffName = "";

        private const string AbilityGuid = "";
        private const string AbilityName = "";

        public static void Configure()
        {
            var cooldownBuff = BuffConfigurator.New(CooldownBuffName, CooldownBuffGuid)
                .Configure();

            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuff(BuffRefs.Shaken.ToString()),
                ifTrue: ActionsBuilder.New().SavingThrow(type: SavingThrowType.Will, onResult: ActionsBuilder.New()
                    .ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(
                        buff: BuffRefs.Shaken.ToString(),
                        durationValue: ContextDuration.VariableDice(DiceType.D6, diceCount: 1)))),
                ifFalse: ActionsBuilder.New().SavingThrow(type: SavingThrowType.Will, onResult: ActionsBuilder.New()
                    .ConditionalSaved(failed: ActionsBuilder.New().ApplyBuffPermanent(
                        buff: BuffRefs.Prone.ToString()))));

            var ability = AbilityConfigurator.New(AbilityGuid, AbilityName)
                .AddAbilityEffectRunAction(action)
                .AddAbilityTargetsAround(radius: 10.Feet(), targetType: TargetType.Enemy)
                .Configure();

            var trigger = ActionsBuilder.New().Conditional(ConditionsBuilder.New().HasBuff(cooldownBuff),
                ifFalse: ActionsBuilder.New().ApplyBuff(cooldownBuff, ContextDuration.Fixed(1)).OnContextCaster(ActionsBuilder.New().CastSpell(ability)));

            FeatureConfigurator.New(FeatName, FeatGuid)
                .AddTargetSavingThrowTrigger(onlyPass: true)
                .SetIsClassFeature(true)
                .SetIcon(FeatIcon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
