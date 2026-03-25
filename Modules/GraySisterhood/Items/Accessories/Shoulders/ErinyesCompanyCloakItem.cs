using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Equipment;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Accessories.Shoulders;

internal class ErinyesCompanyCloakItem
{
    public static readonly string Guid = "{7cfe1f5b-6bba-43dc-932b-14d3a37178de}";

    private static readonly string ItemName = "ErinyesCompanyCloakItem";
    private static readonly string DisplayName = $"{ItemName}.Name";
    private static readonly string Description = $"{ItemName}.Description";

    private static readonly Sprite Icon = ItemEquipmentShouldersRefs.BloodClarityItem.Reference.Get().Icon;

    internal static void Configure()
    {
        Ability.Configure();

        ItemEquipmentShouldersConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: ItemEquipmentShouldersRefs.BloodClarityItem.ToString(), typeof(ArmorVisualParameters))
            .SetEnchantments([EquipmentEnchantmentRefs.Resistance2.ToString()])
            .SetWeight(5f)
            .SetCost(0)
            .SetCR(0)
            .SetAbility(ability: Ability.Guid)
            .SetCharges(3)
            .SetRestoreChargesOnRest(true)
            .SetDestructible(true)
            .SetShardItem(ItemRefs.ClothShardItem.ToString())
            .SetInventoryPutSound(SoundGlossary.ShoulderPut)
            .SetInventoryTakeSound(SoundGlossary.ShoulderTake)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{a4b70235-3aff-4d05-9925-afc622e8a5f4}";

        private static readonly string AbilityName = $"{ItemName}.Ability";

        internal static void Configure()
        {
            var duration = ContextDuration.Fixed(value: 10, rate: DurationRate.Minutes);
            var action = ActionsBuilder.New().ApplyBuff(buff: BuffRefs.WingsAngelBlack.ToString(), durationValue: duration);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(actions: action)
                .SetCanTargetSelf()
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }

}
