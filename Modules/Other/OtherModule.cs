using LostChapters.Modules.Custom.Other;

namespace LostChapters.Modules.Other;

internal class OtherModule
{
    internal static readonly string IconsPath = "assets/other/icons";

    internal static void Configure()
    {
        CharacterClassesConsistencyPatch.Configure();

        MuteBuff.Configure();
        TargetWillProperty.Configure();
    }
}
