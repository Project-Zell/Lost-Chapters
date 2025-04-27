using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class ShortspearPlus1BenevolentMithralItem
{
    public static readonly string Guid = "{380f9aee-7b46-4e83-b893-43479ae31188}";

    private static readonly string ItemName = "ShortspearPlus1BenevolentMithralItem";
    private static readonly string DisplayName = "ShortspearPlus1BenevolentMithralItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.KeenBrilliantEnergyShortspearPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "1fe9d3b85b810e74081903a8bb1faef6" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 18500)
            .SetCR(cR: 4)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.MithralWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Enhancement1.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
