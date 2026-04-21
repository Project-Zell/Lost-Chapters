using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense
{
    internal class ScalykindDomainImposibleIncense
    {
        public static readonly string Guid = "{b534bd64-0371-461b-ae18-03081bce97ff}";

        private static readonly string FeatureName = "ScalykindDomainImposibleIncense";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        private static readonly string Domain = FeatureRefs.ScalykindDomainAllowed.ToString();
        private static readonly string MinorFeatureGuid = ScalykindDomainIncense.MinorFeature.Guid;
        private static readonly string MajorFeatureGuid = ScalykindDomainIncense.MajorFeature.Guid;

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
            public static readonly string Guid = "{00783e5b-d8c7-4a9c-8f48-1df095a40915}";

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
