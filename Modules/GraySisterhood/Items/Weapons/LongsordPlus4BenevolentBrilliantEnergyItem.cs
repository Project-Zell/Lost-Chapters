using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class LongsordPlus4BenevolentBrilliantEnergyItem
{
    //brillian energy
    private static readonly string Guid = "{f6e8a13d-61b2-48b8-a1bc-f9dfdee8f6cf}";

    private static readonly string ItemName = "LongsordPlus4BenevolentBrilliantEnergyItem";
    private static readonly string DisplayName = "LongsordPlus4BenevolentBrilliantEnergyItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.SilverLongswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "191f653b58e3c414f9483b2b6eff9e63" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 75000)
            .SetCR(cR: 15)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.BrilliantEnergy.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
