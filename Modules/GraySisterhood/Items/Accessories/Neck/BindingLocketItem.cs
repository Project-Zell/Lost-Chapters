using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Armors;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Accessories.Neck;

internal class BindingLocketItem
{
    public static readonly string Guid = "{68b6a1ce-bf2f-4a8f-add6-2dbc39187e10}";

    private static readonly string ItemName = "BindingLocketItem";
    private static readonly string DisplayName = $"{ItemName}.Name";
    private static readonly string Description = $"{ItemName}.Description";

    private static readonly Sprite Icon = null;

    internal static void Configure()
    {
        ItemEquipmentNeckConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: null, typeof(ArmorVisualParameters))
            .SetEnchantments([])
            .SetWeight(0.1f)
            .SetCost(0)
            .SetCR(0)
            .SetDestructible(true)
            .SetShardItem(shardItem: ItemRefs.MetalShardItem.ToString())
            .SetInventoryPutSound(SoundGlossary.NeckPut)
            .SetInventoryTakeSound(SoundGlossary.NeckTake)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{66c78688-7ee9-4351-a2cb-9db4b63a03ad}";

        private static readonly string EnchantmentName = $"{EnchantmentName}.Enchantment";

        internal static void Configure()
        {
            EquipmentEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddUnitFactEquipment(HarryingPartnersFeature.Guid)
                .Configure();
        }
    }
}
