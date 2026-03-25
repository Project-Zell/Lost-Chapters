using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using LostChapters.Modules.HellknightCodex.Components.HellknightDoctrine;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightCodex.Orders.Hellknight;

internal class OrderOfTheNailFeature
{
    public static readonly string Guid = "{76ba73f2-31c1-4dd8-becf-65c9ea1ddb80}";

    private static readonly string FeatureName = "OrderOfTheNail";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    internal static void Configure()
    {
        OrderOfTheNailDoctrineFeature.Configure();
        OrderOfTheNailFakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid)
            .AddFacts([OrderOfTheNailDoctrineFeature.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class OrderOfTheNailDoctrineFeature
    {
        public static readonly string Guid = "{b85be922-d0b0-4503-98dc-108abd42bd16}";

        private static readonly string FeatureName = $"{FeatureName}.Doctrine";

        internal static void Configure()
        {
            var favoredWeapon = WeaponCategory.Bardiche;

            var value = ContextValues.Rank();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddProficiencies(weaponProficiencies: [favoredWeapon])
                .AddWeaponCategoryAttackBonus(1, favoredWeapon, ModifierDescriptor.Enhancement)
                .AddStatBonus(stat: Kingmaker.EntitySystem.Stats.StatType.Initiative)
                .AddComponent<OrderOfTheNailDocrtine>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI()
                .Configure();
        }
    }

    public class OrderOfTheNailFakeFeature
    {
        public static readonly string Guid = "{f0e28a9a-2c4a-45b2-8db4-02ca66b84cf9}";

        private static readonly string FeatureName = $"{FeatureName}.Fake";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddToFeatureSelection(HellknightOrderSelectionFeature.HellknightFakeOrderSelectionFeature.Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
