using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.Components.HellknightDoctrine;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightCodex.Orders.Hellknight;

internal class OrderOfTheScorageFeature
{
    public static readonly string Guid = "{215f5cf4-c943-4901-9643-b2b3f391c414}";

    private static readonly string FeatureName = "OrderOfTheScorageFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    internal static void Configure()
    {
        OrderOfTheScorageDoctrineFeature.Configure();
        OrderOfTheScorageFakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid)
            .AddFacts([OrderOfTheScorageDoctrineFeature.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class OrderOfTheScorageDoctrineFeature
    {
        public static readonly string Guid = "{2832f4e0-305b-4b79-8649-285022c12614}";

        private static readonly string FeatureName = $"{FeatureName}.Doctrine";

        internal static void Configure()
        {
            var favoredWeapon = WeaponCategory.LightMace;

            var value = ContextValues.Rank();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddProficiencies(weaponProficiencies: [favoredWeapon])
                .AddWeaponCategoryAttackBonus(1, favoredWeapon, ModifierDescriptor.Enhancement)
                .AddComponent<OrderOfTheScorageDoctrine>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI()
                .Configure();
        }
    }

    public class OrderOfTheScorageFakeFeature
    {
        public static readonly string Guid = "{997a6c39-3ac9-4442-a66a-00346e1ad591}";

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
