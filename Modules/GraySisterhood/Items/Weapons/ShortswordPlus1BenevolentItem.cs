using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class ShortswordPlus1BenevolentItem
{
    public static readonly string Guid = "{9c91e446-d67b-4749-84ed-83b516aaf90f}";

    private static readonly string ItemName = "ShortswordPlus1BenevolentItem";
    private static readonly string DisplayName = "ShortswordPlus1BenevolentItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.ShortswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "6688f06631a7cb343aa0af45d9034e29" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 8500)
            .SetCR(cR: 4)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Enhancement1.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
