using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class ShortspearPlus2BenevolentSpeedItem
{
    public static readonly string Guid = "{e4fdcffb-9fd9-40fe-8a08-2b763fa09c0a}";

    private static readonly string ItemName = "ShortspearPlus2BenevolentSpeedItem";
    private static readonly string DisplayName = "ShortspearPlus2BenevolentSpeedItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.KeenBrilliantEnergyShortspearPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "1fe9d3b85b810e74081903a8bb1faef6" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 32000)
            .SetCR(cR: 7)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Speed.ToString(),
                WeaponEnchantmentRefs.Enhancement2.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
