using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Loot;

namespace LostChapters.Modules.GraySisterhood.Items.Other
{
    internal class RingOfAltruismItem
    {
        public static BlueprintFeature Reference;

        public static readonly string ItemGuid = "{b8f3b60e-83e9-4392-b83b-106dce23e112}";
        public static readonly string FeatGuid = "{a7476d58-bd30-4eaf-905b-1240741aeb7a}";
        public static readonly string EnchantGuid = "{e445742a-c7df-4117-9167-2d626f4bb74d}";

        private static readonly string ItemName = "RingOfAltruismItem";
        private static readonly string FeatName = "RingOfAltruismItem.Blueprint";
        private static readonly string EnchantName = "RingOfAltruismItem.Enchantment";
        private static readonly string DisplayName = "RingOfAltruismItem.BuffName";
        private static readonly string Description = "RingOfAltruismItem.LocalizedDescription";

        public static void Configure()
        {
            Reference = FeatureConfigurator.New(FeatName, FeatGuid)
                .SetHideInUI(true)
                .Configure();

            var enchant = EquipmentEnchantmentConfigurator.New(EnchantName, EnchantGuid)
                .AddUnitFeatureEquipment(Reference)
                .Configure();

            var ring = ItemEquipmentRingConfigurator.New(ItemName, ItemGuid)
                .SetIcon(ItemEquipmentRingRefs.RingOfSourceOfInvisibilityItem.Reference.Get().Icon)
                .SetEnchantments(enchant)
                .SetCost(4200)
                .SetWeight(0.05f)
                .SetInventoryPutSound("RingPut")
                .SetInventoryTakeSound("RingTake")
                .SetInventoryEquipSound("RingPut")
                .SetDisplayNameText(DisplayName)
                .SetDescriptionText(Description)
                .Configure();

            var loot = new LootItem()
            {
                m_Item = ring.ToReference<BlueprintItemReference>(),
                m_Loot = new BlueprintUnitLootReference()
            };

            SharedVendorTableConfigurator.For(SharedVendorTableRefs.WarCamp_QuartermasterVendorTable)
                .AddLootItemsPackFixed(1, loot)
                .Configure();

        }
    }
}
