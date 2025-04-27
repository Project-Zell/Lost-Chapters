using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
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

internal class FallensMercyItem
{
    public static readonly string Guid = "{5f9e0f4d-048d-494e-bd12-98b280c0fb8c}";

    private static readonly string ItemName = "FallensMercyItem";
    private static readonly string DisplayName = "FallensMercyItem.Name";
    private static readonly string Description = "FallensMercyItem.Description";

    private static readonly Sprite Icon = ItemWeaponRefs.MasterworkLongspear.Reference.Get().Icon;

    internal static void Configure()
    {
        //var visualParameters = new WeaponVisualParameters()
        //{
        //    m_WeaponModel = new PrefabLink() { AssetId = "20882006f8f028241b79612be9b87e18" },
        //};

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 200000)
            .SetCR(cR: 20)
            //.SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.Longspear.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.DruchiteWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{da781ac9-22cc-4231-a0b1-8ebd20eda84f}";

        private static readonly string EnchantmentName = "FallensMercyItem.Enchantment";

        internal static void Configure()
        {
            Buff.Configure();

            var action = ActionsBuilder.New().ApplyBuffPermanent(Buff.Guid);

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(
                    action: action,
                    onlyHit: true)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{3aabb124-2eb6-457a-bd5a-9a1c84d23a44}";

        private static readonly string BuffName = "FallensMercyItem.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddInitiatorAttackWithWeaponTrigger()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
