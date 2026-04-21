using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightsCodex.Components;
using LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;
using LostChapters.Modules.HellknightsCodex.Feats;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.New;

internal class OrderOfTheCoilFeature
{
    public static readonly string Guid = "{9d185ad7-3f57-4d22-b55a-c7bb225be2de}";

    private static readonly string FeatureName = "OrderOfTheCoilFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    private static readonly WeaponCategory FavoredWeapon = WeaponCategory.Greataxe;

    internal static void Configure()
    {
        FakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection([HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid, CrossOrderTrainingFeature.Guid])
            .AddWeaponCategoryAttackBonus(1, FavoredWeapon, ModifierDescriptor.Enhancement)
            .AddComponent<OrderOfTheCoilDoctrine>()
            .AddComponent<HellknightDevotion>(component => component.WeaponType = FavoredWeapon)
            .AddComponent<HellknightDedication>(component => component.WeaponType = FavoredWeapon)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class FakeFeature
    {
        public static readonly string Guid = "{2d95ad69-3269-4e3e-b4ab-8b4b87e749eb}";

        private static readonly string FeatureName = $"{OrderOfTheCoilFeature.FeatureName}.Fake";

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
