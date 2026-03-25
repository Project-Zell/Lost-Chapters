using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Enchantments;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Medium
{
    internal class ScalemailPlus2BenevolentItem
    {
        public static readonly string Guid = "{a07d3a85-6af2-41e0-b2e4-52e50f496239}";

        private static readonly string ItemName = "ScalemailPlus2BenevolentItem";
        private static readonly string DisplayName = "ScalemailPlus2BenevolentItem.Name";

        internal static void Configure()
        {
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.BonemailItem)
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
