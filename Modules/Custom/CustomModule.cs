using LostChapters.Modules.Custom.Archetypes.BlackKnight;
using LostChapters.Modules.Custom.Archetypes.CircuitJudge;
using LostChapters.Modules.Custom.Archetypes.Demonologist;
using LostChapters.Modules.Custom.Archetypes.HoodedWanderer;
using LostChapters.Modules.Custom.Archetypes.MageSlayer;
using LostChapters.Modules.Custom.Backgrounds;
using LostChapters.Modules.Custom.Feats;
using LostChapters.Modules.Custom.Other;
using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

namespace LostChapters.Modules.Custom;

internal class CustomModule
{
    internal static readonly string IconPath = "assets/custom/icons";

    internal static void Configure()
    {
        //Feats
        ArmoredMarauderFeature.Configure();
        ArmoredSwiftnessFeature.Configure();
        ReapingStalkerFeature.Configure();

        //Archetypes
        BlackKnightArchetype.Configure();
        CircuitJudgeArchetype.Configure();
        HoodedWandererArchetype.Configure();
        MageSlayerArchetype.Configure();
        DemonologistArchetype.Configure();

        //Backgrounds
        BackgroundFisherman.Configure();
        BackgroundForager.Configure();
        BackgroundGravedigger.Configure();
        BackgroundGrayEminence.Configure();
        BackgroundHighborn.Configure();
        BackgroundPrisoner.Configure();
        BackgroundSentryGuard.Configure();
        BackgroundTavernServer.Configure();


        return;

        PlagueKnightClass.Configure();




        BackgroundFisherman.Configure();
        BackgroundForager.Configure();
        BackgroundHighborn.Configure();
        BackgroundGravedigger.Configure();
        BackgroundTavernServer.Configure();


        ScarredLegionFeature.Configure();  
        DistractingChargeFeature.Configure();

    }
}
