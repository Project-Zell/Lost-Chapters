using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;

namespace LostChapters.Modules.Custom.Feats;

internal class ArmoredSwiftnessFeature
{
    public static readonly string Guid = "{ed608e24-1755-4251-a13f-8d3709efa564}";

    private static readonly string FeatureName = "ArmoredSwiftnessFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        var value = ContextValues.Rank();
        var config = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.SlayerClass.ToString()], min: 0, max: 4).WithDivStepProgression(6);

        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.SlayerTalent)
            .AddToFeatureSelection([FeatureSelectionRefs.SlayerTalentSelection10.ToString()])
            .AddPrerequisiteFeature(ArmoredMarauderFeature.Guid)
            .AddPrerequisiteFeature(FeatureRefs.AdvanceTalents.ToString())
            .AddMaxDexBonusIncrease(contextBonus: value, checkCategory: true, category: ArmorProficiencyGroup.Heavy)
            .AddContextRankConfig(config)
            .AddArmorSpeedPenaltyRemoval()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
