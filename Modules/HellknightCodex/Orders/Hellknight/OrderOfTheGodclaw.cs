using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.EnneadStar;

namespace LostChapters.Modules.GraySisterhood.Orders.Hellknight
{
    internal class OrderOfTheGodclaw
    {
        private static readonly string OrderName = "OrderOfTheGodclaw";
        private static readonly string OrderGuid = "e9564cfd-8778-4323-8b25-76472ab6fe3e";

        private static readonly string OrderDisplayName = "OrderOfTheGodclaw.BuffName";
        private static readonly string OrderDescription = "OrderOfTheGodclaw.Description";

        private static readonly string FakeOrder = "OrderOfTheGodclaw.Fake";
        private static readonly string FakeOrderGuid = "6ac53797-5237-4391-b883-a07d11cc300a";

        public static void Configure()
        {
            FeatureConfigurator.New(OrderName, OrderGuid)
                .AddToFeatureSelection(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
                .AddProficiencies(weaponProficiencies: [WeaponCategory.HeavyMace])
                .AddWeaponCategoryAttackBonus(1, WeaponCategory.HeavyMace, ModifierDescriptor.Enhancement)
                .AddFeatureOnApply(CreateDoctrin())
                .SetIsClassFeature(true)
                .SetDisplayName(OrderDisplayName)
                .SetDescription(OrderDescription)
                .Configure();

            FeatureConfigurator.New(FakeOrder, FakeOrderGuid)
                .AddPrerequisiteFeature(OrderGuid)
                .AddToFeatureSelection(HellknightOrderSelection.FakeOrderSelector)
                .SetHideNotAvailibleInUI(true)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(OrderDisplayName)
                .SetDescription(OrderDescription)
                .Configure();

            var orderFavoredWeaponToChaoticCondition = ConditionsBuilder.New()
                .CasterHasFact(OrderGuid)
                .Alignment(AlignmentComponent.Chaotic)
                .IsWeaponEquipped(checkOnCaster: true, category: WeaponCategory.HeavyMace);

            FeatureConfigurator.For(OrderOfTheEnneadStar.OpressGuid)
                .AddAttackBonusConditional(bonus: 1, conditions: orderFavoredWeaponToChaoticCondition, descriptor: ModifierDescriptor.Insight)
                .AddDamageBonusConditional(bonus: 1, conditions: orderFavoredWeaponToChaoticCondition, descriptor: ModifierDescriptor.Insight)
                .Configure();

        }

        private static readonly string DoctrinName = "OrderOfTheGodclaw.Doctrin";
        private static readonly string DoctrinGuid = "fdc027cd-1ada-4aa7-9958-ece936bc1526";

        private static readonly string DoctrinDisplayName = "OrderOfTheGodclaw.Doctrin.BuffName";
        private static readonly string DoctrinDescription = "OrderOfTheGodclaw.Doctrin.Description";

        private static BlueprintFeature CreateDoctrin()
        {
            var doctrine = FeatureConfigurator.New(DoctrinName, DoctrinGuid)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Charm, bonus: 2)
                .SetIsClassFeature(true)
                .SetDisplayName(DoctrinDisplayName)
                .SetDescription(DoctrinDescription)
                .Configure();

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Charm, bonus: 2)
                .Configure();

            return doctrine;
        }
    }
}
