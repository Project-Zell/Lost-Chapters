using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Enchantments;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Heavy
{
    internal class BandedPlus1BenevolentItem
    {
        public static readonly string Guid = "{51308426-b7e4-46f7-a023-d1990a6d18d9}";

        private static readonly string ItemName = "BandedPlus1BenevolentItem";
        private static readonly string DisplayName = "BandedPlus1BenevolentItem.Name";

        internal static void Configure()
        {
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.BandedStandartAcidresist25Plus3)
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
