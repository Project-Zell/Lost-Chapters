using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Mechanics.Components;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.DisciplineOld
{
    internal class HellknighDedicationFeature
    {
        public static readonly string Guid = "3e05812c-83be-40db-b2fc-52906585c640";

        private const string FeatName = "HellknighDedication";
        private const string DisplayName = "HellknighDedication.BuffName";
        private const string Description = "HellknighDedication.LocalizedDescription";

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(
                    classes: [CharacterClassRefs.HellknightClass.ToString(), CharacterClassRefs.HellknightSigniferClass.ToString()]))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
