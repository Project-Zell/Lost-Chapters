using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Mechanics;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Tome
{
    internal class LibrarianFeature
    {
        public static readonly string Guid = "{1c17fb13-0a23-4267-9d81-25de5beb9937}";

        private static readonly string FeatureName = "Librarian";
        private static readonly string DisplayName = "Librarian.Name";
        private static readonly string Description = "Librarian.Description";

        internal static void Configure()
        {
            var rankConfig = ContextRankConfigs.ClassLevel(classes: [CharacterClassRefs.CavalierClass.ToString()], min: 1, max: 20).WithDivStepProgression(2);

            FeatureConfigurator.New(FeatureName, Guid)
                .AddContextStatBonus(stat: StatType.SkillUseMagicDevice, value: ContextValues.Rank())
                .AddContextRankConfig(rankConfig)
                .SetReapplyOnLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
