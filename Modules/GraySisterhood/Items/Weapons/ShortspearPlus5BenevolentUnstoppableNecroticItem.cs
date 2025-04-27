using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class ShortspearPlus5BenevolentUnstoppableNecroticItem
{
    public static readonly string Guid = "{af54a040-dd33-4f23-a8db-77c695bbb380}";

    private static readonly string ItemName = "ShortspearPlus5BenevolentUnstoppableNecroticItem";
    private static readonly string DisplayName = "ShortspearPlus5BenevolentUnstoppableNecroticItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.KeenBrilliantEnergyShortspearPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "1fe9d3b85b810e74081903a8bb1faef6" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 150000)
            .SetCR(cR: 20)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Shortspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.UnstoppableEnchantment.ToString(),
                WeaponEnchantmentRefs.Necrotic.ToString(),
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
