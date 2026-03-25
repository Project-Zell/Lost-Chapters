using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class DevilDanceFeatureSelection
    {
        public static readonly string Guid = "{21a19a30-1e5e-47e5-a7a3-aa40326deb0f}";

        private static readonly string FeatureName = "DevilDance";
        private static readonly string DisplayName = "DevilDance.Name";
        private static readonly string Description = "DevilDance.Description";

        internal static void Configure()
        {
            FeatureSelectionConfigurator.New(FeatureName, Guid)
                .AddToAllFeatures(
                    FeatureRefs.TwoWeaponFightingImproved.ToString(),
                    FeatureRefs.TwoWeaponFightingGreater.ToString(),

                    FeatureRefs.DoubleSlice.ToString(),
                    FeatureRefs.ShieldMaster.ToString(),
                    FeatureRefs.BashingFinish.ToString(),
                    FeatureRefs.StumblingBash.ToString(),
                    FeatureRefs.TopplingBash.ToString(),

                    FeatureRefs.WeaponFocusLightShield.ToString(),
                    FeatureRefs.WeaponSpecializationLightShield.ToString(),
                    FeatureRefs.ImprovedCriticalLightShield.ToString(),

                    FeatureRefs.GreaterBullRush.ToString(),
                    
                    FeatureRefs.AgileManeuvers.ToString())
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
