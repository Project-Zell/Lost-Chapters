using BlueprintCore.Blueprints.Configurators.Classes;
using LostChapters.Modules.HellknightsCodex.AnimalCompanions.Hellhound;

namespace LostChapters.Modules.HellknightCodex.AnimalCompanions.Hellhound;

internal class HellhoundClass
{
    public static readonly string Guid = "{27655729-920a-40d7-b512-12cb0aa51878}";

    private static readonly string ClassName = "HellhoundClass";
    private static readonly string LocalizedName = $"{ClassName}.LocalizedName";
    private static readonly string LocalizedDescription = $"{ClassName}.LocalizedDescription";

    internal static void Configure()
    {
        HellhoundProgression.Configure();

        CharacterClassConfigurator.New(ClassName, Guid)
            .SetProgression(HellhoundProgression.Guid)
            .SetLocalizedName(LocalizedName)
            .SetLocalizedDescription(LocalizedDescription)
            .Configure();
    }
}
