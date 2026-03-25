using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Bastion;

internal class CavalierOrderOfTheBastion
{
    public static readonly string Guid = "{a5222fb5-2359-40f1-b9ee-d919d9446cc0}";

    private static readonly string OrderName = "CavalierOrderOfTheBastion";
    private static readonly string DisplayName = "CavalierOrderOfTheBastion.Name";
    private static readonly string Description = "CavalierOrderOfTheBastion.Description";

    public static void Configure()
    {
        Challenge.Configure();
        Skills.Configure();
        BarricadeFeature.Configure();

        var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
            .AddToLevelEntry(level: 01, features: Challenge.Guid)
            .AddToLevelEntry(level: 01, features: Skills.Guid)
            .AddToLevelEntry(level: 02, features: BarricadeFeature.Guid)
            .AddToLevelEntry(level: 06, features: BarricadeFeature.Rank.Guid)
            .AddToLevelEntry(level: 08, features: FeatureRefs.UncannyDodge.ToString())
            .AddToLevelEntry(level: 10, features: BarricadeFeature.Rank.Guid)
            .AddToLevelEntry(level: 14, features: BarricadeFeature.Rank.Guid)
            .AddToLevelEntry(level: 15, features: FeatureRefs.ImprovedUncannyDodge.ToString())
            .AddToLevelEntry(level: 18, features: BarricadeFeature.Rank.Guid)
            .SetUIGroups(UIGroupBuilder.New()
               .AddGroup(new Blueprint<BlueprintFeatureBaseReference>[] { Challenge.Guid, BarricadeFeature.Guid, BarricadeFeature.Rank.Guid }))
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
        public static readonly string Guid = "{c1c637d3-00c2-489d-bdb3-8cf7f44c5995}";

        private static readonly string FeatureName = "CavalierOrderOfTheBastion.Challenge";
        private static readonly string DisplayName = "CavalierOrderOfTheBastion.Challenge.Name";
        private static readonly string Description = "CavalierOrderOfTheBastion.Challenge.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddComponent<OrderOfTheBastionChallenge>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Skills
    {
        public static readonly string Guid = "{ab037519-5acd-4bc4-887f-58e996a5c609}";

        private static readonly string FeatureName = "CavalierOrderOfTheBastion.Skills";
        private static readonly string DisplayName = "CavalierOrderOfTheBastion.Skills.Name";
        private static readonly string Description = "CavalierOrderOfTheBastion.Skills.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddClassSkill(StatType.SkillKnowledgeWorld)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
