using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Components;
using UnityEngine;
using static LostChapters.Modules.GraySisterhood.Revelations.OracleSuccorMysteryFeature;

namespace LostChapters.Modules.GraySisterhood.Revelations.Succor;

internal class CurseOfDampeningRevelation
{
    public static readonly string Guid = "{daf881b7-afe2-4334-81a2-75818cb12204}";

    private static readonly string FeatureName = "CurseOfDampening";
    private static readonly string DisplayName = "CurseOfDampening.Name";
    private static readonly string Description = "CurseOfDampening.Description";

    public static void Configure()
    {
        Buff.Configure();
        Resource.Configure();
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.OracleRevelation)
            .AddFacts([Ability.Guid])
            .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
            .AddPrerequisiteClassLevel(characterClass: CharacterClassRefs.OracleClass.ToString(), level: 7)
            .AddPrerequisiteFeaturesFromList(
                amount: 1, 
                features: [OracleSuccorMysteryFeature.Guid, DivineHerbalistVariation.Guid, EnlightenedPhilosopherVariation.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{e106ee3e-d3c6-4c27-9253-b8660dae81ef}";

        private static readonly string AbilityName = "CurseOfDampening.Ability";
        private static readonly string DisplayName = "CurseOfDampening.Ability.Name";
        private static readonly string Description = "CurseOfDampening.Ability.Description";

        private static readonly Sprite Icon = BuffRefs.WitchHexVulnerabilityCurseBuff.Reference.Get().Icon;

        internal static void Configure()
        {
            var contextValue = ContextValues.Rank(AbilityRankType.Default);
            var rankConfig = ContextRankConfigs.ClassLevel(
                type: AbilityRankType.Default,
                classes: [CharacterClassRefs.OracleClass.ToString()],
                min: 1, max: 10).WithDivStepProgression(2);

            var contexDuration = ContextDuration.Variable(contextValue);

            var action = ActionsBuilder.New().SavingThrow(SavingThrowType.Will,
                onResult: ActionsBuilder.New().ConditionalSaved(
                    succeed: ActionsBuilder.New().ApplyBuff(Buff.Guid, contexDuration)).Build());

            AbilityConfigurator.New(AbilityName, Guid)
                .SetIcon(Icon)
                .AddAbilityEffectRunAction(action)
                .AddContextRankConfig(rankConfig)
                .AddAbilityResourceLogic(isSpendResource: true, requiredResource: Resource.Guid, amount: 1)
                .AllowTargeting(point: false, enemies: true, friends: true, self: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{1717ea4b-6309-45d0-8750-163ade57609f}";

        private static readonly string BuffName = "CurseOfDampening.Buff";
        private static readonly string DisplayName = "CurseOfDampening.Buff.Name";
        private static readonly string Description = "CurseOfDampening.Buff.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<CurseOfDampening>()
                .AddSpellDescriptorComponent(descriptor: SpellDescriptor.Curse | SpellDescriptor.MindAffecting)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{7bc1364c-a1e2-4e37-8d0f-0d5970ebca9a}";

        private static readonly string ResourceName = "CurseOfDampening.Resource";

        internal static void Configure()
        {
            var resourceAmount = ResourceAmountBuilder.New(1)
                .IncreaseByLevelStartPlusDivStep(
                    classes: [CharacterClassRefs.OracleClass.ToString()],
                    startingLevel: 11,
                    startingBonus: 1,
                    levelsPerStep: 5,
                    bonusPerStep: 1)
                .Build();

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(resourceAmount)
                .Configure();
        }
    }
}
