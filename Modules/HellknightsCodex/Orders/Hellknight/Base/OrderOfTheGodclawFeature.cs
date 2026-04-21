using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightsCodex.Components;
using LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;
using LostChapters.Modules.HellknightsCodex.Feats;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.Base;

internal class OrderOfTheGodclawFeature
{
    public static readonly string Guid = "{c9e095ed-976b-4e5d-98c4-111cabd30ac0}";

    private static readonly string FeatureName = "OrderOfTheGodclawFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    private static readonly WeaponCategory FavoredWeapon = WeaponCategory.HeavyMace;

    internal static void Configure()
    {
        FakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection([HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid, CrossOrderTrainingFeature.Guid])
            .AddProficiencies(weaponProficiencies: [FavoredWeapon])
            .AddWeaponCategoryAttackBonus(1, FavoredWeapon, ModifierDescriptor.Enhancement)
            .AddComponent<OrderOfTheGodclawDoctrine>()
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
        public static readonly string Guid = "{aaca8bef-e5a7-41e3-ade0-c1b4eb656bee}";

        private static readonly string FeatureName = $"{OrderOfTheGodclawFeature.FeatureName}.Fake";

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
