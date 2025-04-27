using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.NewEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UI.MVVM._PCView.NewGame.Menu;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Components;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using LostChapters.Modules.GraySisterhood.Components;

namespace LostChapters
{
    internal class Test
    {
        internal class Component : UnitBuffComponentDelegate, IInitiatorRulebookHandler<RuleAttackWithWeapon>, IInitiatorRulebookSubscriber
        {
            public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
            {
                throw new System.NotImplementedException();
            }

            public void OnEventDidTrigger(RuleAttackWithWeapon evt)
            {
                throw new System.NotImplementedException();
            }
        }

        internal class CavalierAbilityTest
        {
            internal static void Configure()
            {
                var a = AbilityConfigurator.New("Cavalier.Ability.Test", "{d41854c7-74fd-4ba0-b90a-9a946e66c016}")
                     .AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.CavalierChallengeBuffTarget.ToString()))
                     //.AddAbilityEffectRunAction(ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.CavalierChallengeBuffSelf.ToString(), toCaster: true))
                     .AllowTargeting(true, true, true, true)
                     .SetDisplayName("Cavalier.Ability.Test.Name")
                     .SetDescription("Cavalier.Ability.Test.Description")
                     .SetIcon(AbilityRefs.Transformation.Reference.Get().Icon)
                     .Configure();

                var f = FeatureConfigurator.New("Feaasdzxcz", "{5fcc33c2-975f-4219-b458-329a1665a402}")
                    .AddFacts([a])
                    //.AddComponent<OrderOfTheBlueRoseChallenge>()
                    .SetDisplayName("Cavalier.Ability.Test.Name")
                    .SetDescription("Cavalier.Ability.Test.Description")
                    .Configure();

                
            }
        }


        internal class TestAbility
        {
            public static readonly string FeatGuid    = "{540b6eff-e23a-4097-9c2e-7d7893834901}";
            public static readonly string BuffGuid    = "{28a66ad0-57f2-41c1-a265-b8daead26540}";
            public static readonly string AbilityGuid = "{eaaf0341-ba9b-4aed-9b2a-0efe85d71114}";

            private static readonly string FeatName    = "Debug";
            private static readonly string BuffName    = "DebugBuff";
            private static readonly string AbilityName = "DebugAbility";

            private static readonly string DisplayName = "Debug.DisplayName";
            private static readonly string Description = "Debug.Description";

            public static void Configure()
            {
                var buff = BuffConfigurator.New(BuffName, BuffGuid)
                    .SetIcon(BuffRefs.BlessBuff.Reference.Get().Icon)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
                
                var duration = ContextDuration.Fixed(1, DurationRate.Hours);

                //AddReplaceStatForPrerequisites

                var ability = AbilityConfigurator.New(AbilityName, AbilityGuid)
                    .AddAbilityApplyFact(duration: duration, facts: [buff])
                    .AddAbilityApplyFact(duration: duration, facts: [BuffRefs.AasimarHaloBuff.Reference.Get()])
                    .SetType(AbilityType.Special)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();

                var feat = FeatureConfigurator.New(FeatName, FeatGuid)
                    .AddComponent<ComponentTest>()
                    .AddIgnoreDamageReductionOnTarget()
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();

                FeatureConfigurator.For(FeatureRefs.InspiredRageAllyFeature.Reference.Get())
                    .AddFacts([FeatureRefs.AasimarHaloFeature.ToString()])
                    .Configure();
            }
        }



        public const PetType Eidolon = (PetType)24141;


        public static readonly string FeatGuid = "";

        private const string FeatName    = "placeholder";
        private const string FeatIcon    = "";
        private const string DisplayName = "placeholder.BuffName";
        private const string Description = "placeholder.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, FeatGuid)
                .SetIsClassFeature(true)
                .SetIcon(FeatIcon)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        public static void Configure2()
        {
            ItemWeaponConfigurator.New("", "")
                .AddToEnchantments(WeaponEnchantmentRefs.Oversized.ToString())
                .SetIcon(ItemWeaponRefs.HandaxeAgilePlus1.Reference.Get().Icon)
                .SetDisplayNameText("")
                .SetDescriptionText("")
                .Configure();

            FeatureConfigurator.New("b94c0624-cece-4357-a65c-f338420e4d62", "72f71476-ff08-4001-9ccb-7f69263dfcb7")
                .AddWeaponSizeChange(category: WeaponCategory.Scythe, checkWeaponCategory: true, sizeCategoryChange: 1)
                .AddWeaponSizeChange(category: WeaponCategory.Sickle, checkWeaponCategory: true, sizeCategoryChange: 1)
                .AddWeaponTypeCriticalEdgeIncrease(weaponType: WeaponTypeRefs.Scythe.Reference.GetBlueprint())
                .AddWeaponTypeCriticalEdgeIncrease(weaponType: WeaponTypeRefs.Sickle.Reference.GetBlueprint())
                

                .Configure();

            //UnitUISettings
            //UnitDescriptor

            BuffConfigurator.New("", "")
                .AddBlindsense(10.Feet())
                .Configure();

            FeatureConfigurator.New("1", "1", Kingmaker.Blueprints.Classes.FeatureGroup.BackgroundSelection)
                .AddClassSkill()
                .AddCMDBonusAgainstManeuvers(maneuvers: [CombatManeuver.Grapple])
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.LingeringPerformance)
                .AddBackgroundClassSkill()
                .AddStatBonus()
                .AddFacts(null)
                .AddBackgroundWeaponProficiency()
                .Configure();


            var oath = BuffConfigurator.New("Oath", "")
                .Configure();


            ActionsBuilder.New()
                .Conditional(ConditionsBuilder.New().TargetInMeleeRange().HasBuff(oath))
                .Build();
        }
    }
}
