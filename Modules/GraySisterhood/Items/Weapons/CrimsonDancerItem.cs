using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Class.Kineticist;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class CrimsonDancerItem
{
    public static readonly string Guid = "{20c8e95d-402d-4b82-8957-130fec8dde43}";

    private static readonly string ItemName = "CrimsonDancerItem";
    private static readonly string DisplayName = "CrimsonDancerItem.Name";
    private static readonly string Description = "CrimsonDancerItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.StandardDoubleSwordSpeedPlus4.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "c1bd45bf391b81a468400d7c096747ad" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 8500)
            .SetCR(cR: 6)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.DoubleSword.ToString())
            .SetSize(Size.Medium) 
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.QuickbladeEnchant.ToString(),
                WeaponEnchantmentRefs.Keen.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
