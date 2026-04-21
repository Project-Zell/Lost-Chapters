using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightsCodex.Components;
using LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;
using LostChapters.Modules.HellknightsCodex.Feats;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.New;

internal class OrderOfTheScarFeature
{
    public static readonly string Guid = "{1fffa9a4-9d2c-4ccf-9ad9-ca201bef3e0a}";

    private static readonly string FeatureName = "OrderOfTheScarFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    private static readonly WeaponCategory FavoredWeapon = WeaponCategory.Estoc;

    internal static void Configure()
    {
        FakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection([HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid, CrossOrderTrainingFeature.Guid])
            .AddWeaponCategoryAttackBonus(1, FavoredWeapon, ModifierDescriptor.Enhancement)
            .AddComponent<OrderOfTheScarDoctrine>()
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
        public static readonly string Guid = "{8067b280-925c-4af0-b2a8-f4c2deba3c6b}";

        private static readonly string FeatureName = $"{OrderOfTheScarFeature.FeatureName}.Fake";

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
