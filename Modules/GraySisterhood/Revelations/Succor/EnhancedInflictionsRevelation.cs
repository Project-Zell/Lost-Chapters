using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using System.Collections.Generic;
using static LostChapters.Modules.GraySisterhood.Revelations.OracleSuccorMysteryFeature;

namespace LostChapters.Modules.GraySisterhood.Revelations.Succor;

internal class EnhancedInflictionsRevelation
{
    public static readonly string Guid = "{fe77727f-dd80-4d65-92ac-5cb44054c239}";

    private static readonly string FeatureName = "EnhancedInflictionsRevelation";
    private static readonly string DisplayName = "EnhancedInflictionsRevelation.Name";
    private static readonly string Description = "EnhancedInflictionsRevelation.Description";

    public static void Configure()
    {
        List<Blueprint<BlueprintAbilityReference>> inflictSpells =
        [
            AbilityRefs.InflictLightWounds.Reference.Get(),
            AbilityRefs.InflictLightWoundsCast.Reference.Get(),
            AbilityRefs.InflictLightWoundsDamage.Reference.Get(),

            AbilityRefs.InflictModerateWounds.Reference.Get(),
            AbilityRefs.InflictModerateWoundsCast.Reference.Get(),
            AbilityRefs.InflictModerateWoundsDamage.Reference.Get(),

            AbilityRefs.InflictSeriousWounds.Reference.Get(),
            AbilityRefs.InflictSeriousWoundsCast.Reference.Get(),
            AbilityRefs.InflictSeriousWoundsDamage.Reference.Get(),

            AbilityRefs.InflictCriticalWounds.Reference.Get(),
            AbilityRefs.InflictCriticalWoundsCast.Reference.Get(),
            AbilityRefs.InflictCriticalWoundsDamage.Reference.Get(),

            AbilityRefs.InflictLightWoundsMass.Reference.Get(),
            AbilityRefs.InflictLightWoundsMassDamage.Reference.Get(),

            AbilityRefs.InflictModerateWoundsMass.Reference.Get(),
            AbilityRefs.InflictModerateWoundsDamage.Reference.Get(),

            AbilityRefs.InflictSeriousWoundsMass.Reference.Get(),
            AbilityRefs.InflictSeriousWoundsMassDamage.Reference.Get(),

            AbilityRefs.InflictCriticalWoundsMass.Reference.Get(),
            AbilityRefs.InflictCriticalWoundsMassDamage.Reference.Get(),
        ];

        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.OracleRevelation)
            .AddUnlimitedSpell(inflictSpells)
            .AddPrerequisiteFeaturesFromList(
                amount: 1,
                features: [OracleSuccorMysteryFeature.Guid, DivineHerbalistVariation.Guid, EnlightenedPhilosopherVariation.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}