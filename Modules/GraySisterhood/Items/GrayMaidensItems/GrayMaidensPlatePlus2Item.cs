using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Enchantments;
using LostChapters.Modules.GraySisterhood.Feats;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.GrayMaidensItems;

internal class GrayMaidensPlatePlus2Item
{
    public static readonly string Guid = "{e045627c-12ba-49b9-9ead-4f5d9cced9c0}";

    private static readonly string ItemName    = "GrayMaidensPlatePlus2Item";
    private static readonly string DisplayName = "GrayMaidensPlatePlus2Item.Name";
    private static readonly string Description = "GrayMaidensPlatePlus2Item.Description";

    private static readonly Sprite Icon = ItemArmorRefs.MithralFullplate.Reference.Get().Icon;

    internal static void Configure()
    {
        var factRestriction = new EquipmentRestrictionHasFact()
        {
            CheckedFact = BlueprintTool.Get<BlueprintFeature>(GrayMaidensTrainingFeature.Guid)
        };

        ItemArmorConfigurator.New(ItemName, Guid)
            .CopyFrom(ItemArmorRefs.MithralFullplate.ToString(), typeof(ArmorVisualParameters))
            .AddComponent(factRestriction)
            .SetEnchantments(enchantments: [
                ArmorEnchantmentRefs.ArmorEnhancementBonus2.ToString(),
                BenevolentArmorEnchantment.Reference])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
