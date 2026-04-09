using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.Components.HellknightDoctrine;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.Base;

internal class OrderOfTheGodclawFeature
{
    public static readonly string Guid = "{c9e095ed-976b-4e5d-98c4-111cabd30ac0}";

    private static readonly string FeatureName = "OrderOfTheGodclaw";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    internal static void Configure()
    {
        OrderOfTheGodclawDoctrineFeature.Configure();
        OrderOfTheGodclawFakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid)
            .AddFacts([OrderOfTheGodclawDoctrineFeature.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class OrderOfTheGodclawDoctrineFeature
    {
        public static readonly string Guid = "{824ea23b-7893-4842-8da9-af8850e99f88}";

        private static readonly string FeatureName = $"{FeatureName}.Doctrine";

        internal static void Configure()
        {
            var favoredWeapon = WeaponCategory.HeavyMace;

            var value = ContextValues.Rank();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddProficiencies(weaponProficiencies: [favoredWeapon])
                .AddWeaponCategoryAttackBonus(1, favoredWeapon, ModifierDescriptor.Enhancement)
                .AddComponent<OrderOfTheGodclawDoctrine>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI()
                .Configure();
        }
    }

    public class OrderOfTheGodclawFakeFeature
    {
        public static readonly string Guid = "{aaca8bef-e5a7-41e3-ade0-c1b4eb656bee}";

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
