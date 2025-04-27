using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class LongsordPlus1BenevolentItem
{
    public static readonly string Guid = "{f036c678-cad4-4cc1-86cf-01e2d0aa50e0}";

    private static readonly string ItemName = "LongsordPlus1BenevolentItem";
    private static readonly string DisplayName = "LongsordPlus1BenevolentItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.SilverLongswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "191f653b58e3c414f9483b2b6eff9e63" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 8500)
            .SetCR(cR: 6)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Enhancement1.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
