using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense
{
    internal class SunDomainImposibleIncense
    {
        public static readonly string Guid = "{ec560c29-6e58-4b2b-8130-f28cba73c795}";

        private static readonly string FeatureName = "SunDomainImposibleIncense";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        private static readonly string Domain = FeatureRefs.SunDomainAllowed.ToString();
        private static readonly string MinorFeatureGuid = SunDomainIncense.MinorFeature.Guid;
        private static readonly string MajorFeatureGuid = SunDomainIncense.MajorFeature.Guid;

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteNoFeature(feature: Domain, checkInProgression: true, hideInUI: true)
                .AddFacts([Progression.Guid])
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }

        internal class Progression
        {
            public static readonly string Guid = "{a580716d-a787-4e0b-bc3e-be721c5b0ee1}";

            private static readonly string ProgressionName = $"{FeatureName}.Progression";

            internal static void Configure()
            {
                ProgressionConfigurator.New(ProgressionName, Guid)
                    .AddToLevelEntries(level: 01, features: MinorFeatureGuid)
                    .AddToLevelEntries(level: 10, features: MajorFeatureGuid)
                    .SetClasses(classes: CharacterClassRefs.WarpriestClass.ToString())
                    .SetIsClassFeature(true)
                    .SetHideInUI()
                    .Configure();
            }
        }
    }
}
