using BlueprintCore.Blueprints.Configurators.Root;
using BlueprintCore.Utils;
using HarmonyLib;
using Kingmaker.Blueprints.JsonSystem;
using LostChapters.Modules.Custom;
using LostChapters.Modules.GraySisterhood;
using System;
using UnityModManagerNet;

namespace LostChapters;

public static class Main
{
    public static bool Enabled;
    private static readonly LogWrapper Logger = LogWrapper.Get("LostChapters");

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
        try
        {
            modEntry.OnToggle = OnToggle;
            var harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll();
            Logger.Info("Finished patching.");
        }
        catch (Exception e)
        {
            Logger.Error("Failed to patch", e);
        }
        return true;
    }

    public static bool OnToggle(UnityModManager.ModEntry modEntry, bool value)
    {
        Enabled = value;
        return true;
    }

    [HarmonyPatch(typeof(BlueprintsCache))]
    static class BlueprintsCaches_Patch
    {
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        static void Init()
        {
            try
            {
                if (Initialized)
                {
                    Logger.Info("Already configured blueprints.");
                    return;
                }
                Initialized = true;

                Logger.Info("Configuring blueprints.");

                Configure();
            }
            catch (Exception e)
            {
                Logger.Error("Failed to configure blueprints.", e);
            }
        }
    }

    [HarmonyPatch(typeof(StartGameLoader))]
    static class StartGameLoader_Patch
    {
        private static bool Initialized = false;

        [HarmonyPatch(nameof(StartGameLoader.LoadPackTOC)), HarmonyPostfix]
        static void LoadPackTOC()
        {
            try
            {
                if (Initialized)
                {
                    Logger.Info("Already configured delayed blueprints.");
                    return;
                }
                Initialized = true;

                RootConfigurator.ConfigureDelayedBlueprints();
            }
            catch (Exception e)
            {
                Logger.Error("Failed to configure delayed blueprints.", e);
            }
        }
    }
    private static void Configure()
    {
        var harmony = new Harmony("LostChapters");
        harmony.PatchAll();

        LocalizationTool.LoadEmbeddedLocalizationPacks(
            "LostChapters.Localization.GraySisterhoodStrings.json");

        GraySisterhoodModule.Configure();

        CustomModule.Configure();
    }

}
