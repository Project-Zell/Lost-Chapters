using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class LongspearPlus2BenevolentSacrificialItem
{
    public static readonly string Guid = "{a6b79b69-c9e2-4341-ad94-56b3d8ceb2cb}";

    private static readonly string ItemName = "LongspearPlus2BenevolentSacrificialItem";
    private static readonly string DisplayName = "LongspearPlus2BenevolentSacrificialItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.LongspearPlus3.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "3a92c0b81d66750449a8a3bc7e67bebd" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 32000)
            .SetCR(cR: 7)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Sacrificial.ToString(),
                WeaponEnchantmentRefs.Enhancement2.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
