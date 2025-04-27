using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class LongspearPlus3BenevolentColdIronBleedItem
{
    public static readonly string Guid = "{7e2b90bb-5c15-4e35-8356-d61ff36761f0}";

    private static readonly string ItemName = "LongspearPlus3BenevolentColdIronBleedItem";
    private static readonly string DisplayName = "LongspearPlus3BenevolentColdIronBleedItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.LongspearPlus3.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "3a92c0b81d66750449a8a3bc7e67bebd" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 50000)
            .SetCR(cR: 11)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.ColdIronWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Bleed.ToString(),
                WeaponEnchantmentRefs.Enhancement3.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
