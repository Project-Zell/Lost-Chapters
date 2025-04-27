using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class MaidensShieldFeature
    {
        public static readonly string Guid = "{01e4fe56-f48b-4724-a83c-0f80f2775f92}";

        private static readonly string FeatureName = "MaidensShield";
        private static readonly string DisplayName = "MaidensShield.Name";
        private static readonly string Description = "MaidensShield.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([FeatureRefs.TwoWeaponFighting.ToString()])
                .AddReplaceStatForPrerequisites(oldStat: StatType.Dexterity, newStat: StatType.Strength)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
