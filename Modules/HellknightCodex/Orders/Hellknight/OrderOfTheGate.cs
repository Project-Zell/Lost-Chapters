using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.Orders.Hellknight
{
    internal class OrderOfTheGate
    {
        public static readonly string OrderGuid = "4f95ff76-2f75-4166-9a35-978e1399f701";
        public static readonly string FakeOrderGuid = "dec61a72-7813-4170-949f-fb3871a6ed77";

        private const string OrderName = "OrderOfTheGate";
        private const string OrderIcon = "";
        private const string OrderDisplayName = "OrderOfTheGate.BuffName.BuffName";
        private const string OrderDescription = "OrderOfTheGate.Description";
        private const string FakeOrder = "OrderOfTheGate.Fake";

        public static void Configure()
        {
            var favoredWeaponType = WeaponCategory.Dagger;
            var favoredWeaponReference = WeaponTypeRefs.Dagger.Reference.Get();

            HellknightOrderConfigurator.SetupFeats(
                orderGuid: OrderGuid,
                favoredWeaponType: favoredWeaponType,
                favoredWeaponReference: favoredWeaponReference);

            FeatureConfigurator.New(OrderName, OrderGuid)
                .AddToFeatureSelection(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
                .AddProficiencies(weaponProficiencies: [favoredWeaponType])
                .AddWeaponCategoryAttackBonus(1, favoredWeaponType, ModifierDescriptor.Enhancement)
                .AddFeatureOnApply(CreateDoctrin())
                .SetIsClassFeature(true)
                .SetIcon(OrderIcon)
                .SetDisplayName(OrderDisplayName)
                .SetDescription(OrderDescription)
                .Configure();

            FeatureConfigurator.New(FakeOrder, FakeOrderGuid)
                .AddPrerequisiteFeature(OrderGuid)
                .AddToFeatureSelection(HellknightOrderSelection.FakeOrderSelector)
                .SetHideNotAvailibleInUI(true)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetIsClassFeature(true)
                .SetIcon(OrderIcon)
                .SetDisplayName(OrderDisplayName)
                .SetDescription(OrderDescription)
                .Configure();
        }

        public static readonly string DoctrinGuid = "af89487c-2cab-4e45-8e7a-f04b4f72270a";

        private const string DoctrinName = "OrderOfTheGate.Doctrin";
        private const string DoctrinDisplayName = "OrderOfTheGate.Doctrin.BuffName";
        private const string DoctrinDescription = "OrderOfTheGate.Doctrin.LocalizedDescription";

        private static BlueprintFeature CreateDoctrin()
        {
            var doctrine = FeatureConfigurator.New(DoctrinName, DoctrinGuid)
                .AddSavingThrowBonusAgainstSchool(school: SpellSchool.Illusion, value: 2)
                .SetIsClassFeature(true)
                .SetDisplayName(DoctrinDisplayName)
                .SetDescription(DoctrinDescription)
                .Configure();

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddSavingThrowBonusAgainstSchool(school: SpellSchool.Illusion, value: 2)
                .Configure();

            return doctrine;
        }
    }
}
