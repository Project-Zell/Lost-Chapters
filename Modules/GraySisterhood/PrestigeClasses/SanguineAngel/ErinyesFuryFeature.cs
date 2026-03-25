using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class ErinyesFuryFeature
    {
        public static readonly string Guid = "{5df15aa7-2a0c-409f-a48b-cd4eec3a10ba}";

        private static readonly string FeatureName = "ErinyesFury";
        private static readonly string DisplayName = "ErinyesFury.Name";
        private static readonly string Description = "ErinyesFury.Description";

        internal static void Configure()
        {
            var rankConfig = ContextRankConfigs.ClassLevel([SanguineAngelClass.Guid]).WithMultiplyByModifierProgression(2);

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([DeadCalmFeature.Guid])
                .AddIncreaseResourceAmountBySharedValue(resource: DeadCalmFeature.Resource.Guid, value: ContextValues.Rank())
                .AddContextRankConfig(rankConfig)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
