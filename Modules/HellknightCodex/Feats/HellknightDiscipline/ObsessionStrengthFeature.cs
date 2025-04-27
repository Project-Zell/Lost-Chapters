using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class ObsessionStrengthFeature
    {
        public static readonly string FeatGuid = "f0444713-7f61-4889-863d-ad206eecae01";

        private const string FeatName = "ObsessionStrength";
        private const string DisplayName = "ObsessionStrength.BuffName";
        private const string Description = "ObsessionStrength.LocalizedDescription";

        public static void Configure()
        {
            var feat = FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var entity = new AddStatBonusIfHasFactFixed(
                stat: StatType.Strength,
                bonus: ContextValues.Rank(AbilityRankType.StatBonus),
                requiredFacts: [feat]);

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddStatBonusIfHasFactFixed(entity)
                .Configure();
        }
    }
}
