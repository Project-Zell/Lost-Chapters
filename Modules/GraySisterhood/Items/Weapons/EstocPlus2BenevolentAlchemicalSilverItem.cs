using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class EstocPlus2BenevolentAlchemicalSilverItem
{
    public static readonly string Guid = "{8aa6ba74-9810-4a0d-a0b9-269f16372394}";

    private static readonly string ItemName = "EstocPlus2BenevolentAlchemicalSilverItem";
    private static readonly string DisplayName = "EstocPlus2BenevolentAlchemicalSilverItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.EstocAgilePlus1.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "7ee97c8792e9adf4288f71753af3d350" },
            m_WeaponSheathModelOverride = new PrefabLink() { AssetId = "00616f7757cef024d8af17ede53f4609" }
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 24750)
            .SetCR(cR: 7)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Estoc.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.SilverWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Enhancement2.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
