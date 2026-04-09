using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Enums;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight.Discipline;

internal class NoEscapeFeature
{
    public static readonly string Guid = "{3cc0c059-d5fb-46a7-8362-1c71bfe1283c}";

    private static readonly string FeatureName = "NoEscapeFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        BuffConfigurator.For(BuffRefs.Shaken.ToString())
            .AddAttackBonusAgainstFactOwner(attackBonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
            .AddSavingThrowBonusAgainstFact(value: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
            .AddACBonusAgainstFactOwner(bonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
            .Configure();

        BuffConfigurator.For(BuffRefs.Frightened.ToString())
            .AddAttackBonusAgainstFactOwner(attackBonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
            .AddSavingThrowBonusAgainstFact(value: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
            .AddACBonusAgainstFactOwner(bonus: -2, checkedFact: Guid, descriptor: ModifierDescriptor.FearPenalty)
            .Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
