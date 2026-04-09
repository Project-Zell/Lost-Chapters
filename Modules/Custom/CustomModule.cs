using LostChapters.Modules.Custom.Archetypes.BlackKnight;
using LostChapters.Modules.Custom.Archetypes.CircuitJudge;
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
        ArmoredMarauderFeature.Configure();
        ArmoredSwiftnessFeature.Configure();
        ReapingStalkerFeature.Configure();

        BlackKnight.Configure();
        CircuitJudgeArchetype.Configure();
        HoodedWandererArchetype.Configure();
        MageSlayer.Configure();


        CharacterClassesConsistencyPatch.Configure();




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
