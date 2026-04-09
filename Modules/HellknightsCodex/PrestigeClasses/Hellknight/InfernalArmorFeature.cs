using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using UnityEngine;

namespace LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

internal class InfernalArmorFeature
{
    public static readonly string Guid = "{bdb05248-f666-4a35-b672-4ea99d385bba}";

    private static readonly string FeatureName = "InfernalArmor";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly Sprite Icon = FeatureRefs.ArmoredHulkIndomitableStance.Reference.Get().Icon;

    internal static void Configure()
    {
        var value = ContextValues.Rank();
        var mainMultiplier = ContextValues.Constant(10);
        var subMultiplier = ContextValues.Constant(5);
        var config = ContextRankConfigs.FeatureRank(feature: Guid, min: 0, max: 3);

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([FeatureRefs.ArmorTraining.ToString()])
            .AddDamageResistanceEnergy(type: DamageEnergyType.Fire, value: value, useValueMultiplier: true, valueMultiplier: mainMultiplier)
            .AddDamageResistanceEnergy(type: DamageEnergyType.Cold, value: value, useValueMultiplier: true, valueMultiplier: subMultiplier)
            .AddDamageResistanceEnergy(type: DamageEnergyType.Acid, value: value, useValueMultiplier: true, valueMultiplier: subMultiplier)
            .AddContextRankConfig(config)
            .SetRanks(3)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }
}
