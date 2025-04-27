using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Modules.GraySisterhood;

internal class BasicProgression
{
    internal static void Configure()
    {
        ProgressionConfigurator.For(ProgressionRefs.BasicFeatsProgression)
            .AddToLevelEntry(level: 01, AidAnotherFeature.Guid)
            .Configure();
    }
}
