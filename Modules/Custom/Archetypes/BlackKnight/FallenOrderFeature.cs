using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Archetypes.BlackKnight;

internal class FallenOrderFeature
{
    public static readonly string Guid = "{82aca15c-357a-4d92-88d6-3a2e62a82190}";

    private static readonly string FeatureName = "FallenOrder";
    private static readonly string DisplayName = "FallenOrder.Name";
    private static readonly string Description = "FallenOrder.Description";

    public static void Configure()
    {
        Challenge.Configure();
        Skills.Configure();

        ImpostorFeature.Configure();

        ProgressionConfigurator.New(FeatureName, Guid)
            .AddToLevelEntry(level: 01, features: Challenge.Guid)
            .AddToLevelEntry(level: 01, features: Skills.Guid)
            .AddToLevelEntry(level: 02, features: ImpostorFeature.Guid)
            //.AddToLevelEntry(level: 08, features: null)
            //.AddToLevelEntry(level: 15, features: null)
            .SetUIGroups(UIGroupBuilder.New()
               .AddGroup([Challenge.Guid]))
            .SetClasses(CharacterClassRefs.CavalierClass.ToString())
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Challenge
    {
        public static readonly string Guid = "{25c96df7-b2ec-4db1-ac49-f77ca28bd5d5}";

        private static readonly string FeatureName = "FallenOrder.Challenge";
        private static readonly string DisplayName = "FallenOrder.Challenge.Name";
        private static readonly string Description = "FallenOrder.Challenge.Description";

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
        public static readonly string Guid = "{c59cc762-fea3-4677-8fc1-79862d13a309}";

        private static readonly string FeatureName = "FallenOrder.Skills";
        private static readonly string DisplayName = "FallenOrder.Skills.Name";
        private static readonly string Description = "FallenOrder.Skills.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddClassSkill(StatType.SkillStealth)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
