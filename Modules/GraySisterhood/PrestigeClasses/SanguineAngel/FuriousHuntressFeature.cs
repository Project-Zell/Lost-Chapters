using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel
{
    internal class FuriousHuntressFeature
    {
        public static readonly string Guid = "{ada49879-d21f-4a45-8032-06d49f9a3172}";

        private static readonly string FeatureName = "FuriousHuntress";
        private static readonly string DisplayName = "FuriousHuntress.Name";
        private static readonly string Description = "FuriousHuntress.Description";

        internal static void Configure()
        {
            var bowStatReplacement = new AttackStatReplacementFixed(
                replacementStat: StatType.Strength,
                weaponTypes: [
                    WeaponTypeRefs.Longbow.ToString(),
                    WeaponTypeRefs.Shortbow.ToString(),
                    WeaponTypeRefs.LightCrossbow.ToString(),
                    WeaponTypeRefs.HeavyCrossbow.ToString()]);

            FeatureConfigurator.New(FeatureName, Guid)
                .AddAttackStatReplacementFixed(bowStatReplacement)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
