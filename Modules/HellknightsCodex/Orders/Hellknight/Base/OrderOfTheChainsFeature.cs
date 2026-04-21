using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightsCodex.Components;
using LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;
using LostChapters.Modules.HellknightsCodex.Feats;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.Base;

internal class OrderOfTheChainsFeature
{
    public static readonly string Guid = "{215f5cf4-c943-4901-9643-b2b3f391c414}";

    private static readonly string FeatureName = "OrderOfTheChainsFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    private static readonly WeaponCategory FavoredWeapon = WeaponCategory.Flail;

    internal static void Configure()
    {
        FakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection([HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid, CrossOrderTrainingFeature.Guid])
            .AddProficiencies(weaponProficiencies: [FavoredWeapon])
            .AddWeaponCategoryAttackBonus(1, FavoredWeapon, ModifierDescriptor.Enhancement)
            .AddComponent<OrderOfTheChainsDocrtine>()
            .AddComponent<HellknightDevotion>(component => component.WeaponType = FavoredWeapon)
            .AddComponent<HellknightDedication>(component => component.WeaponType = FavoredWeapon)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class FakeFeature
    {
        public static readonly string Guid = "{997a6c39-3ac9-4442-a66a-00346e1ad591}";

        private static readonly string FeatureName = $"{OrderOfTheChainsFeature.FeatureName}.Fake";

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