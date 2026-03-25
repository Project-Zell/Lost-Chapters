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

internal class GrayMaidensPlateItem
{
    public static readonly string Guid = "{0c24545b-98dd-4cd1-9248-ccca2af3a2b0}";

    private static readonly string ItemName    = "GrayMaidensPlateItem";
    private static readonly string DisplayName = "GrayMaidensPlateItem.Name";
    private static readonly string Description = "GrayMaidensPlateItem.Description";

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
            .SetEnchantments(enchantments:[BenevolentArmorEnchantment.Reference])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
