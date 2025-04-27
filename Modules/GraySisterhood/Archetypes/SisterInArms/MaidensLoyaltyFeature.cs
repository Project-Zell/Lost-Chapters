using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class MaidensLoyaltyFeature
{
    public static readonly string Guid = "{7b1a163f-0e87-403e-8261-db3d5b7d67d3}";

    private static readonly string FeatureName = "MaidensLoyalty";
    private static readonly string DisplayName = "MaidensLoyalty.Name";
    private static readonly string Description = "MaidensLoyalty.Description";

    internal static void Configure()
    {
        var bonusValue = ContextValues.Rank();
        var rankConfig = ContextRankConfigs.ClassLevel([CharacterClassRefs.CavalierClass.ToString()]).WithDivStepProgression(4);

        FeatureConfigurator.New(FeatureName, Guid)
            .AddSavingThrowBonusAgainstDescriptor(value: 1, bonus: bonusValue, spellDescriptor: SpellDescriptor.Charm | SpellDescriptor.Compulsion | SpellDescriptor.Confusion)
            .AddContextRankConfig(rankConfig)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
