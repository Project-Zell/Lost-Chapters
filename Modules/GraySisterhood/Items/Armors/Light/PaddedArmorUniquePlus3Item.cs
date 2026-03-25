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
    internal class PaddedArmorUniquePlus3Item
    {
        public static readonly string Guid = "{487efe32-1335-40bb-aac9-29521f7ad9c6}";

        private static readonly string ItemName = "PaddedArmorPlus3BenevolentItem";
        private static readonly string DisplayName = "PaddedArmorPlus3BenevolentItem.Name";

        internal static void Configure()
        {
            //Unique instead
            ItemArmorConfigurator.New(ItemName, Guid)
                .CopyFrom(ItemArmorRefs.DemonicAltarMasochisticPaddedItem)
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
