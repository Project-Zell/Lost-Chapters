using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic;
using LostChapters.Modules.GraySisterhood.Components;
using UnityEngine;
using static LostChapters.Modules.GraySisterhood.Revelations.OracleSuccorMysteryFeature;

namespace LostChapters.Modules.GraySisterhood.Revelations.Succor;

internal class PitifulFoeRevelation
{
    public static readonly string Guid = "{41b55c52-3b61-45ad-9525-e082b8118af8}";

    private static readonly string FeatureName = "PitifulFoeRevelation";
    private static readonly string DisplayName = "PitifulFoeRevelation.Name";
    private static readonly string Description = "PitifulFoeRevelation.Description";

    public static void Configure()
    {
        Buff.Configure();
        Resource.Configure();
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid, Kingmaker.Blueprints.Classes.FeatureGroup.OracleRevelation)
            .AddFacts([Ability.Guid])
            .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
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
        public static readonly string Guid = "{b1532263-7ddb-4af4-9eb4-06a6b1bc8986}";

        private static readonly string AbilityName = "PitifulFoeRevelation.Ability";
        private static readonly string DisplayName = "PitifulFoeRevelation.Ability.Name";
        private static readonly string Description = "PitifulFoeRevelation.Ability.Description";

        private static readonly Sprite Icon = BuffRefs.WitchHexVulnerabilityCurseBuff.Reference.Get().Icon;

        internal static void Configure()
        {
            var rankConfig = ContextRankConfigs.ClassLevel(
                type: AbilityRankType.Default,
                classes: [CharacterClassRefs.OracleClass.ToString()],
                min: 1, max: 10).WithDivStepProgression(2);
            var contextValue = ContextValues.Rank(AbilityRankType.Default);

            var contexDuration = ContextDuration.Variable(contextValue);
            var action = ActionsBuilder.New().SavingThrow(SavingThrowType.Will,
                onResult: ActionsBuilder.New().ConditionalSaved(
                    succeed: ActionsBuilder.New().ApplyBuff(Buff.Guid, contexDuration)).Build());

            AbilityConfigurator.New(AbilityName, Guid)
                //.AddComponent<CurseOfDampeningDC>()
                .AddAbilityEffectRunAction(action)
                .AddContextRankConfig(rankConfig)
                .AddAbilityResourceLogic(isSpendResource: true, requiredResource: Resource.Guid, amount: 1)
                .AllowTargeting(point: false, enemies: true, friends: true, self: true)
                .SetIcon(Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{ef228d44-71dc-49de-80c7-384a47acddbd}";

        private static readonly string BuffName = "PitifulFoeRevelation.Buff";
        private static readonly string DisplayName = "PitifulFoeRevelation.Buff.Name";
        private static readonly string Description = "PitifulFoeRevelation.Buff.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddCondition(UnitCondition.DisableAttacksOfOpportunity)
                .AddModifyD20(
                    rule: RuleType.AttackRoll | RuleType.SavingThrow,
                    rollsAmount: 1,
                    takeBest: false)
                .AddComponent<InitiatorCritAutofail>()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{6fa7b2a5-fe98-423b-a827-0949af02852b}";

        private static readonly string ResourceName = "PitifulFoeRevelation.Resource";
        private static readonly string DisplayName = "PitifulFoeRevelation.Resource.Name";
        private static readonly string Description = "PitifulFoeRevelation.Resource.Description";

        internal static void Configure()
        {
            var resourceAmount = ResourceAmountBuilder.New(1)
                .IncreaseByLevelStartPlusDivStep(
                    classes: [CharacterClassRefs.OracleClass.ToString()],
                    startingLevel: 7,
                    startingBonus: 1,
                    levelsPerStep: 8,
                    bonusPerStep: 1)
                .Build();

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(resourceAmount)
                .Configure();
        }
    }
}
