using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

namespace LostChapters.Modules.Custom;

internal class CustomModule
{
    internal static readonly string IconPath = "assets/custom/icons";

    internal static void Configure()
    {
        PlagueKnightClass.Configure();

    }
}
