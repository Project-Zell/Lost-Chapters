using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.Components.HellknightDoctrine;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightCodex.Orders.Hellknight;

internal class OrderOfTheChainsFeature
{
    public static readonly string Guid = "{215f5cf4-c943-4901-9643-b2b3f391c414}";

    private static readonly string FeatureName = "OrderOfTheChains";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    internal static void Configure()
    {
        OrderOfTheChainsDoctrineFeature.Configure();
        OrderOfTheChainsFakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid)
            .AddFacts([OrderOfTheChainsDoctrineFeature.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class OrderOfTheChainsDoctrineFeature
    {
        public static readonly string Guid = "{2832f4e0-305b-4b79-8649-285022c12614}";

        private static readonly string FeatureName = $"{FeatureName}.Doctrine";

        internal static void Configure()
        {
            var favoredWeapon = WeaponCategory.Flail;

            var value = ContextValues.Rank();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddProficiencies(weaponProficiencies: [favoredWeapon])
                .AddWeaponCategoryAttackBonus(1, favoredWeapon, ModifierDescriptor.Enhancement)
                .AddComponent<OrderOfTheChainsDocrtine>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI()
                .Configure();
        }
    }

    public class OrderOfTheChainsFakeFeature
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



















    //public static readonly string OrderGuid = "a651e7ce-d207-468f-ba1a-0ffeddba72bb";
    //public static readonly string FakeOrderGuid = "831c544e-7159-4e38-b216-1ca688b37930";

    //private static readonly string OrderName = "OrderOfTheChains";
    //private static readonly string DisplayName1 = "OrderOfTheChains.Name";
    //private static readonly string Description1 = "OrderOfTheChains.Description";

    //private static readonly string FakeOrderName = "OrderOfTheChains.Fake";

    

    //public static void Configure1()
    //{












    //    var favoredWeaponType = WeaponCategory.Flail;
    //    var favoredWeaponReference = WeaponTypeRefs.Flail.Reference.Get();

    //    FeatureConfigurator.New(OrderName, OrderGuid)
    //        .AddToFeatureSelection(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
    //        .AddProficiencies(weaponProficiencies: [favoredWeaponType])
    //        .AddWeaponCategoryAttackBonus(1, favoredWeaponType, ModifierDescriptor.Enhancement)
    //        .AddCMBBonusForManeuver(maneuvers: [CombatManeuver.Trip], value: 2)
    //        .SetIsClassFeature(true)
    //        .SetDisplayName(DisplayName)
    //        .SetDescription(Description)
    //        //.SetIcon(Icon)
    //        .Configure();

    //    BuffConfigurator.For(HellknightObidienceBuff.Guid)
    //        .AddCMBBonusForManeuver(checkedFact: OrderGuid, maneuvers: [CombatManeuver.Trip], value: 2)
    //        .Configure();

    //    HellknightOrderConfigurator.SetupFeats(
    //        orderGuid: OrderGuid,
    //        favoredWeaponType: favoredWeaponType,
    //        favoredWeaponReference: favoredWeaponReference);

    //    FeatureConfigurator.New(FakeOrderName, FakeOrderGuid)
    //        .AddPrerequisiteFeature(OrderGuid)
    //        .AddToFeatureSelection(HellknightOrderSelection.FakeOrderSelector)
    //        .SetHideNotAvailibleInUI(true)
    //        .SetHideInCharacterSheetAndLevelUp(true)
    //        .SetIsClassFeature(true)
    //        .SetDisplayName(DisplayName)
    //        .SetDescription(Description)
    //        //.SetIcon(Icon)
    //        .Configure();
    //}
}