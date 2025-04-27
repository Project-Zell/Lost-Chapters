using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Commands.Base;

namespace LostChapters.Modules.GraySisterhood.Feats
{
    internal class IntimidatingGlareFeature
    {
        private static readonly string FeatName = "IntimidatingGlare";
        private static readonly string FeatGuid = "bbae4835-10ac-4ee8-afb9-310d0e8883ce";
        private static readonly string FeatDisplayName = "IntimidatingGlare.Enchantment.BuffName";
        private static readonly string FeatDescription = "IntimidatingGlare.Enchantment.LocalizedDescription";

        private static readonly string AbilityName = "IntimidatingGlare.Ability";
        private static readonly string AbilityGuid = "355247de-dd1a-4313-a312-60eeeb776a75";
        private static readonly string AbilityDisplayName = "IntimidatingGlare.Ability.BuffName";
        private static readonly string AbilityDescription = "IntimidatingGlare.Ability.LocalizedDescription";

        public static void Configure()
        {
            var action = ActionsBuilder.New()
                .Conditional(conditions: ConditionsBuilder.New().IsEnemy().HasBuff(buff: BuffRefs.BlindnessBuff.Reference.Get(), negate: true),
                ifTrue: ActionsBuilder.New().SavingThrow(type: SavingThrowType.Will, customDC: 12,
                    onResult: ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(
                        buff: BuffRefs.ParalyzedMindAffecting.Reference.Get(),
                        durationValue: ContextDuration.Fixed(1),
                        asChild: true))));

            var ability = AbilityConfigurator.New(AbilityName, AbilityGuid)
                .CopyFrom(AbilityRefs.PersuasionUseAbility,
                    typeof(AbilityEffectRunAction))
                .AdditionalAbilityEffectRunActionOnClickedTarget(action)
                .SetActionType(UnitCommand.CommandType.Swift)
                .SetIcon(FeatureRefs.SternGaze.Reference.Get().Icon)
                .SetDisplayName(AbilityName)
                .SetDescription(AbilityDescription)
                .Configure();

            FeatureConfigurator.New(FeatName, FeatGuid, FeatureGroup.Feat)
                .AddPrerequisiteFullStatValue(stat: StatType.CheckIntimidate, value: 3)
                .AddFacts(facts: [ability])
                .SetIsClassFeature(true)
                .SetDisplayName(FeatDisplayName)
                .SetDescription(FeatDescription)
                .Configure();
        }
    }
}
