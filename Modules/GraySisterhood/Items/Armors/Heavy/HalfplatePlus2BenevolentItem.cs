using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Enchantments;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Heavy
{
    internal class HalfplatePlus2BenevolentItem
    {
        public static readonly string Guid = "{2fbb4ddf-3f70-455d-a85d-d1fcc20255eb}";

        private static readonly string ItemName = "FullplatePlus3BenevolentItem";
        private static readonly string DisplayName = "FullplatePlus3BenevolentItem.Name";

        internal static void Configure()
        {
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.HalfplateStandartPlus2)
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
