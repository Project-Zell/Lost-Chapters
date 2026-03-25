using BlueprintCore.Blueprints.Configurators.Items.Armors;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Enchantments;
using LostChapters.Modules.GraySisterhood.Feats;
using UnityEngine;

namespace LostChapters.Modules.GraySisterhood.Items.GrayMaidensItems;

internal class MaidensPanoplyItem
{
    public static readonly string Guid = "{6dc2afa8-5b50-4e93-bcde-603bf18608b9}";

    private static readonly string ItemName    = "MaidensPanoplyItem";
    private static readonly string DisplayName = "MaidensPanoplyItem.Name";
    private static readonly string Description = "MaidensPanoplyItem.Description";

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
            .SetEnchantments([
                ArmorEnchantmentRefs.ArmorEnhancementBonus5.ToString(),
                BenevolentArmorEnchantment.Reference])
            .SetDisplayNameText(DisplayName)
            .SetDescriptionText(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class Feature
    {
        public static readonly string Guid = "{3a1603bc-cd1d-4c42-a22e-865ebe93d519}";

        private static readonly string FeatureName = "MaidensPanoply.Feature";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddStatBonus(stat: StatType.Initiative, value: 2, descriptor: ModifierDescriptor.Insight)
                .AddStatBonus(stat: StatType.SaveReflex, value: 2, descriptor: ModifierDescriptor.Resistance)
                .SetDisplayName(DisplayName)
                .Configure();
        }
    }
}
