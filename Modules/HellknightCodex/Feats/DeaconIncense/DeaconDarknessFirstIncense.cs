using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Archetypes.ClassFeatures;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.GraySisterhood.Feats.DeaconIncense
{
    internal class DeaconDarknessFirstIncense
    {
        public static readonly string Guid = "2dd760a1-7dad-45d6-866d-4143ad05c925";

        private const string IncenseName = "DarknessFirstIncense";
        private const string DisplayName = "DarknessFirstIncense.BuffName";
        private const string Description = "DarknessFirstIncense.LocalizedDescription";

        public static void Configure()
        {
            AbilityAreaEffectConfigurator.For(CapellanIncenseClassFeature.AreaRef)
                .AddAbilityAreaEffectBuff(
                    buff: DeaconAnimalFirstIncenseBuff.GetReference(),
                    condition: ConditionsBuilder.New().IsAlly().CasterHasFact(Guid))
                .Configure();

            FeatureConfigurator.New(IncenseName, Guid)
                .AddToFeatureSelection(CapellanIncenseSelector.Guid)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
    internal class DeaconDarkness1FirstIncenseBuff
    {
        public static readonly string Guid = "f4eb5709-f210-4ac7-9126-3791d6ea5b3b";

        private const string BuffName = "DarknessFirstIncense.BuffName";
        private const string DisplayName = "DarknessFirstIncense.BuffName.BuffName";
        private const string Description = "DarknessFirstIncense.BuffName.LocalizedDescription";

#nullable enable
        private static BlueprintBuff? Reference;
#nullable disable

        public static BlueprintBuff GetReference() => Reference ??= CreateBuff();

        private static BlueprintBuff CreateBuff()
        {
            return BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.DruchiteWeaponEnchantment.ToString(), slot: EquipSlotBase.SlotType.PrimaryHand)
                .AddBuffEnchantAnyWeapon(enchantmentBlueprint: WeaponEnchantmentRefs.DruchiteWeaponEnchantment.ToString(), slot: EquipSlotBase.SlotType.SecondaryHand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}