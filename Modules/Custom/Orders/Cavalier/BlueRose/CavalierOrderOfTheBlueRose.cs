using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Orders.Cavalier.BlueRose;

internal class CavalierOrderOfTheBlueRose
{

    private static readonly string Guid = "{9fc2cea5-7c6c-45a5-b207-7051390b9db6}";

    private static readonly string OrderName = "CavalierOrderOfTheBlueRose";
    private static readonly string DisplayName = "CavalierOrderOfTheBlueRose.Name";
    private static readonly string Description = "CavalierOrderOfTheBlueRose.Description";

    public static void Configure()
    {
        Challenge.Configure();
        Skills.Configure();

        ShieldOfBladesFeature.Configure();
        LacerationFeature.Configure();
        InnerPeaceFeature.Configure();

        var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
            .AddToLevelEntry(level: 01, features: Challenge.Guid)
            .AddToLevelEntry(level: 01, features: Skills.Guid)
            .AddToLevelEntry(level: 02, features: ShieldOfBladesFeature.Guid)
            .AddToLevelEntry(level: 08, features: LacerationFeature.Guid)
            .AddToLevelEntry(level: 15, features: InnerPeaceFeature.Guid)
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
        public static readonly string Guid = "{b3598d14-8b14-4e41-a9f9-664c0824c2c7}";

        private static readonly string FeatureName = "CavalierOrderOfTheBlueRose.Challenge";
        private static readonly string DisplayName = "CavalierOrderOfTheBlueRose.Challenge.Name";
        private static readonly string Description = "CavalierOrderOfTheBlueRose.Challenge.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddComponent<OrderOfTheBlueRoseChallenge>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Skills
    {
        public static readonly string Guid = "{055396f3-3555-4560-8752-e9d89bacb7ba}";

        private static readonly string FeatureName = "CavalierOrderOfTheBlueRose.Skills";
        private static readonly string DisplayName = "CavalierOrderOfTheBlueRose.Skills.Name";
        private static readonly string Description = "CavalierOrderOfTheBlueRose.Skills.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddClassSkill(StatType.SkillKnowledgeWorld)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .Configure();
        }
    }
}
