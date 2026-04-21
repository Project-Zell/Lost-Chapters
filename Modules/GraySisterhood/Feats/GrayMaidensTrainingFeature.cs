using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood.Feats
{
    internal class GrayMaidensTrainingFeature
    {
        public static readonly string Guid = "{770ab6cc-c258-4f66-82ec-ae610b58f8e4}";

        private static readonly string FeatureName = "GrayMaidensTraining";
        private static readonly string DisplayName = "GrayMaidensTraining.Name";
        private static readonly string Description = "GrayMaidensTraining.Description";

        private static readonly string Icon = $"{GraySisterhoodModule.IconsPath}/graymaidenstraining.png";

        public static void Configure()
        {
            var genderCondition = Toolbox.GenderCondition(Gender.Female);

            FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat)
                .AddComponent<GrayMaidensTraining>()
                .AddPrerequisiteStatValue(stat: StatType.SkillKnowledgeWorld, value: 3)
                .AddPrerequisiteCondition(condition: genderCondition, uIText: "Gender: Female")
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();
        }
    }
}
