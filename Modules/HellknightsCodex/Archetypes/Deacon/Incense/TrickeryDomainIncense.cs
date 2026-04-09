using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;

internal class TrickeryDomainIncense
{
    private static readonly string IncenceName = "DeceptiveFog";
    private static readonly string Domain = FeatureRefs.TrickeryDomainAllowed.ToString();
    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{1167b502-d495-4bcc-a6a3-7fc1eb6ca1a9}";

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
        public static readonly string Guid = "{313498ed-6d1c-4e4a-90a2-c0ce9ba5ea5f}";

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
        public static readonly string Guid = "{eaabb82f-6b3a-4c4c-891c-5d0e9cdcb5d9}";

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
