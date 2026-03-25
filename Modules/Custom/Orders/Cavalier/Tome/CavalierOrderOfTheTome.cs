using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Components;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Tome
{
    internal class CavalierOrderOfTheTome
    {
        public static readonly string Guid = "{8c97ee1c-9278-48ac-8d95-959b2cb4faa6}";

        private static readonly string OrderName = "CavalierOrderOfTheTome";
        private static readonly string DisplayName = "CavalierOrderOfTheTome.Name";
        private static readonly string Description = "CavalierOrderOfTheTome.Description";

        public static void Configure()
        {
            Challenge.Configure();
            Skills.Configure();
            LibrarianFeature.Configure();
            ArcaneFortressFeature.Configure();
            ScrollWeavingFeature.Configure();

            var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
                .AddToLevelEntry(level: 01, features: Challenge.Guid)
                .AddToLevelEntry(level: 01, features: Skills.Guid)
                .AddToLevelEntry(level: 02, features: LibrarianFeature.Guid)
                .AddToLevelEntry(level: 08, features: ArcaneFortressFeature.Guid)
                .AddToLevelEntry(level: 15, features: ScrollWeavingFeature.Guid)
                .SetClasses(CharacterClassRefs.CavalierClass.ToString())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.CavalierOrderSelection.ToString())
                .AddToAllFeatures(orderProgression)
                .Configure();
        }

        internal class Challenge
        {
            public static readonly string Guid = "{3d3aae7f-81a3-4884-bb25-960681f06e55}";

            private static readonly string FeatureName = "CavalierOrderOfTheTome.Challenge";
            private static readonly string DisplayName = "CavalierOrderOfTheTome.Challenge.Name";
            private static readonly string Description = "CavalierOrderOfTheTome.Challenge.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddComponent<OrderOfTheTomeChallenge>()
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class Skills
        {
            public static readonly string Guid = "{87b93eb0-219f-4fec-b94a-70c510e92f7f}";

            private static readonly string FeatureName = "CavalierOrderOfTheTome.Skills";
            private static readonly string DisplayName = "CavalierOrderOfTheTome.Skills.Name";
            private static readonly string Description = "CavalierOrderOfTheTome.Skills.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddClassSkill(StatType.SkillUseMagicDevice)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIsClassFeature(true)
                    .Configure();
            }
        }
    }
}
