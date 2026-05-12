using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistSummonPool
{
    public static readonly string Guid = "{bfa65fd7-4cb5-4b84-83ff-011acc8de7ad}";

    private static readonly string SummonPool = "DemonologistSummonPool";
    internal static void Configure()
    {
        SummonPoolConfigurator.New(SummonPool, Guid)
            .Configure();
    }
}
