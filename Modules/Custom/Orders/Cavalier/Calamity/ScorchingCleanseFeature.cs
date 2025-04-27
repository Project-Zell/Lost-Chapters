using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Calamity
{
    internal class ScorchingCleanseFeature
    {
        public static readonly string Guid = "{c4b0f11e-ee62-4860-be3e-7c7253eae4bb}";

        private static readonly string FeatureName = "ScorchingCleanse";
        private static readonly string DisplayName = "ScorchingCleanse.Name";
        private static readonly string Description = "ScorchingCleanse.Description";


        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var dispelAction = ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().CasterHasFact(Guid),
                    ifTrue: ActionsBuilder.New().DispelMagic(
                        buffType: ContextActionDispelMagic.BuffType.FromSpells,
                        checkType: RuleDispelMagic.CheckType.CasterLevel,
                        maxSpellLevel: 0,
                        countToRemove: 1,
                        oneRollForAll: false));

            AbilityConfigurator.For(AbilityRefs.CavalierChallengeAbility.ToString())
                .AddAbilityExecuteActionOnCast(actions: dispelAction)
                .Configure();
        }
    }
}
