using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class RatSwarmFeature
{
    public static readonly string Guid = "{9e17b13d-0c83-452d-ba95-28acb70f780b}";

    private static readonly string FeatureName = "RatSwarm";
    private static readonly string DisplayName = "RatSwarm.Name";
    private static readonly string Description = "RatSwarm.Description";

    //private static readonly string Icon = $"{CustomModule.IconPath}/ratswarm.png";
    internal static void Configure()
    {
        Ability.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Ability.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{d9fc941f-63e7-4383-adfa-a4bf09e6b216}";

        private static readonly string AbilityName = "RatSwarm.Ability";

        internal static void Configure()
        {
            Unit.Configure();

            var monsterCount = new ContextDiceValue()
            {
                DiceType = DiceType.D3,
                DiceCountValue = 1,
                BonusValue = 0,
            };

            var action = ActionsBuilder.New().SpawnMonster(
                monster: Unit.Guid,
                countValue: monsterCount,
                durationValue: ContextDuration.Fixed(value: 1, rate: DurationRate.Minutes));

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Unit
    {
        public static readonly string Guid = "{8f885d64-4268-48e6-b656-bebaf938b28d}";

        private static readonly string UnitName = "RatSwarm.Unit";

        internal static void Configure()
        {
            var basicFeatSelection = BlueprintTool.GetRef<BlueprintFeatureSelectionReference>(FeatureSelectionRefs.BasicFeatSelection.ToString());

            UnitConfigurator.New(UnitName, Guid)
                .CopyFrom(UnitRefs.CR2_RatSwarm_DLC2)
                .AddFacts([FeatureRefs.Dodge.ToString(), FeatureRefs.Toughness.ToString()])
                .AddBuffOnEntityCreated(BuffRefs.SummonedCreatureVisual.ToString())
                .AddBuffOnEntityCreated(BuffRefs.Unlootable.ToString())
                .AddClassLevels(
                    characterClass: CharacterClassRefs.AnimalClass.ToString(),
                    levels: 10,
                    raceStat: StatType.Constitution)
                .SetDisplayName("PlagueRat")
                .Configure();   
        }
    }
}
