using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class BladeBreakerItem
{
    public static readonly string Guid = "{35beb1de-f17f-4a48-99c7-546c96dd476f}";

    private static readonly string ItemName = "BladeBreakerItem";
    private static readonly string DisplayName = "BladeBreakerItem.Name";
    private static readonly string Description = "BladeBreakerItem.Description";

    //icon and model and cost
    private static readonly Sprite Icon = ItemWeaponRefs.AxiomaticLightMacePlus1.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "893a54fbad5389345a041f6851f3137b" },
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 8500)
            .SetCR(cR: 6)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.LightMace.ToString())
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

    internal class Enchantment
    {
        public static readonly string Guid = "{c3d14a9f-ad5c-418d-97f2-9819f087afdf}";

        private static readonly string EnchantmentName = "BladeBreakerItem";

        internal static void Configure()
        {
            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{c3d14a9f-ad5c-418d-97f2-9819f087afdf}";

        private static readonly string BuffName = "BladeBreakerItem";
        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAttackBonusConditional() // has melee weapon
                .Configure();
        }
    }
}
