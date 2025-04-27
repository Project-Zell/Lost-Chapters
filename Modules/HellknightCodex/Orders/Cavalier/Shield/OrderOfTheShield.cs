using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.Shield
{
    internal class OrderOfTheShield
    {
        private static readonly string Guid = "{85d9817c-c57b-497c-a3d0-6aaa58624e51}";

        private static readonly string OrderName   = "OrderOfTheShield";
        private static readonly string DisplayName = "OrderOfTheShield.BuffName";
        private static readonly string Description = "OrderOfTheShield.Description";

        public static void Configure()
        {
            Challenge.Configure();
            Skills.Configure();

            var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
                .AddToLevelEntry(01, Challenge.Guid, Skills.Guid)
                .AddToLevelEntry(02, ResoluteFeature.Guid)
                .AddToLevelEntry(06, ResoluteFeature.Guid)
                .AddToLevelEntry(10, ResoluteFeature.Guid)
                .AddToLevelEntry(14, ResoluteFeature.Guid)
                .AddToLevelEntry(18, ResoluteFeature.Guid)
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
            public static readonly string Guid = "{8fabf63c-f52e-4d4b-a3bc-fb865e5fbc8d}";

            private static readonly string FeatureName = "OrderOfTheShield.Challenge";
            private static readonly string DisplayName = "OrderOfTheShield.Challenge.Name";
            private static readonly string Description = "OrderOfTheShield.Challenge.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class Skills
        {
            public static readonly string Guid = "{8fdafb92-41b2-4cc5-a95c-6ed362277fbf}";

            private static readonly string FeatureName = "OrderOfTheShield.Skills";
            private static readonly string DisplayName = "OrderOfTheShield.Skills.Name";
            private static readonly string Description = "OrderOfTheShield.Skills.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddClassSkill(StatType.SkillPerception)
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
