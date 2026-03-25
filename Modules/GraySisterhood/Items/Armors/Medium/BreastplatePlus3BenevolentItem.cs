using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Enchantments;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Medium
{
    internal class BreastplatePlus3BenevolentItem
    {
        public static readonly string Guid = "{2fbb4ddf-3f70-455d-a85d-d1fcc20255eb}";

        private static readonly string ItemName = "BreastplatePlus3BenevolentItem";
        private static readonly string DisplayName = "BreastplatePlus3BenevolentItem.Name";

        internal static void Configure()
        {
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.BreastplateStandard)
                .AddEquipmentRestrictionClass(CharacterClassRefs.DragonClass.ToString(), not: true)
                .SetCost(1)
                .SetEnchantments(enchantments: [
                    BenevolentArmorEnchantment.Reference,
                    ArmorEnchantmentRefs.ArmorEnhancementBonus2.ToString()])
                .SetDisplayNameText(DisplayName)
                .Configure();
        }
    }
}
