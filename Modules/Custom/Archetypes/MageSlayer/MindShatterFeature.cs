using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.Archetypes.MageSlayer;

internal class MindShatterFeature
{
    public static readonly string Guid = "{2c93f6fa-b45b-4123-8ee8-4782f1d17be1}";

    private static readonly string FeatureName = $"MindShatterFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Buff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<MindShatterOwner>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetRanks(5)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{20bcc78b-e415-401b-a890-297ae265713a}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<MindShatterTarget>()
                .AddRemoveBuffIfCasterIsMissing(removeOnCasterDeath: true)
                .AddUniqueBuff()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
