using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class StaffPlus3BenevolentUnholyItem
{
    public static readonly string Guid = "{0f037046-5b53-4730-b248-307af6676605}";

    private static readonly string ItemName = "StaffPlus3BenevolentUnholyItem";
    private static readonly string DisplayName = "StaffPlus3BenevolentUnholyItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.AnarchicConstructBaneQuarterStaffPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "998227d156d74414cb7f5af2b23781fb" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 50000)
            .SetCR(cR: 11)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Quarterstaff.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Unholy.ToString(),
                WeaponEnchantmentRefs.Enhancement3.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
