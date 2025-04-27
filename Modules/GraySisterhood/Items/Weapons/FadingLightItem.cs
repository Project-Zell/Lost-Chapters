using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class FadingLightItem
{
    public static readonly string Guid = "{983c84ab-3345-4c7f-b7fb-ab7fc4fb9d06}";

    private static readonly string ItemName = "FadingLightItem";
    private static readonly string DisplayName = "FadingLightItem.Name";
    private static readonly string Description = "FadingLightItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.HolyElderFlamingLongswordPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "20882006f8f028241b79612be9b87e18" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 8500)
            .SetCR(cR: 6)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longsword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
