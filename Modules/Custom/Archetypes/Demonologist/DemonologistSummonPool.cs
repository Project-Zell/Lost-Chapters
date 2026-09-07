using BlueprintCore.Blueprints.Configurators;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistSummonPool
{
    public static readonly string Guid = "{bfa65fd7-4cb5-4b84-83ff-011acc8de7ad}";

    private static readonly string SummonPoolName = $"{DemonologistArchetype.BaseName}SummonPool";
    internal static void Configure()
    {
        SummonPoolConfigurator.New(SummonPoolName, Guid)
            .Configure();
    }
}