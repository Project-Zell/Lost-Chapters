using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using LostChapters.Modules.GraySisterhood.Components;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon;
using System.Collections.Generic;

namespace LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;

internal class DedicatedCommanderFeature
{
    public static readonly string Guid = "{244c72f1-792f-4a73-922a-3a13ba0d5d16}";

    private static readonly string FeatureName = "DedicatedCommander";
    private static readonly string DisplayName = "DedicatedCommander.Name";
    private static readonly string Description = "DedicatedCommander.Description";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddComponent<DedicatedCommander>()
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
