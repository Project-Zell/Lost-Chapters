using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Components;
using LostChapters.Modules.Custom.Feats;
using LostChapters.Modules.GraySisterhood.Feats;
using static LostChapters.Modules.GraySisterhood.Revelations.OracleSuccorMysteryFeature;

namespace LostChapters.Modules.GraySisterhood.Revelations.Succor;

internal class TeamworkMasteryRevelation
{
    public static readonly string Guid = "{92d743b7-28c4-46be-9ea3-e7fdab2ff85d}";

    private static readonly string FeatureName = "TeamworkMastery";
    private static readonly string DisplayName = "TeamworkMastery.Name";
    private static readonly string Description = "TeamworkMastery.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.OracleRevelation)
            .AddFacts([Ability.Guid])
            .AddAbilityResources(resource: Resource.Guid, restoreAmount: true)
            .AddPrerequisiteFeaturesFromList(
                amount: 1,
                features: [OracleSuccorMysteryFeature.Guid, DivineHerbalistVariation.Guid, EnlightenedPhilosopherVariation.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{b87775a5-ffe7-435d-8312-abd2d4853ad2}";

        private static readonly string AbilityName = "TeamworkMasteryAbility";
        internal static void Configure()
        {
            //TODO FVX and Icon
            var durationConfig = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.OracleClass.ToString()], min: 1, max: 20).WithOnePlusDiv2Progression();
            var duration = ContextDuration.Variable(ContextValues.Rank());

            AbilityConfigurator.New(AbilityName, Guid)
            .AddAbilityResourceLogic(amount: 1, requiredResource: Resource.Guid, isSpendResource: true)
            .AddContextRankConfig(durationConfig)
            .AddAbilityApplyFact(
                facts: [
                    BuffRefs.CavalierTacticianAlliedSpellcasterBuff.ToString(),
                    BuffRefs.CavalierTacticianBackToBackBuff.ToString(),
                    BuffRefs.CavalierTacticianCoordinatedDefenseBuff.ToString(),
                    BuffRefs.CavalierTacticianCoordinatedManeuversBuff.ToString(),
                    BuffRefs.CavalierTacticianOutflankBuff.ToString(),
                    BuffRefs.CavalierTacticianPreciseStrikeBuff.ToString(),
                    BuffRefs.CavalierTacticianShakeItOffBuff.ToString(),
                    BuffRefs.CavalierTacticianShieldedCasterBuff.ToString(),
                    BuffRefs.CavalierTacticianShieldWallBuff.ToString(),
                    BuffRefs.CavalierTacticianSiezeTheMomentBuff.ToString(),
                    BuffRefs.CavalierTacticianTandemTripBuff.ToString(),
                    BuffRefs.CavalierTacticianVolleyFireBuff.ToString(),

                    HarryingPartnersFeature.CavalierBuffGuid.ToString(),
                    ScarredLegionFeature.CavalierBuffGuid.ToString(),
                    DistractingChargeFeature.CavalierBuffGuid.ToString()
                    ],
                restriction: AbilityApplyFact.FactRestriction.CasterHasFact,
                hasDuration: true,
                duration: duration)
            .AllowTargeting(point: false, enemies: false, friends: true, self: false)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
        }
    }

    internal class Resource
    {
        public static readonly string Guid = "{8433973a-f48f-482d-9233-5454c3b7c801}";

        private static readonly string ResourceName = "TeamworkMasteryResource";
        internal static void Configure()
        {
            var resourceBuilder = ResourceAmountBuilder.New(3)
                .IncreaseByStat(StatType.Charisma)
                .Build();

            AbilityResourceConfigurator.New(ResourceName, Guid)
                .SetMaxAmount(resourceBuilder)
                .Configure();
        }
    }
}
