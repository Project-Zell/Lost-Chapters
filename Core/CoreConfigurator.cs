using BlueprintCore.Utils;
using LostChapters.Modules.Custom;
using LostChapters.Modules.Other;

namespace LostChapters.Core;

internal class CoreConfigurator
{
    internal static void Configure()
    {
        var modName = Main.ModName;

        LocalizationTool.LoadEmbeddedLocalizationPacks(
            $"{modName}.Localization.CustomModuleStrings.json",
            $"{modName}.Localization.GraySisterhoodStrings.json",
            $"{modName}.Localization.HellknightsCodexStrings.json",
            $"{modName}.Localization.OtherLocalizedStrings.json");

        OtherModule.Configure();
        CustomModule.Configure();
        //GraySisterhoodModule.Configure();
        //HellknightCodexModule.Configure();
    }
}
