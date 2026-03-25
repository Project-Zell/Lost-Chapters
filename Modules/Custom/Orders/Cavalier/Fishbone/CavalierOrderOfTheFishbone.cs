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
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Fishbone
{
    internal class CavalierOrderOfTheFishbone
    {
        public static readonly string Guid = "{f1630ca0-7d21-45ef-a345-68c8bf3d686f}";

        private static readonly string OrderName = "CavalierOrderOfTheFishbone";
        private static readonly string DisplayName = "CavalierOrderOfTheFishbone.Name";
        private static readonly string Description = "CavalierOrderOfTheFishbone.Description";

        public static void Configure()
        {
            Challenge.Configure();
            Skills.Configure();

            PartnerInCrimeFeature.Configure();
            BoneChokeFeature.Configure();

            var sneakAttack = FeatureRefs.SneakAttack.ToString();

            var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
                .AddToLevelEntry(level: 01, features: Challenge.Guid)
                .AddToLevelEntry(level: 01, features: Skills.Guid)
                .AddToLevelEntry(level: 02, features: sneakAttack)
                .AddToLevelEntry(level: 08, features: sneakAttack)
                .AddToLevelEntry(level: 08, features: PartnerInCrimeFeature.Guid)
                .AddToLevelEntry(level: 14, features: sneakAttack)
                .AddToLevelEntry(level: 15, features: BoneChokeFeature.Guid)
                .AddToLevelEntry(level: 20, features: sneakAttack)
                .SetUIGroups(UIGroupBuilder.New()
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { Challenge.Guid, sneakAttack }))
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
            public static readonly string Guid = "{10de868e-3d3c-4629-a11d-e65b8128e040}";

            private static readonly string FeatureName = "CavalierOrderOfTheFishbone.Challenge";
            private static readonly string DisplayName = "CavalierOrderOfTheFishbone.Challenge.Name";
            private static readonly string Description = "CavalierOrderOfTheFishbone.Challenge.Description";

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
            }
        }

        internal class Buff
        {
            public static readonly string Guid = "{7f210951-f1c0-4a74-a049-f4d2fd5c298f}";

            private static readonly string BuffName = "CavalierOrderOfTheFishbone.Buff";
            private static readonly string DisplayName = "CavalierOrderOfTheFishbone.Challenge.Name";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddNotDispelable()
                    .AddComponent<OrderOfTheFishboneChallenge>()
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class Skills
        {
            public static readonly string Guid = "{f66a87da-1b6e-4283-90fe-2ef068dfbc2a}";

            private static readonly string FeatureName = "CavalierOrderOfTheFishbone.Skills";
            private static readonly string DisplayName = "CavalierOrderOfTheFishbone.Skills.Name";
            private static readonly string Description = "CavalierOrderOfTheFishbone.Skills.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddClassSkill(StatType.SkillThievery)
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
