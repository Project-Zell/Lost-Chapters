using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon;
using System.Collections.Generic;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class SupremeCommanderFeature
{
    public static readonly string Guid = "{b57192a6-aa69-42ea-9345-29dd4c8ae01f}";

    private static readonly string FeatureName = "SupremeCommander";
    private static readonly string DisplayName = "SupremeCommander.Name";
    private static readonly string Description = "SupremeCommander.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<SupremeCommander>()
            .AddRemoveFeatureOnApply(feature: DedicatedCommanderFeature.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
