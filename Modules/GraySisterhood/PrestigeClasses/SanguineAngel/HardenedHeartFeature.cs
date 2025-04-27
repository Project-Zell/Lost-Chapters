using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class HardenedHeartFeature
    {
        public static readonly string Guid = "{b0d4925d-4b69-456e-86e9-95bf53fc841c}";

        private static readonly string FeatureName = "HardenedHeart";
        private static readonly string DisplayName = "HardenedHeart.Name";
        private static readonly string Description = "HardenedHeart.Description";

        internal static void Configure()
        {
            var rankCongfig = ContextRankConfigs.ClassLevel([SanguineAngelClass.Guid], max: 20).WithMultiplyByModifierProgression(2);

            FeatureConfigurator.New(FeatureName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(bonus: ContextValues.Rank(), spellDescriptor: SpellDescriptor.Fear | SpellDescriptor.Shaken | SpellDescriptor.Frightened)
                .AddContextRankConfig(rankCongfig)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
