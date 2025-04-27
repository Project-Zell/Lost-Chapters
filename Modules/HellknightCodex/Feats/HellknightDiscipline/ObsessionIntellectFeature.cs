using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class ObsessionIntellectFeature
    {
        public static readonly string FeatGuid = "0d7b702c-7ce1-41e7-bc0a-02f287750a92";

        private const string FeatName = "ObsessionIntellect";
        private const string DisplayName = "ObsessionIntellect.BuffName";
        private const string Description = "ObsessionIntellect.LocalizedDescription";

        public static void Configure()
        {
            var feat = FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var entity = new AddStatBonusIfHasFactFixed(
                stat: StatType.Intelligence,
                bonus: ContextValues.Rank(AbilityRankType.StatBonus),
                requiredFacts: [feat]);

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddStatBonusIfHasFactFixed(entity)
                .Configure();
        }
    }
}
