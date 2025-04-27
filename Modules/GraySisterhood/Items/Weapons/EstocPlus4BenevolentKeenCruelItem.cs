using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class EstocPlus4BenevolentKeenCruelItem
{
    public static readonly string Guid = "{b0dacc4a-134d-4f25-a8d7-0ec86ec8fc12}";

    private static readonly string ItemName = "EstocPlus4BenevolentKeenCruelItem";
    private static readonly string DisplayName = "EstocPlus4BenevolentKeenCruelItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.EstocAgilePlus1.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "7ee97c8792e9adf4288f71753af3d350" },
            m_WeaponSheathModelOverride = new PrefabLink() { AssetId = "00616f7757cef024d8af17ede53f4609" }
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 75000)
            .SetCR(cR: 15)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Estoc.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Keen.ToString(),
                WeaponEnchantmentRefs.CruelEnchantment.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
