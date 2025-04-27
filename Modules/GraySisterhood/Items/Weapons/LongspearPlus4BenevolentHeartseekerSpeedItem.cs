using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class LongspearPlus4BenevolentHeartseekerSpeedItem
{
    public static readonly string Guid = "{4bd5e654-0cae-49b2-a711-c1f9e7ff791a}";

    private static readonly string ItemName = "LongspearPlus4BenevolentHeartseekerSpeedItem";
    private static readonly string DisplayName = "LongspearPlus4BenevolentHeartseekerSpeedItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.LongspearPlus3.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "3a92c0b81d66750449a8a3bc7e67bebd" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 75000)
            .SetCR(cR: 15)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Heartseeker.ToString(),
                WeaponEnchantmentRefs.Speed.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
