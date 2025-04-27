using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;
using LostChapters.Modules.GraySisterhood.Feats.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightDiscipline
{
    internal class NoEscapeFeature
    {
        public static readonly string Guid = "953a0c7f-5317-4aa7-8a93-c68bb8c9a91c";

        private const string FeatName = "NoEscape";
        private const string DisplayName = "NoEscape.BuffName";
        private const string Description = "NoEscape.LocalizedDescription";

        public static void Configure()
        {
            BuffConfigurator.For(BuffRefs.Shaken.ToString())
                .AddAttackBonusAgainstFactOwner(attackBonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
                .AddSavingThrowBonusAgainstFact(value: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
                .AddACBonusAgainstFactOwner(bonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
                .Configure(true);

            BuffConfigurator.For(BuffRefs.Frightened.ToString())
                .AddAttackBonusAgainstFactOwner(attackBonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
                .AddSavingThrowBonusAgainstFact(value: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
                .AddACBonusAgainstFactOwner(bonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
                .Configure(true);

            FeatureConfigurator.New(FeatName, Guid)
                .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
