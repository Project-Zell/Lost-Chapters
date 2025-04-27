using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Ecnchantments;
using Kingmaker.Blueprints.Loot;

namespace LostChapters.Enchantment
{
    internal class BenevolentWeaponEnchantment
    {
        public static BlueprintFeature FeatReference;
        public static BlueprintWeaponEnchantment Reference;

        public static readonly string FeatureGuid = "{da935410-cbfc-47a8-b3dd-7550c076a161}";
        public static readonly string EnchantGuid = "{97c59b72-1e96-4736-af43-61f1a99a950e}";

        private static readonly string FeatureName = "BenevolentWeapon";
        private static readonly string EnchantName = "BenevolentWeapon.Enchantment";
        private static readonly string EnchantDisplayName = "BenevolentWeapon.Name";
        private static readonly string EnchantDescription = "BenevolentWeapon.Description";


        public static void Configure()
        {
            FeatReference = FeatureConfigurator.New(FeatureName, FeatureGuid)
                .Configure();

            Reference = WeaponEnchantmentConfigurator.New(EnchantName, EnchantGuid)
                .AddUnitFeatureEquipment(FeatReference)
                .SetEnchantName(EnchantDisplayName)
                .SetDescription(EnchantDescription)
                .Configure(); 

            var sword = ItemWeaponConfigurator.New("Ebasos", "{e58f4a1b-f623-4d5c-8260-ad855ab00035}")
                .CopyFrom(ItemWeaponRefs.ShortswordPlus1)
                .SetCost(5) 
                .SetEnchantments([Reference, WeaponEnchantmentRefs.Enhancement1.Reference.Get()])
                .SetDisplayNameText("Benevolent Shortsword +1")
                .Configure();

            var loot = new LootItem()
            {
                m_Item = sword.ToReference<BlueprintItemReference>(),
                m_Loot = new BlueprintUnitLootReference()
            };

            var sword2 = ItemWeaponConfigurator.New("Ebasos2", "{adb9dd36-282e-463f-86ea-4d6e9b05da52}")
                .CopyFrom(ItemWeaponRefs.ShortswordPlus1)
                .SetCost(5)
                .SetEnchantments([Reference, WeaponEnchantmentRefs.Enhancement5.Reference.Get()])
                .SetDisplayNameText("Benevolent Shortsword +5")
                .Configure();

            var loot2 = new LootItem()
            {
                m_Item = sword2.ToReference<BlueprintItemReference>(),
                m_Loot = new BlueprintUnitLootReference()
            };

            SharedVendorTableConfigurator.For(SharedVendorTableRefs.WarCamp_QuartermasterVendorTable)
                .AddLootItemsPackFixed(1, loot)
                .AddLootItemsPackFixed(1, loot2)
                .Configure();
        }
    }
}
