using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Properties;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using System.Collections.Generic;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class CapellanChaosSecondIncense
    {
        public static readonly string Guid = "8d0bb5e1-f203-49ad-9671-7d6aba621b91";

        private const string IncenseName = "ChaosSecondIncense";
        private const string DisplayName = "ChaosSecondIncense.BuffName";
        private const string Description = "ChaosSecondIncense.LocalizedDescription";

        public static void Configure()
        {
            var duration = ContextDuration.VariableDice(diceType: DiceType.D3, diceCount: 2);
            var applyBuff = ActionsBuilder.New().ApplyBuff(buff: BuffRefs.IncenseFogSickenedBuff.ToString(), durationValue: duration);
            var hasAbility = ConditionsBuilder.New().CasterHasFact(Guid);
            var enemyIsChaotic = ConditionsBuilder.New().IsEnemy().Alignment(AlignmentComponent.Chaotic);
            var isEmpowered = ConditionsBuilder.New().CasterHasFact(Deacon.FeatGuid);

            List<(ConditionsBuilder conditions, ContextValue modifier)> dcModifiers =
                [(ConditionsBuilder.New(), ContextValues.Property(UnitProperty.StatBonusWisdom, true))];

            var action = ActionsBuilder.New().Conditional(hasAbility,
                    ifTrue: ActionsBuilder.New().Conditional(enemyIsChaotic,
                        ifTrue: ActionsBuilder.New().Conditional(isEmpowered,
                            ifTrue: applyBuff,
                            ifFalse: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude, conditionalDCModifiers: dcModifiers,
                                onResult: ActionsBuilder.New().ConditionalSaved(
                                    failed: applyBuff)))));

            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectRunAction(unitEnter: action)
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

        }
    }
}
