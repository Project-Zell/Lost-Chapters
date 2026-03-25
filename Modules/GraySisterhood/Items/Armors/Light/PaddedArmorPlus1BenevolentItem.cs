using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Enchantments;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Light
{
    internal class PaddedArmorPlus1BenevolentItem
    {
        public static readonly string Guid = "{a1c24359-8011-4a84-aa7e-f9cbaff2915c}";

        private static readonly string ItemName = "PaddedArmorPlus1BenevolentItem";
        private static readonly string DisplayName = "PaddedArmorPlus1BenevolentItem.Name";

        internal static void Configure()
        {
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.PaddedArmorOfFocusItem)
                .AddEquipmentRestrictionClass(CharacterClassRefs.DragonClass.ToString(), not: true)
                .SetCost(1)
                .SetEnchantments(enchantments: [
                    BenevolentArmorEnchantment.Reference,
                    ArmorEnchantmentRefs.ArmorEnhancementBonus1.ToString()])
                .SetDisplayNameText(DisplayName)
                .Configure();
        }
    }
}
