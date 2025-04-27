using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class ShortspearPlus4BenevolentDruchiteLivingBaneItem
{
    public static readonly string Guid = "{b1de63a1-7ce4-43c5-86ee-5dc7c6496ad5}";

    private static readonly string ItemName = "ShortspearPlus4BenevolentDruchiteLivingBaneItem";
    private static readonly string DisplayName = "ShortspearPlus4BenevolentDruchiteLivingBaneItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.KeenBrilliantEnergyShortspearPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "1fe9d3b85b810e74081903a8bb1faef6" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 75000)
            .SetCR(cR: 15)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.DruchiteWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.BaneLiving.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
