using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline;
using LostChapters.Modules.GraySisterhood.Feats.Selection;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.Orders.Hellknight
{
    internal class OrderOfTheChains
    {
        public static readonly string OrderGuid = "a651e7ce-d207-468f-ba1a-0ffeddba72bb";
        public static readonly string FakeOrderGuid = "831c544e-7159-4e38-b216-1ca688b37930";

        private static readonly string OrderName = "OrderOfTheChains";
        private static readonly string DisplayName = "OrderOfTheChains.Name";
        private static readonly string Description = "OrderOfTheChains.Description";

        private static readonly string FakeOrderName = "OrderOfTheChains.Fake";

        private static readonly string Icon = $"{HellknightCodexModule.IconsPath}/orderofthechains.png";

        public static void Configure()
        {
            var favoredWeaponType = WeaponCategory.Flail;
            var favoredWeaponReference = WeaponTypeRefs.Flail.Reference.Get();

            FeatureConfigurator.New(OrderName, OrderGuid)
                .AddToFeatureSelection(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
                .AddProficiencies(weaponProficiencies: [favoredWeaponType])
                .AddWeaponCategoryAttackBonus(1, favoredWeaponType, ModifierDescriptor.Enhancement)
                .AddCMBBonusForManeuver(maneuvers: [CombatManeuver.Trip], value: 2)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddCMBBonusForManeuver(checkedFact: OrderGuid, maneuvers: [CombatManeuver.Trip], value: 2)
                .Configure();

            HellknightOrderConfigurator.SetupFeats(
                orderGuid: OrderGuid,
                favoredWeaponType: favoredWeaponType,
                favoredWeaponReference: favoredWeaponReference);

            FeatureConfigurator.New(FakeOrderName, FakeOrderGuid)
                .AddPrerequisiteFeature(OrderGuid)
                .AddToFeatureSelection(HellknightOrderSelection.FakeOrderSelector)
                .SetHideNotAvailibleInUI(true)
                .SetHideInCharacterSheetAndLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}