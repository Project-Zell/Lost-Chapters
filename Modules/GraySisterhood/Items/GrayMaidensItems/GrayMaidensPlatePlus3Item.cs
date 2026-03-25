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

internal class GrayMaidensPlatePlus3Item
{
    public static readonly string Guid = "{c240a890-d059-44e1-8ff0-82e329e2f5c3}";

    private static readonly string ItemName    = "GrayMaidensPlatePlus3Item";
    private static readonly string DisplayName = "GrayMaidensPlatePlus3Item.Name";
    private static readonly string Description = "GrayMaidensPlatePlus3Item.Description";

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
                ArmorEnchantmentRefs.ArmorEnhancementBonus3.ToString(),
                BenevolentArmorEnchantment.Reference])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}