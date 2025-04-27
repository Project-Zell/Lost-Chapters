using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Orders.Cavalier.EmeraldPath
{
    internal class ForeverGreenFeature
    {
        public static readonly string Guid = "{d58e6794-a54c-4d40-be62-0bcd9ab2a85f}";

        private static readonly string FeatureName = "ForeverGreen";
        private static readonly string DisplayName = "ForeverGreen.Name";
        private static readonly string Description = "ForeverGreen.Description";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddWeaponSizeChange(category: WeaponCategory.Quarterstaff, checkWeaponCategory: true, sizeCategoryChange: 2)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
