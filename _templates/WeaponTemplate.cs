using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Enums;
using UnityEngine;

namespace LostChapters._templates;

internal class WeaponTemplate
{
    public static readonly string Guid = "";

    private static readonly string ItemName    = "";
    private static readonly string DisplayName = $"{ItemName}.Name";
    private static readonly string Description = $"{ItemName}.Description";
    //private static readonly string FlavorText  = $"{ItemName}.Flavor";

    private static readonly Sprite Icon = null;

    internal static void Configure()
    {
        ItemWeaponConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: null, typeof(ArmorVisualParameters))
            .AddEquipmentRestrictionClass(clazz: CharacterClassRefs.DragonClass.ToString(), not: true)
            .SetType(null)
            .SetSize(Size.Medium)
            .SetEnchantments([])
            .SetCost(0)
            .SetCR(0)
            .SetDestructible(true)
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            //.SetFlavorText(FlavorText)
            .SetIcon(Icon)
            .Configure();
    }
}
