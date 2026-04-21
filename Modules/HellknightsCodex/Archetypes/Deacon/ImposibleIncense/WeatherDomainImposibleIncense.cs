using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense
{
    internal class WeatherDomainImposibleIncense
    {
        public static readonly string Guid = "{a5ba00b5-4485-4fc4-86a1-9cfc9b75129c}";

        private static readonly string FeatureName = "WeatherDomainImposibleIncense";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        private static readonly string Domain = FeatureRefs.WeatherDomainAllowed.ToString();
        private static readonly string MinorFeatureGuid = WeatherDomainIncense.MinorFeature.Guid;
        private static readonly string MajorFeatureGuid = WeatherDomainIncense.MajorFeature.Guid;

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
            public static readonly string Guid = "{5a4f8b5d-0214-44bb-b82a-0849b000ca7e}";

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
