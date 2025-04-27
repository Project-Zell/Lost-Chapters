using BlueprintCore.Blueprints.Configurators.Items.Weapons;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Enums;
using Kingmaker.ResourceLinks;
using LostChapters.Enchantment;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.Weapons;

internal class BastardSwordPlus3BenevolentShockFrostItem
{
    public static readonly string Guid = "{54ad8fd4-ab0a-4a57-b7d9-0bc1f1d810b1}";

    private static readonly string ItemName = "BastardSwordPlus3BenevolentShockFrostItem";
    private static readonly string DisplayName = "BastardSwordPlus3BenevolentShockFrostItem.Name";

    private static readonly Sprite Icon = ItemWeaponRefs.BastardSwordShockPlus2.Reference.Get().Icon;

    internal static void Configure()
    {
        var visualParameters = new WeaponVisualParameters()
        {
            m_WeaponModel = new PrefabLink() { AssetId = "b5aa461a0d813d146bdd6d4a75140648" },
            m_WeaponSheathModelOverride = new PrefabLink() { AssetId = "1f78a2dfc8b4eea44ab92031b76d153e" }
        };

        ItemWeaponConfigurator.New(ItemName, Guid)
            .SetCost(cost: 50000)
            .SetInventoryPutSound(SoundGlossary.SwordPut)
            .SetInventoryTakeSound(SoundGlossary.SwordTake)
            .SetCR(cR: 11)
            .SetVisualParameters(visualParameters)
            .SetType(WeaponTypeRefs.BastardSword.ToString())
            .SetSize(Size.Medium)
            .SetEnchantments(enchantments: [
                BenevolentWeaponEnchantment.Reference,
                WeaponEnchantmentRefs.Shock.ToString(),
                WeaponEnchantmentRefs.Frost.ToString(),
                WeaponEnchantmentRefs.Enhancement3.ToString()])
            .SetDisplayNameText(DisplayName)
            .SetIcon(Icon)
            .Configure();
    }
}
