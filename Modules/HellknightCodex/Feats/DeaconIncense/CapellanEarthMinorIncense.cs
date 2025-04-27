using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class CapellanEarthMinorIncense
    {
        public static readonly string Guid = "a83f3042-2260-4a1d-b2a1-a8b6e81d052f";

        private const string IncenseName = "EarthMinorIncense";
        private const string DisplayName = "EarthMinorIncense.BuffName";
        private const string Description = "EarthMinorIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: CapellanEarthMinorIncenseNormalBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid, negate: true))
                .AddAbilityAreaEffectBuff(
                    buff: CapellanEarthMinorIncenseStrongBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid).CasterHasFact(fact: Deacon.FeatGuid))
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class CapellanEarthMinorIncenseNormalBuff
    {
        public static readonly string Guid = "c71cb402-895e-463b-828b-712ec2dbb1c1";

        private const string BuffName = "EarthMinorIncense.NormalBuff";
        private const string DisplayName = "EarthMinorIncense.NormalBuff.BuffName";
        private const string Description = "EarthMinorIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Corrosive.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Corrosive.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }

    internal class CapellanEarthMinorIncenseStrongBuff
    {
        public static readonly string Guid = "c493e992-bb89-4dcf-a722-2e744d92d244";

        private const string BuffName = "EarthMinorIncense.StrongBuff";
        private const string DisplayName = "EarthMinorIncense.NormalBuff.BuffName";
        private const string Description = "EarthMinorIncense.NormalBuff.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Corrosive2d6.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.Corrosive2d6.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
