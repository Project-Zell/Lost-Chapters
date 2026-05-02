using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Class.Kineticist;
using LostChapters.Modules.GraySisterhood.Enchantments;
using LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;
using UnityEngine;

namespace LostChapters.Modules.Custom.Items.Weapons.Exotic;

internal class CrimsonDancerItem
{
    public static readonly string Guid = "{da17c995-1931-4f0f-958a-65d712e19394}";

    private static readonly string ItemName = "CrimsonDancerItem";
    private static readonly string DisplayName = "CrimsonDancerItem.Name";
    private static readonly string Description = "CrimsonDancerItem.Description";

    //icon and model and cost
    //private static readonly Sprite Icon = ItemWeaponRefs.StandardDoubleSwordSpeedPlus4.Reference.Get().Icon;
    private static readonly Sprite Icon = ItemWeaponRefs.GreataxePlus1.Reference.Get().Icon;

    internal static void Configure()
    {
        //var visualParameters = new WeaponVisualParameters()
        //{
        //    m_Projectiles = [],
        //    m_PossibleAttachSlots = [],
        //    m_WeaponModel = new PrefabLink() { AssetId = "c1bd45bf391b81a468400d7c096747ad" },
        //};

        ItemWeaponConfigurator.New(ItemName, Guid)
            .CopyFrom(ItemWeaponRefs.GreataxePlus1.ToString())
            //.SetCost(cost: 8500)
            //.SetCR(cR: 6)
            //.SetVisualParameters(visualParameters)
            //.SetType(WeaponTypeRefs.DoubleSword.ToString())
            //.SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                DiabolicalBladeFeature.Enchantment.Guid,
                //WeaponEnchantmentRefs.QuickbladeEnchant.ToString(),
                //WeaponEnchantmentRefs.Keen.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
