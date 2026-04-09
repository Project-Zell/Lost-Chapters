using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Mechanics.Components;
using UnityEngine;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Codex;

internal class DelegatedJudgmentProgression
{
    public static readonly string Guid = "{13621a8d-51fe-460d-a539-05c0d18c7d88}";

    private static readonly string FeatureName = "DelegatedJudgment";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        InitialFeature.Configure();

        ProgressionConfigurator.New(FeatureName, Guid)
            .AddPrerequisiteFeature(FeatureRefs.JudgmentFeature.ToString())
            .SetClasses([CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()])
            .AddToLevelEntry(level: 01, features: InitialFeature.Guid)
            .AddToLevelEntry(level: 05, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddToLevelEntry(level: 10, features: FeatureRefs.JudgmentAdditionalUse.ToString())
            .AddToUIGroups([InitialFeature.Guid, FeatureRefs.JudgmentAdditionalUse.ToString()])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class InitialFeature
    {
        public static readonly string Guid = "{adf02c6b-fab8-408c-8836-81b1b4b71433}";

        private static readonly string FeatureName = "DelegatedJudgment.InitialFeature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        private static readonly Sprite Icon = FeatureRefs.JudgmentAdditionalUse.Reference.Get().Icon;

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddFeatureOnClassLevel()
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}
