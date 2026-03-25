using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Modules.GraySisterhood.Enchantments;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Martial;

internal class ShortswordPlus5BenevolentAdamantineGreaterCorrosiveItem
{
    public static readonly string Guid = "{0bfaddb5-732e-4ba8-b6ec-624532c8f16f}";

    private static readonly string ItemName = "ShortswordPlus5BenevolentAdamantineGreaterCorrosiveItem";
    private static readonly string DisplayName = "ShortswordPlus5BenevolentAdamantineGreaterCorrosiveItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.ShortswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_Projectiles = [],
            m_PossibleAttachSlots = [],
            m_WeaponModel = new PrefabLink() { AssetId = "6688f06631a7cb343aa0af45d9034e29" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 75)
            .SetCR(cR: 15)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.AdamantineWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Corrosive2d6.ToString(),
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
