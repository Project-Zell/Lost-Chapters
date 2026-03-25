using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Enchantments;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Unique;

internal class EyeOfScornItem
{
    public static readonly string Guid = "{eb96c83f-805e-413e-9129-d9975bf84807}";

    private static readonly string ItemName    = "EyeOfScornItem";
    private static readonly string DisplayName = "EyeOfScornItem.Name";
    private static readonly string Description = "EyeOfScornItem.Description";

    private static readonly Sprite Icon = ItemWeaponRefs.UnexpectedResolutionItem.Reference.Get().Icon;

    internal static void Configure()
    {
        ItemWeaponConfigurator.New(ItemName, Guid)
            .CopyFrom(blueprint: ItemWeaponRefs.UnexpectedResolutionItem, typeof(WeaponVisualParameters))
            .SetType(WeaponTypeRefs.Shortsword.ToString())
            .SetSize(Size.Medium)
            .SetAbility(ability: AbilityRefs.SenseVitals.ToString())
            .SetCasterLevel(14)
            .SetSpellLevel(14)
            .SetCharges(4)
            .SetCost(cost: 120000)
            .SetCR(cR: 20)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Heartseeker.ToString(),
                WeaponEnchantmentRefs.Bleed.ToString(),
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
