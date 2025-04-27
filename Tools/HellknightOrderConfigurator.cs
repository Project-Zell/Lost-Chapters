   using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.EnneadStar;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Tools
{
    internal class HellknightOrderConfigurator
    {
        public static void SetupFeats(string orderGuid, WeaponCategory favoredWeaponType, BlueprintWeaponType favoredWeaponReference)
        {
            var orderFavoredWeaponToChaoticCondition = ConditionsBuilder.New()
                .CasterHasFact(orderGuid)
                .Alignment(AlignmentComponent.Chaotic)
                .IsWeaponEquipped(category: favoredWeaponType, checkWeaponCategory: true, checkOnCaster: true);

            FeatureConfigurator.For(OrderOfTheEnneadStar.OpressGuid)
                .AddAttackBonusConditional(bonus: 1, conditions: orderFavoredWeaponToChaoticCondition)
                .AddDamageBonusConditional(bonus: 1, conditions: orderFavoredWeaponToChaoticCondition)
                .Configure();

            FeatureConfigurator.For(HellknighDedicationFeature.Guid)
                .AddDamageBonusConditional(bonus: ContextValues.Rank(), conditions: orderFavoredWeaponToChaoticCondition)
                .Configure();

            HellknightDevotion devotion = new() { WeaponType = favoredWeaponReference, OrderBlueprint = orderGuid };

            FeatureConfigurator.For(HellknightDevotionFeature.Guid)
                .AddComponent(devotion)
                .Configure();
        }
    }
}
