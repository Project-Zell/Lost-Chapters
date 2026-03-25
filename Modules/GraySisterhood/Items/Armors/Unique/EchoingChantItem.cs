using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Armors.Unique;

internal class EchoingChantItem
{
    public static readonly string Guid = "{d7a5708a-1d66-4501-9935-4910abb92299}";

    private static readonly string ItemName    = "EchoingChantItem";
    private static readonly string DisplayName = $"{ItemName}.Name";
    private static readonly string Description = $"{ItemName}.Description";

    private static readonly Sprite Icon = ItemArmorRefs.AdamantineChainshirtPlus5.Reference.Get().Icon;

    internal static void Configure()
    {
        ItemArmorConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: ItemArmorRefs.AdamantineChainshirtPlus5.ToString(), typeof(ArmorVisualParameters))
            .AddEquipmentRestrictionClass(clazz: CharacterClassRefs.DragonClass.ToString(), not: true)
            .SetType(type: ArmorTypeRefs.ChainshirtType.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments([
                ArmorEnchantmentRefs.ArmorEnhancementBonus3.ToString(),
                ArmorEnchantmentRefs.SonicResistance10Enchant.ToString()])
            .SetCost(0)
            .SetAbility(ability: AbilityRefs.GoodHope.ToString())
            .SetCasterLevel(casterLevel: 8)
            .SetSpendCharges(true)
            .SetRestoreChargesOnRest(true)
            .SetCharges(2)
            .SetCR(14)
            .SetDestructible(true)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
