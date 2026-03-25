using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class UnyieldingFeature
    {
        public static readonly string Guid = "{f34973b5-34a8-4baa-9ca6-6fc455f27497}";

        private static readonly string FeatureName = "Unyielding";
        private static readonly string DisplayName = "Unyielding.Name";
        private static readonly string Description = "Unyielding.Description";

        internal static void Configure()
        {
            var contextValue = ContextValues.Rank();
            var rankConfig = ContextRankConfigs.ClassLevel([SanguineAngelClass.Guid])
                .WithStartPlusDivStepProgression(divisor: 2, start: 6, delayStart: true);

            FeatureConfigurator.New(FeatureName, Guid)
                .AddDamageResistancePhysical(isStackable: true, value: contextValue)
                .AddContextRankConfig(rankConfig)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
