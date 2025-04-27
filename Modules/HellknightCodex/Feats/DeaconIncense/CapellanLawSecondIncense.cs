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
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class CapellanLawSecondIncense
    {
        public static readonly string Guid = "929ab44a-f009-4f09-8834-96e347db8a16";

        private const string IncenseName = "LawSecondIncense";
        private const string DisplayName = "LawSecondIncense.BuffName";
        private const string Description = "LawSecondIncense.LocalizedDescription";

        public static void Configure()
        {
            var duration = ContextDuration.VariableDice(diceType: DiceType.D3, diceCount: 2);
            var applyBuff = ActionsBuilder.New().ApplyBuff(buff: BuffRefs.IncenseFogSickenedBuff.ToString(), durationValue: duration);
            var hasAbility = ConditionsBuilder.New().CasterHasFact(Guid);
            var enemyIsChaotic = ConditionsBuilder.New().IsEnemy().Alignment(AlignmentComponent.Chaotic);
            var isEmpowered = ConditionsBuilder.New().CasterHasFact(Deacon.FeatGuid);

            var action = ActionsBuilder.New().Conditional(hasAbility,
                    ifTrue: ActionsBuilder.New().Conditional(enemyIsChaotic,
                        ifTrue: ActionsBuilder.New().Conditional(isEmpowered,
                            ifTrue: applyBuff,
                            ifFalse: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude,
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
