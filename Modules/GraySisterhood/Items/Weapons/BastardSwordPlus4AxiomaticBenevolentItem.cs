using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class BastardSwordPlus4AxiomaticBenevolentItem
{
    public static readonly string Guid = "{f99b6618-d30d-40d2-9323-042f5aaf389c}";

    private static readonly string ItemName = "BastardSwordPlus4AxiomaticBenevolentItem";
    private static readonly string DisplayName = "BastardSwordPlus4AxiomaticBenevolentItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.BastardSwordShockPlus2.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "b5aa461a0d813d146bdd6d4a75140648" },
            m_WeaponSheathModelOverride = new PrefabLink() { AssetId = "1f78a2dfc8b4eea44ab92031b76d153e" }
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 75000)
            .SetInventoryPutSound(SoundGlossary.SwordPut)
            .SetInventoryTakeSound(SoundGlossary.SwordTake)
            .SetCR(cR: 15)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.BastardSword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Axiomatic.ToString(),
                WeaponEnchantmentRefs.Enhancement4.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
