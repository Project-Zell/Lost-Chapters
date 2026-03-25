using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Calamity;

internal class CavalierOrderOfTheCalamity
{
    private static readonly string Guid = "{250a1ca9-9b6b-4cdd-9a64-77b8c3923aed}";

    private static readonly string OrderName = "CavalierOrderOfTheCalamity";
    private static readonly string DisplayName = "CavalierOrderOfTheCalamity.Name";
    private static readonly string Description = "CavalierOrderOfTheCalamity.Description";

    internal static void Configure()
    {
        Challenge.Configure();
        Skills.Configure();

        ScorchingCleanseFeature.Configure();
        HeavensBurnFeature.Configure();
        PyroclasticStrikeFeature.Configure();


        var orderProgression = ProgressionConfigurator.New(OrderName, Guid)
            .AddToLevelEntry(level: 01, features: Challenge.Guid)
            .AddToLevelEntry(level: 01, features: Skills.Guid)
            .AddToLevelEntry(level: 02, features: ScorchingCleanseFeature.Guid)
            .AddToLevelEntry(level: 08, features: HeavensBurnFeature.Guid)
            .AddToLevelEntry(level: 15, features: PyroclasticStrikeFeature.Guid)
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
        public static readonly string Guid = "{05c0ea7d-66f8-4c3b-ba5c-0f738b8e578a}";

        private static readonly string FeatureName = "CavalierOrderOfTheCalamity.Challenge";
        private static readonly string DisplayName = "CavalierOrderOfTheCalamity.Challenge.Name";
        private static readonly string Description = "CavalierOrderOfTheCalamity.Challenge.Description";

        internal static void Configure()
        {
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddBuffExtraEffects(checkedBuff: BuffRefs.CavalierChallengeBuffSelf.ToString(), extraEffectBuff: Buff.Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{b71246c5-7d38-4550-bc56-02370ccabd85}";

        private static readonly string BuffName = "CavalierOrderOfTheCalamity.Buff";

        internal static void Configure()
        {
            var rankConfig = ContextRankConfigs.ClassLevel([CharacterClassRefs.CavalierClass.ToString()])
                .WithCustomProgression([(04, 10), (09, 20), (14, 30), (19, 40), (20, 50)]);

            BuffConfigurator.New(BuffName, Guid)
                .AddResistEnergy(type: DamageEnergyType.Fire, value: ContextValues.Rank())
                .AddContextRankConfig(rankConfig)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

    }

    internal class Skills
    {
        public static readonly string Guid = "{0573b2e7-9e8d-440e-8b1c-991fec0f51e7}";

        private static readonly string FeatureName = "CavalierOrderOfTheCalamity.Skills";
        private static readonly string DisplayName = "CavalierOrderOfTheCalamity.Skills.Name";
        private static readonly string Description = "CavalierOrderOfTheCalamity.Skills.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddClassSkill(StatType.SkillLoreReligion)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .Configure();
        }
    }
}
