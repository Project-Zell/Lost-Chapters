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

internal class GrayMaidensPlatePlus4Item
{
    public static readonly string Guid = "{ef95d3aa-e456-4391-a58b-5880c4131de7}";

    private static readonly string ItemName    = "GrayMaidensPlatePlus4Item";
    private static readonly string DisplayName = "GrayMaidensPlatePlus4Item.Name";
    private static readonly string Description = "GrayMaidensPlatePlus4Item.Description";

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
                ArmorEnchantmentRefs.ArmorEnhancementBonus4.ToString(),
                BenevolentArmorEnchantment.Reference])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}