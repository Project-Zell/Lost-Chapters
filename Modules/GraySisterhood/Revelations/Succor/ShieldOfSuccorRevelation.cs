using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Mechanics;
using static LostChapters.Modules.GraySisterhood.Revelations.OracleSuccorMysteryFeature;

namespace LostChapters.Modules.GraySisterhood.Revelations.Succor;

internal class ShieldOfSuccorRevelation
{
    public static readonly string Guid = "{2c174cfb-c7a6-4be1-b0c0-189d9d3c033f}";

    private static readonly string FeatureName = "ShieldOfSuccor";
    private static readonly string DisplayName = "ShieldOfSuccor.Name";
    private static readonly string Description = "ShieldOfSuccor.Description";

    public static void Configure()
    {
        Buff.Configure();
        Resource.Configure();
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid, Kingmaker.Blueprints.Classes.FeatureGroup.OracleRevelation)
            .AddFacts([Ability.Guid])
            .AddPrerequisiteClassLevel(characterClass: CharacterClassRefs.OracleClass.ToString(), level: 3)
            .AddPrerequisiteFeaturesFromList(
                amount: 1,
                features: [OracleSuccorMysteryFeature.Guid, DivineHerbalistVariation.Guid, EnlightenedPhilosopherVariation.Guid])
            .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{9236703c-152d-452c-8d7f-d2daec91226d}";

        private static readonly string AbilityName = "ShieldOfSuccor.Ability";
        private static readonly string DisplayName = "ShieldOfSuccor.Ability.Name";
        private static readonly string Description = "ShieldOfSuccor.Ability.Description";

        internal static void Configure()
        {
            var durationConfig = ContextRankConfigs.ClassLevel(
                type: AbilityRankType.Default,
                classes: [CharacterClassRefs.OracleClass.ToString()],
                min: 1, max: 20);

            var durationValue = ContextValues.Rank(AbilityRankType.Default);
            var contexDuration = ContextDuration.Variable(durationValue, DurationRate.Minutes);
            var action = ActionsBuilder.New().ApplyBuff(Buff.Guid, contexDuration).Build();

            AbilityConfigurator.New(AbilityName, Guid)
                .SetIcon(BuffRefs.WitchHexVulnerabilityCurseBuff.Reference.Get().Icon)
                //.AddComponent<CurseOfDampeningDC>()
                .AddAbilityEffectRunAction(action)
                .AddContextRankConfig(durationConfig)
                .AddAbilityResourceLogic(isSpendResource: true, requiredResource: Resource.Guid, amount: 1)
                .AllowTargeting(point: false, enemies: true, friends: true, self: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{365a8ccd-ba4a-4df0-a9c6-415806d2e65d}";


        private static readonly string BuffName = "ShieldOfSuccor.Buff";
        private static readonly string DisplayName = "ShieldOfSuccor.Buff.Name";
        private static readonly string Description = "ShieldOfSuccor.Buff.Description";

        internal static void Configure()
        {
            var contextValue = ContextValues.Shared(AbilitySharedValue.Heal);
            var rankConfigCharisma = ContextRankConfigs.StatBonus(stat: StatType.Charisma, type: AbilityRankType.StatBonus);
            var rankConfigOracleLevel = ContextRankConfigs.ClassLevel(
                classes: [CharacterClassRefs.OracleClass.ToString()],
                type: AbilityRankType.DamageBonus,
                max: 20).WithDiv2Progression();

            var dice = new ContextDiceValue()
            {
                DiceType = DiceType.D6,
                DiceCountValue = ContextValues.Rank(AbilityRankType.DamageBonus),
                BonusValue = ContextValues.Rank(AbilityRankType.StatBonus)
            };

            BuffConfigurator.New(BuffName, Guid)
                .AddTemporaryHitPointsFromAbilityValue(
                    value: contextValue,
                    descriptor: ModifierDescriptor.None,
                    removeWhenHitPointsEnd: true)
                .AddContextRankConfig(rankConfigCharisma)
                .AddContextRankConfig(rankConfigOracleLevel)
                .AddContextCalculateSharedValue(
                    valueType: AbilitySharedValue.Heal,
                    value: dice,
                    modifier: 1)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{abe9d6dc-1400-4611-bb86-f25632d01b52}";

        private static readonly string ResourceName = "ShieldOfSuccor.Resource";
        private static readonly string DisplayName = "ShieldOfSuccor.Resource.Name";
        private static readonly string Description = "ShieldOfSuccor.Resource.Description";

        internal static void Configure()
        {
            var resourceAmount = ResourceAmountBuilder.New(1)
            .IncreaseByLevelStartPlusDivStep(
                classes: [CharacterClassRefs.OracleClass.ToString()],
                startingLevel: 11,
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
