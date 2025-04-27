using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class ShortswordPlus2BenevolentAnarchicItem
{
    public static readonly string Guid = "{98478079-a00f-4c52-8259-304a4c0ece91}";

    private static readonly string ItemName = "ShortswordPlus2BenevolentAnarchicItem";
    private static readonly string DisplayName = "ShortswordPlus2BenevolentAnarchicItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.ShortswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "6688f06631a7cb343aa0af45d9034e29" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 32000)
            .SetCR(cR: 7)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Anarchic.ToString(),
                WeaponEnchantmentRefs.Enhancement2.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
