using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;
using LostChapters.Modules.GraySisterhood.Components;
using static LostChapters.Modules.GraySisterhood.Feats.AidAnotherFeature;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon
{
    internal class CavalierOrderOfTheDragon
    {
        public static readonly string Guid = "{030d6f37-7ea3-4bbf-9e6b-570b1767acc9}";

        private static readonly string OrderName = "CavalierOrderOfTheDragon";
        private static readonly string DisplayName = "CavalierOrderOfTheDragon.Name";
        private static readonly string Description = "CavalierOrderOfTheDragon.Description";

        public static void Configure()
        {
            Challenge.Configure();
            Skills.Configure();
            ActAsOneFeature.Configure();
            AidAlliesFeature.Configure();
            StrategyFeature.Configure();

            var aidAlly = AidAlliesFeature.Guid;
            var acBonusRank = ArmorClassRank.Guid;
            var attackBonusRank = AttackRank.Guid;
            var skillCheckRank = SkillCheckRank.Guid;
            var saveRank = SaveRank.Guid;

            var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
                .AddToLevelEntry(level: 01, features: Challenge.Guid)
                .AddToLevelEntry(level: 01, features: Skills.Guid)
                .AddToLevelEntry(level: 02, features: aidAlly)
                .AddToLevelEntry(level: 02, features: acBonusRank)
                .AddToLevelEntry(level: 02, features: attackBonusRank)
                .AddToLevelEntry(level: 02, features: skillCheckRank)
                .AddToLevelEntry(level: 02, features: saveRank)
                .AddToLevelEntry(level: 08, features: StrategyFeature.FeatureGuid)
                .AddToLevelEntry(level: 08, features: aidAlly)
                .AddToLevelEntry(level: 08, features: acBonusRank)
                .AddToLevelEntry(level: 08, features: attackBonusRank)
                .AddToLevelEntry(level: 08, features: skillCheckRank)
                .AddToLevelEntry(level: 08, features: saveRank)
                .AddToLevelEntry(level: 14, features: aidAlly)
                .AddToLevelEntry(level: 14, features: acBonusRank)
                .AddToLevelEntry(level: 14, features: attackBonusRank)
                .AddToLevelEntry(level: 14, features: skillCheckRank)
                .AddToLevelEntry(level: 14, features: saveRank)
                .AddToLevelEntry(level: 15, features: ActAsOneFeature.Guid)
                .AddToLevelEntry(level: 20, features: aidAlly)
                .AddToLevelEntry(level: 20, features: acBonusRank)
                .AddToLevelEntry(level: 20, features: attackBonusRank)
                .AddToLevelEntry(level: 20, features: skillCheckRank)
                .AddToLevelEntry(level: 20, features: saveRank)
                .SetUIGroups(UIGroupBuilder.New()
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { Challenge.Guid, aidAlly }))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetClasses(CharacterClassRefs.CavalierClass.ToString())
                .Configure();

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.CavalierOrderSelection.ToString())
                .AddToAllFeatures(orderProgression)
                .Configure();
        }

        internal class Challenge
        {
            public static readonly string Guid = "{329217f2-efbf-41b7-92f4-bd45562787a8}";

            private static readonly string FeatureName = "CavalierOrderOfTheDragon.Challenge";
            private static readonly string DisplayName = "CavalierOrderOfTheDragon.Challenge.Name";
            private static readonly string Description = "CavalierOrderOfTheDragon.Challenge.Description";

            internal static void Configure()
            {
                Buff.Configure();

                FeatureConfigurator.New(FeatureName, Guid)
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();

                var applyBuff = ActionsBuilder.New()
                    .Conditional(
                        ConditionsBuilder.New().CasterHasFact(Guid),
                        ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: Buff.Guid));

                AbilityConfigurator.For(AbilityRefs.CavalierChallengeAbility.ToString())
                    .AddAbilityExecuteActionOnCast(actions: applyBuff)
                    .Configure();

                AbilityConfigurator.For(HalfheartedChallengeFeature.Ability.Guid)
                    .AddAbilityExecuteActionOnCast(actions: applyBuff)
                    .Configure();
            }
        }

        internal class Buff
        {
            public static readonly string Guid = "{e27d353c-7b14-4c09-a507-c79ea796b0c3}";

            private static readonly string BuffName = "CavalierOrderOfTheDragon.Challenge.Buff";
            private static readonly string DisplayName = "CavalierOrderOfTheDragon.Challenge.Name";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddNotDispelable()
                    .AddComponent<OrderOfTheDragonChallenge>()
                    .AddToFlags(BlueprintBuff.Flags.HiddenInUi)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class Skills
        { 
            public static readonly string Guid = "{87887f1f-b065-4b03-baaa-ca3a67901619}";

            private static readonly string FeatureName = "CavalierOrderOfTheDragon.Skills";
            private static readonly string DisplayName = "CavalierOrderOfTheDragon.Skills.Name";
            private static readonly string Description = "CavalierOrderOfTheDragon.Skills.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddClassSkill(StatType.SkillPerception)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIsClassFeature(true)
                    .Configure();
            }
        }
    }
}
