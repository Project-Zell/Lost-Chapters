using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;

namespace LostChapters.Modules.Custom.Orders.Cavalier.Tome
{
    internal class ArcaneFortressFeature
    {
        public static readonly string Guid = "{794ee13e-c4f1-4804-a19d-413f0c4dc6d1}";

        private static readonly string FeatureName = "ArcaneFortress";
        private static readonly string DisplayName = "ArcaneFortress.Name";
        private static readonly string Description = "ArcaneFortress.Description";

        public static void Configure()
        {
            Fact.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Fact.Guid])
                .AddFactsToPet(facts: [Fact.Guid], petType: PetType.AnimalCompanion)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Fact
        {
            public static readonly string Guid = "{53b75d43-2e28-45c1-b585-8a2123bb970f}";

            private static readonly string FeatureName = "ArcaneFortress.Fact";

            public static void Configure()
            {
                FeatureConfigurator.New(FeatureName, Guid)
                    .AddSavingThrowBonusAgainstAbilityType(bonus: 2, abilityType: AbilityType.Spell)
                    .AddSavingThrowBonusAgainstAbilityType(bonus: 2, abilityType: AbilityType.SpellLike)
                    .SetHideInCharacterSheetAndLevelUp(true)
                    .SetIsClassFeature(true)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
