using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class LongsordPlus3BenevolentItem
{
    public static readonly string Guid = "{aa8301fc-9a14-4702-92ea-f6ae8683ae28}";

    private static readonly string ItemName = "LongsordPlus3BenevolentItem";
    private static readonly string DisplayName = "LongsordPlus3BenevolentItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.SilverLongswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "191f653b58e3c414f9483b2b6eff9e63" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 32000)
            .SetCR(cR: 11)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Enhancement3.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
