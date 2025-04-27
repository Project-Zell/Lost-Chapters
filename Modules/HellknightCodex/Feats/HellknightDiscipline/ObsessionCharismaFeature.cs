using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class ObsessionCharismaFeature
    {
        public static readonly string FeatGuid = "f8dcc3b1-2378-4975-a4bd-f9e8469451f2";

        private const string FeatName = "ObsessionCharisma";
        private const string DisplayName = "ObsessionCharisma.BuffName";
        private const string Description = "ObsessionCharisma.LocalizedDescription";

        public static void Configure()
        {
            var feat = FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var entity = new AddStatBonusIfHasFactFixed(
                stat: StatType.Charisma,
                bonus: ContextValues.Rank(AbilityRankType.StatBonus),
                requiredFacts: [feat]);

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddStatBonusIfHasFactFixed(entity)
                .Configure();
        }
    }
}
