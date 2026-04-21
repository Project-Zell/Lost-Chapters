using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightsCodex.Components;
using LostChapters.Modules.HellknightsCodex.Components.HellknightDoctrines;
using LostChapters.Modules.HellknightsCodex.Feats;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.Base;

internal class OrderOfTheNailFeature
{
    public static readonly string Guid = "{76ba73f2-31c1-4dd8-becf-65c9ea1ddb80}";

    private static readonly string FeatureName = "OrderOfTheNailFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    private static readonly WeaponCategory FavoredWeapon = WeaponCategory.Bardiche;

    internal static void Configure()
    {
        FakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection([HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid, CrossOrderTrainingFeature.Guid])
            .AddProficiencies(weaponProficiencies: [FavoredWeapon])
            .AddWeaponCategoryAttackBonus(1, FavoredWeapon, ModifierDescriptor.Enhancement)
            .AddStatBonus(stat: Kingmaker.EntitySystem.Stats.StatType.Initiative)
            .AddComponent<OrderOfTheNailDocrtine>()
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
        public static readonly string Guid = "{f0e28a9a-2c4a-45b2-8db4-02ca66b84cf9}";

        private static readonly string FeatureName = $"{OrderOfTheNailFeature.FeatureName}.Fake";

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
