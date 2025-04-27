using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class ShortspearPlus3BenevolentGreaterShockItem
{
    public static readonly string Guid = "{95f94294-1a4c-4cf7-a3df-d5f67c8e3636}";

    private static readonly string ItemName = "ShortspearPlus3BenevolentGreaterShockItem";
    private static readonly string DisplayName = "ShortspearPlus3BenevolentGreaterShockItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.KeenBrilliantEnergyShortspearPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "1fe9d3b85b810e74081903a8bb1faef6" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 50000)
            .SetCR(cR: 11)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Shock2d6.ToString(),
                WeaponEnchantmentRefs.Enhancement3.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
