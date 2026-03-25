using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Enchantments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Light
{
    internal class ChainshirtPlus2BenevolentItem
    {
        public static readonly string Guid = "{ca12811c-2ef3-4b61-b32b-1eab2565b04b}";

        private static readonly string ItemName = "ChainshirtPlus2BenevolentItem";
        private static readonly string DisplayName = "ChainshirtPlus2BenevolentItem.Name";

        internal static void Configure()
        {
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.BruisersChainshirtItem)
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
