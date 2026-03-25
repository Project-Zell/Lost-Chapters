using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class MadnessDomainIncense
{
    private static readonly string IncenceName = "CrimsonShroud";
    private static readonly string Domain = FeatureRefs.MadnessDomainAllowed.ToString();
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{c4ab735d-30c4-40f4-910a-2ffedbb13821}";

        private static readonly string FeatureName = $"{IncenceName}.MinorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{914a671f-a5f0-45f4-85a0-0610b8f67f0a}";

        private static readonly string FeatureName = $"{IncenceName}.MajorFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddPrerequisiteFeature(Domain, hideInUI: true)
                .AddPrerequisiteFeature(MinorFeature.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class CooldownBuff
    {
        public static readonly string Guid = "{0a86bee1-f033-4b3d-80ed-01a69df26a12}";

        private static readonly string BuffName = $"{IncenceName}.CooldownBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddToFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
