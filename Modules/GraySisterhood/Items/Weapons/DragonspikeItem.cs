using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class DragonspikeItem
{
    public static readonly string Guid = "{74730e7a-b7ec-4a4d-b51a-8457589914fe}";

    private static readonly string ItemName = "DragonspikeItem";
    private static readonly string DisplayName = "DragonspikeItem.Name";
    private static readonly string Description = "DragonspikeItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.FabledHerosLanceItem.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "20882006f8f028241b79612be9b87e18" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 32000)
            .SetCR(cR: 13)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longspear.ToString())
            .SetSize(Size.Medium)
            .SetAbility(AbilityRefs.AcidBlood.ToString())
            .SetCharges(3)
            .SetSpendCharges(true)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.BaneDragon.ToString(),
                WeaponEnchantmentRefs.Corrosive2d6.ToString(),
                WeaponEnchantmentRefs.Enhancement2.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
