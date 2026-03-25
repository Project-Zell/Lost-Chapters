using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.EmeraldPath
{
    internal class CavalierOrderOfTheEmeraldPath
    {
        public static readonly string Guid = "{62e1a69a-f371-46fe-bd51-a20718a93bc1}";

        private static readonly string OrderName = "CavalierOrderOfTheEmeraldPath";
        private static readonly string DisplayName = "CavalierOrderOfTheEmeraldPath.Name";
        private static readonly string Description = "CavalierOrderOfTheEmeraldPath.Description";

        public static void Configure()
        {
            Skills.Configure();
            Challenge.Configure();

            EmeraldPathFavoredTerrainSelection.Configure();
            ForeverGreenFeature.Configure();
            ForestStrikeFeature.Configure();

            var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
                .AddToLevelEntry(01, Challenge.Guid, Skills.Guid)
                .AddToLevelEntry(02, EmeraldPathFavoredTerrainSelection.Guid)
                .AddToLevelEntry(08, ForeverGreenFeature.Guid)
                .AddToLevelEntry(10, EmeraldPathFavoredTerrainSelection.Guid)
                .AddToLevelEntry(15, ForestStrikeFeature.Guid)
                .AddToLevelEntry(18, EmeraldPathFavoredTerrainSelection.Guid)
                .SetClasses(CharacterClassRefs.CavalierClass.ToString())
                .SetUIGroups(UIGroupBuilder.New()
                    .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { Challenge.Guid, EmeraldPathFavoredTerrainSelection.Guid }))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.CavalierOrderSelection.ToString())
                .AddToAllFeatures(orderProgression)
                .Configure();
        }

        internal class Challenge
        {
            public static readonly string Guid = "{90c4118d-c07c-4df4-8f38-a486852e8ee9}";

            private static readonly string FeatureName = "CavalierOrderOfTheEmeraldPath.Challenge";
            private static readonly string DisplayName = "CavalierOrderOfTheEmeraldPath.Challenge.Name";
            private static readonly string Description = "CavalierOrderOfTheEmeraldPath.Challenge.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddComponent<OrderOfTheEmeraldPathChallenge>()
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }

        internal class Skills
        {
            public static readonly string Guid = "{b4242331-19ce-43cd-9f55-606e030aaed6}";

            private static readonly string FeatureName = "CavalierOrderOfTheEmeraldPath.Skills";
            private static readonly string DisplayName = "CavalierOrderOfTheEmeraldPath.Skills.Name";
            private static readonly string Description = "CavalierOrderOfTheEmeraldPath.Skills.Description";

            internal static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddClassSkill(StatType.SkillLoreNature)
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
