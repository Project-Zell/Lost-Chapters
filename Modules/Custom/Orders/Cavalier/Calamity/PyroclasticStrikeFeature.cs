using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UI.GenericSlot;
using UnityEngine;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Calamity;

internal class PyroclasticStrikeFeature
{
    public static readonly string Guid = "{8c0215db-eb7d-4d23-bc05-6520e347d6db}";

    private static readonly string FeatureName = "PyroclasticStrike";
    private static readonly string DisplayName = "PyroclasticStrike.Name";
    private static readonly string Description = "PyroclasticStrike.Description";

    internal static void Configure()
    {
        Abitity.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Abitity.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Abitity
    {
        public static readonly string Guid = "{60af0c30-2c2c-4ed2-b093-57d7cba23095}";

        private static readonly string AbilityName = "PyroclasticStrike.Ability";
        private static readonly string DisplayName = "PyroclasticStrike.Ability.Name";
        private static readonly string Description = "PyroclasticStrike.Ability.Description";

        private static readonly Sprite Icon = BuffRefs.WeaponBondFlamingBurstBuff.Reference.Get().Icon;

        internal static void Configure()
        {
            Buff.Configure();

            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(Buff.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{03c33f12-13d3-4f33-92a0-f4cd64841e1a}";

        private static readonly string BuffName = "PyroclasticStrike.Buff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.FlamingBurst.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Flaming.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.FlamingBurst.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Flaming.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
