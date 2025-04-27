using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class ObsessionDexterityFeature
    {
        public static readonly string FeatGuid = "61327af7-6308-4547-b628-3255619d9fbb";

        private const string FeatName = "ObsessionDexterity";
        private const string DisplayName = "ObsessionDexterity.BuffName";
        private const string Description = "ObsessionDexterity.LocalizedDescription";

        public static void Configure()
        {
            var feat = FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var entity = new AddStatBonusIfHasFactFixed(
                stat: StatType.Dexterity,
                bonus: ContextValues.Rank(AbilityRankType.StatBonus),
                requiredFacts: [feat]);

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddStatBonusIfHasFactFixed(entity)
                .Configure();
        }
    }
}
