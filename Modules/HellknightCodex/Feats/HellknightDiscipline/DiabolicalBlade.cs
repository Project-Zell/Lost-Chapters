using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using System;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class DiabolicalBlade
    {
        public static readonly string FeatGuid = "f5d9bcce-bf61-442e-8831-8d6ef9517e5f";

        private const string FeatName = "DiabolicalBlade";
        private const string DisplayName = "DiabolicalBlade.BuffName";
        private const string Description = "DiabolicalBlade.LocalizedDescription";

        public static void Configure()
        {

            //Bloodboiler Item



            var charismaBonusRank = ContextValues.Rank();
            var charsimaBonusConfig = ContextRankConfigs.StatBonus(StatType.Charisma);

            var buffDuration = ContextDuration.Fixed(1, DurationRate.Minutes);
            var damageType = new DamageTypeDescription
            {
                Energy = DamageEnergyType.Fire,
                Type = DamageType.Energy,
            };

            var contextRankConfig = ContextValues.Property(Kingmaker.UnitLogic.Mechanics.Properties.UnitProperty.Level);

            var value = new ContextDiceValue
            {
                DiceType = DiceType.D4,
                DiceCountValue = 0,
            };

            //Hit dice is equal to character level?


            var action2 = ActionsBuilder.New().DealDamage(damageType: damageType, value: value);

            var actionOnReduceBelowZero = ActionsBuilder.New()
                .OnRandomTargetsAround(actions: action2, radius: 15f.Feet(), onEnemies: false, numberOfTargets: 99);
            ;

            BuffConfigurator.New("vcxvxvx", "e6dad79c-b7b9-4332-a68b-0d17cda0ee23")
                .AddAttackBonusAgainstAlignment(alignment: AlignmentComponent.Chaotic, bonus: charismaBonusRank)
                .AddContextRankConfig(charsimaBonusConfig)
                .AddIgnoreTargetDR()
                .AddIncomingDamageTrigger(actions: actionOnReduceBelowZero, reduceBelowZero: true)
                .AddBuffEnchantAnyWeapon(DiabolicalBladeWeaponEnchantment.Guid, Kingmaker.UI.GenericSlot.EquipSlotBase.SlotType.PrimaryHand)
            .Configure();

            FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

        }

        internal class DiabolicalBladeWeaponEnchantment
        {
            public static readonly string Guid = "09fa66c1-2a9e-4bc5-9363-e8a9b21e92d6";

            private const string EnchantmentName = "DiabolicalBladeWeaponEnchantment";
            private const string DisplayName = "DiabolicalBladeWeaponEnchantment.BuffName";
            private const string Description = "DiabolicalBladeWeaponEnchantment.LocalizedDescription";

            public static void Configure()
            {
                //var sourceFx = "91e5a56dd421a2941984a36a2af164b6";
                //var newFx = "ea68e52c-aeea-4418-b93c-f257378f11d8";

                //AssetTool.RegisterDynamicPrefabLink(newFx, sourceFx, ModifyFx);

                WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                    .AddWeaponEnergyDamageDice(element: DamageEnergyType.Fire, energyDamageDice: new DiceFormula(rollsCount: 2, diceType: DiceType.D6))
                    .AddIgnoreResistanceForDamageFromEnchantment(type: IgnoreResistanceForDamageFromEnchantment.IgnoreType.ReductionAndImmunities)
                    .SetWeaponFxPrefab("91e5a56dd421a2941984a36a2af164b6")
                    .SetEnchantName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }

            private static void ModifyFx(GameObject enchantment)
            {
                var e = enchantment.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem p in e)
                {
                    p.startColor = Color.cyan;
                }
            }
        }
    }
}
