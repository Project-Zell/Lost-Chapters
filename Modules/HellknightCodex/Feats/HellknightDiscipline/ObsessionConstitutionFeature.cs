using BlueprintCore.Blueprints.Components.Replacements;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class ObsessionConstitutionFeature
    {
        public static readonly string FeatGuid = "4df854e2-067d-4a2f-a618-1d2b739db166";

        private const string FeatName = "ObsessionConstitution";
        private const string DisplayName = "ObsessionConstitution.BuffName";
        private const string Description = "ObsessionConstitution.LocalizedDescription";

        public static void Configure()
        {
            var feat = FeatureConfigurator.New(FeatName, FeatGuid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();

            var entity = new AddStatBonusIfHasFactFixed(
                stat: StatType.Constitution,
                bonus: ContextValues.Rank(AbilityRankType.StatBonus),
                requiredFacts: [feat]);

            BuffConfigurator.For(HellknightObidienceBuff.Guid)
                .AddStatBonusIfHasFactFixed(entity)
                .Configure();
        }
    }
}
