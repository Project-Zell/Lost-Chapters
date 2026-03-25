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
    internal class LeatherPlus3BenevolentItem
    {
        public static readonly string Guid = "{8b7d0a03-360a-4946-b638-05cc22ebe1d8}";

        private static readonly string ItemName = "LeatherPlus3BenevolentItem";
        private static readonly string DisplayName = "LeatherPlus3BenevolentItem.Name";

        internal static void Configure()
        {
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.SageArmorItem)
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
