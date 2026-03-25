using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;

namespace LostChapters.Modules.GraySisterhood.Enchantments;

internal class GrayMaidensPlateEnchantment
{
    public static readonly string Guid = "{fe283c68-52ff-4490-b583-ab51411724dd}";

    private static readonly string EnchantmentName = "GrayMaidensPlate.Enchantment.";

    internal static void Configure()
    {
        Feature.Configure();

        ArmorEnchantmentConfigurator.New(EnchantmentName, Guid)
            .AddUnitFactEquipment(blueprint: Feature.Guid)
            .Configure();
    }

    internal class Feature
    {
        public static readonly string Guid = "{9c5527d2-114e-4607-8ad3-c352b56cc0a8}";
        
        private static readonly string FeatureName = "GrayMaidensPlateEnchantment.Feature";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .SetHideInUI(true)
                .SetHideInCharacterSheetAndLevelUp(true)
                .Configure();
        }
    }
}
