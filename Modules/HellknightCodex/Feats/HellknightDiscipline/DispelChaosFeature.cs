using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic.Mechanics.Actions;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class DispelChaosFeature
    {
        public static readonly string Guid = "0fd1bcfe-f073-43b2-93a8-4008f8160cd3";

        private const string FeatName = "DispelChaos";
        private const string DisplayName = "DispelChaos.BuffName";
        private const string Description = "DispelChaos.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddPrerequisiteFeature(FeatureRefs.SmiteChaosFeature.ToString())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var dispelAction = ActionsBuilder.New()
                .Conditional(
                    ConditionsBuilder.New().CasterHasFact(Guid).Alignment(AlignmentComponent.Chaotic),
                    ifTrue: ActionsBuilder.New().DispelMagic(
                        buffType: ContextActionDispelMagic.BuffType.FromSpells,
                        checkType: RuleDispelMagic.CheckType.CasterLevel,
                        maxSpellLevel: 0,
                        countToRemove: 3,
                        oneRollForAll: false))
                .Build();

            AbilityConfigurator.For(AbilityRefs.SmiteChaosAbility.ToString())
                .AddAbilityExecuteActionOnCast(actions: dispelAction)
                .Configure();
        }
    }
}
