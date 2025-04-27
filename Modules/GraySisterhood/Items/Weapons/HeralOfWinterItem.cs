using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Enchantment;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class HeralOfWinterItem
{
    public static readonly string Guid = "{55df6ed1-61c3-4f67-9ff6-0e26c4af49a0}";

    private static readonly string ItemName = "HeralOfWinterItem";
    private static readonly string DisplayName = "HeralOfWinterItem.Name";
    private static readonly string Description = "HeralOfWinterItem.Description";

    private static readonly Sprite Icon = ItemWeaponRefs.IcyBurstKeenColdIronBastardSwordPlus3Item.Reference.Get().Icon;

    internal static void Configure()
    {
        Enchantment.Configure();

        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "38c83fc9e41aa0c4fa827c8c7aa3f5a3" },
            m_WeaponSheathModelOverride = new PrefabLink() { AssetId = "06467410f181cce468d484720f87a58f" }
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 215000)
            .SetInventoryPutSound(SoundGlossary.SwordPut)
            .SetInventoryTakeSound(SoundGlossary.SwordTake)
            .SetCR(cR: 20)
            .SetAbility(ability: AbilityRefs.IceBody.ToString())
            .SetSpendCharges(true)
            .SetCharges(1)
            .SetRestoreChargesOnRest(true)
            .SetCasterLevel(casterLevel: 18)
            .SetSpellLevel(spellLevel: 18)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.BastardSword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                WeaponEnchantmentRefs.ElderIce2d6.ToString(),
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.ColdIronWeaponEnchantment.ToString(),
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{1f9496f6-df45-4c34-9b0d-5b80f0bbcd67}";

        private static readonly string EnchantmentName = "HeralOfWinterItem.EnchantmentName";

        internal static void Configure()
        {
            AreaBuff.Configure();

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddUnitFactEquipment(blueprint: AreaBuff.Guid)
                .Configure();
        }
    }

    internal class AreaBuff
    {
        public static readonly string Guid = "{d1e6fb64-cc18-4d0d-a190-bc8c77deddbf}";

        private static readonly string AreaBuffName = "HeralOfWinterItem.AreaBuff";
        internal static void Configure()
        {
            Area.Configure();

            BuffConfigurator.New(AreaBuffName, Guid)
                .AddAreaEffect(areaEffect: Area.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Area
    {
        public static readonly string Guid = "{b2910a29-c61e-493f-bf1d-1bf32b53d42b}";

        private static readonly string AreaName = "HeralOfWinterItem.Area";

        internal static void Configure()
        {
            Buff.Configure();

            AbilityAreaEffectConfigurator.New(AreaName, Guid)
                .AddAbilityAreaEffectRunAction(
                    unitEnter: ActionsBuilder.New().ApplyBuffPermanent(Buff.Guid),
                    unitExit: ActionsBuilder.New().RemoveBuff(Buff.Guid))
                .SetAffectEnemies(true)
                .SetSize(15.Feet())
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{fbf2e62b-3aad-473d-838c-ed3dd4a85562}";

        private static readonly string BuffName = "HeralOfWinterItem.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(bonus: -2, spellDescriptor: SpellDescriptor.Cold)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
