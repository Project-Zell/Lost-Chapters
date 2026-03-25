using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Modules.GraySisterhood.Enchantments;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Simple;

internal class StaffPlus4BenevolentDisruptionRadiantItem
{
    public static readonly string Guid = "{84cadc04-c711-4d4f-936e-97b71b34f568}";

    private static readonly string ItemName = "StaffPlus4BenevolentDisruptionRadiantItem";
    private static readonly string DisplayName = "StaffPlus4BenevolentDisruptionRadiantItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.AnarchicConstructBaneQuarterStaffPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_Projectiles = [],
            m_PossibleAttachSlots = [],
            m_WeaponModel = new PrefabLink() { AssetId = "998227d156d74414cb7f5af2b23781fb" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 75000)
            .SetCR(cR: 15)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Quarterstaff.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Disruption.ToString(),
                WeaponEnchantmentRefs.Radiant.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
