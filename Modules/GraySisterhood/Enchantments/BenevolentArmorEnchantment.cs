using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Loot;

namespace LostChapters.Enchantment
{
    internal class BenevolentArmorEnchantment
    {
        public static BlueprintFeature FeatReference;
        public static BlueprintArmorEnchantment Enchantment;

        public static readonly string FeatureGuid = "{9c5527d2-114e-4607-8ad3-c352b56cc0a8}";
        public static readonly string EnchantGuid = "{fe283c68-52ff-4490-b583-ab51411724dd}";

        private static readonly string FeatureName = "BenevolentArmor";
        private static readonly string EnchantName = "BenevolentArmor.Enchantment";
        private static readonly string EnchantDisplayName = "BenevolentArmor.Name";
        private static readonly string EnchantDescription = "BenevolentArmor.Description";

        public static void Configure()
        {
            FeatReference = FeatureConfigurator.New(FeatureName, FeatureGuid)
                .Configure();

            Enchantment = ArmorEnchantmentConfigurator.New(EnchantName, EnchantGuid)
                .AddUnitFeatureEquipment(FeatReference)
                .SetEnchantName(EnchantDisplayName)
                .SetDescription(EnchantDescription)
                .Configure();
            
            var armor = ItemArmorConfigurator.New("Armoring", "{755871e7-107a-45ac-8d78-26bf69f29fcd}")
                .CopyFrom(ItemArmorRefs.PaddedStandartPlus1)
                .SetCost(5) 
                .SetEnchantments([Enchantment, ArmorEnchantmentRefs.ArmorEnhancementBonus5.Reference.Get()])
                .SetDisplayNameText("Benevolent Armor +5")
                .Configure();

            var loot = new LootItem()
            {
                m_Item = armor.ToReference<BlueprintItemReference>(),
                m_Loot = new BlueprintUnitLootReference()
            };
        }
    }
}
