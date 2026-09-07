using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Modules.GraySisterhood.Enchantments;
using LostChapters.Tools.Glossaries;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons.Exotic;

internal class BastardSwordPlus5AxiomaticBenevolentItem
{
    public static readonly string Guid = "{f99b6618-d30d-40d2-9323-042f5aaf389c}";

    private static readonly string ItemName = "BastardSwordPlus5AxiomaticBenevolentItem";
    private static readonly string DisplayName = "BastardSwordPlus5AxiomaticBenevolentItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.BastardSwordShockPlus2.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_Projectiles = [],
            m_PossibleAttachSlots = [],
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
                WeaponEnchantmentRefs.Enhancement5.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
