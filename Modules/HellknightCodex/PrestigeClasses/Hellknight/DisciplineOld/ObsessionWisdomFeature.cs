using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.DisciplineOld
{
    internal class ObsessionWisdomFeature
    {
        public static readonly string FeatGuid = "46285a83-414c-46fe-9610-b992d742165a";

        private const string FeatName = "ObsessionWisdom";
        private const string DisplayName = "ObsessionWisdom.BuffName";
        private const string Description = "ObsessionWisdom.LocalizedDescription";

        public static void Configure()
        {
            var feat = FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var entity = new AddStatBonusIfHasFactFixed(
                stat: StatType.Wisdom,
                bonus: ContextValues.Rank(AbilityRankType.StatBonus),
                requiredFacts: [feat]);
        }
    }
}
