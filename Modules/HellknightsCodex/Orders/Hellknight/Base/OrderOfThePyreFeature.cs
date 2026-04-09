using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums;
using LostChapters.Modules.HellknightCodex.Components.HellknightDoctrine;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.HellknightsCodex.Orders.Hellknight.Base;

internal class OrderOfThePyreFeature
{
    public static readonly string Guid = "{4306b682-fe27-42fb-a112-bc47af40a6c2}";

    private static readonly string FeatureName = "OrderOfThePyre";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

    internal static void Configure()
    {
        OrderOfThePyreDoctrineFeature.Configure();
        OrderOfThePyreFakeFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightOrderSelectionFeature.HellknightInitialOrderSelectionFeature.Guid)
            .AddFacts([OrderOfThePyreDoctrineFeature.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    public class OrderOfThePyreDoctrineFeature
    {
        public static readonly string Guid = "{ea6f902d-1134-4b1f-a0e9-ee2334185eaa}";

        private static readonly string FeatureName = $"{FeatureName}.Doctrine";

        internal static void Configure()
        {
            var favoredWeapon = WeaponCategory.Glaive;

            var value = ContextValues.Rank();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddProficiencies(weaponProficiencies: [favoredWeapon])
                .AddWeaponCategoryAttackBonus(1, favoredWeapon, ModifierDescriptor.Enhancement)
                .AddComponent<OrderOfThePyreDoctrine>()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI()
                .Configure();
        }
    }

    public class OrderOfThePyreFakeFeature
    {
        public static readonly string Guid = "{a3fdd5d2-387f-4cda-8914-5fe1d0c6f96e}";

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
