using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.Archetypes.CircuitJudge
{
    internal class CircuitJudgeArchetype
    {
        public static readonly string Guid = "{9bcaea12-1233-4e7a-a26a-c241241a18f8}";

        private static readonly string ArchetypeName = "CircuitJudge";
        private static readonly string LocalizedName = $"{ArchetypeName}.Name";
        private static readonly string Description = $"{ArchetypeName}.Description";

        internal static void Configure()
        {
            //Sentence: A circuit judge can choose one target with a chaotic alignment within sight to sentence as a swift action. The circuit judge's melee attacks deal extra damage whenever they are made against the target of his sentence. This extra damage is equal to the cavalier's level.
            //Sentence also includes another effect which is listed in the section describing the cavalier's order.This ability replaces challenge.
            //Judgment: At 1st level, and every three levels thereafter, a circuit judge gain judgment as a bonus ability.
            //Circuit: A circuit judge adds half his cavalier level (minimum 1) on Intimidate and Knowledge(World).
            //Verdict: Upon using sentence against a chaotic enemy, a circuit judge may make a Persuasion (to intimidate) check as a free action to demoralize the sentenced foe.

            BlueprintCharacterClass parentClass = null;

            var removeFeaturesEntryBuilder = LevelEntryBuilder.New();

            var addFeaturesEntryBuilder = LevelEntryBuilder.New();

            var classSkills = new StatType[]
            {

            };

            ArchetypeConfigurator.New(ArchetypeName, Guid, parentClass)
                .SetReplaceClassSkills(true)
                .SetClassSkills(classSkills)
                .SetAddFeatures(addFeaturesEntryBuilder)
                .SetRemoveFeatures(removeFeaturesEntryBuilder)
                .SetLocalizedName(LocalizedName)
                .SetLocalizedDescription(Description)
                .Configure();
        }
    }
}
