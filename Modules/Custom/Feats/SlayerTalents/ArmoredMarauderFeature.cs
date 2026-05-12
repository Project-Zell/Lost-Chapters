using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;

namespace LostChapters.Modules.Custom.Feats.SlayerTalents;

internal class ArmoredMarauderFeature
{
    public static readonly string Guid = "{9a3ee3ff-bb80-4840-affe-48ac025953ea}";

    private static readonly string FeatureName = "ArmoredMarauderFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        var value = ContextValues.Rank();
        var config = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.SlayerClass.ToString()], min: 0, max: 4).WithDivStepProgression(6);

        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.SlayerTalent)
            .AddToFeatureSelection([
                FeatureSelectionRefs.SlayerTalentSelection2.ToString(),
                FeatureSelectionRefs.SlayerTalentSelection6.ToString(),
                FeatureSelectionRefs.SlayerTalentSelection10.ToString(),
            ])
            .AddFacts([FeatureRefs.HeavyArmorProficiency.ToString()])
            .AddArmorCheckPenaltyIncrease(bonus: value, checkCategory: true, category: ArmorProficiencyGroup.Heavy)
            .AddToIsPrerequisiteFor([ArmoredSwiftnessFeature.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }
}
