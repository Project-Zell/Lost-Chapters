using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightsCodex.Components;
using LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;
using LostChapters.Modules.HellknightsCodex.Feats;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.New;

internal class OrderOfTheCragFeature
{
    public static readonly string Guid = "{ecdf9c72-348d-43a3-859e-ae747e67b85c}";

    private static readonly string FeatureName = "OrderOfTheCragFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    private static readonly WeaponCategory FirstFavoredWeapon = WeaponCategory.SpikedLightShield;
    private static readonly WeaponCategory SecondFavoredWeapon = WeaponCategory.SpikedHeavyShield;

    internal static void Configure()
    {
        FakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection([HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid, CrossOrderTrainingFeature.Guid])
            .AddWeaponCategoryAttackBonus(1, FirstFavoredWeapon, ModifierDescriptor.Enhancement)
            .AddWeaponCategoryAttackBonus(1, SecondFavoredWeapon, ModifierDescriptor.Enhancement)
            .AddComponent<OrderOfTheCragDoctrine>()
            .AddComponent<HellknightDevotion>(component => component.WeaponType = FirstFavoredWeapon)
            .AddComponent<HellknightDedication>(component => component.WeaponType = FirstFavoredWeapon)
            .AddComponent<HellknightDevotion>(component => component.WeaponType = SecondFavoredWeapon)
            .AddComponent<HellknightDedication>(component => component.WeaponType = SecondFavoredWeapon)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class FakeFeature
    {
        public static readonly string Guid = "{828d0f29-c225-472c-ab66-a20633115398}";

        private static readonly string FeatureName = $"{OrderOfTheCragFeature.FeatureName}.Fake";

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
