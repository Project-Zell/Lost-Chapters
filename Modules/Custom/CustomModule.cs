using LostChapters.Modules.Custom.Archetypes.BlackKnight;
using LostChapters.Modules.Custom.Archetypes.CircuitJudge;
using LostChapters.Modules.Custom.Archetypes.Demonologist;
using LostChapters.Modules.Custom.Archetypes.HoodedWanderer;
using LostChapters.Modules.Custom.Archetypes.MageSlayer;
using LostChapters.Modules.Custom.Backgrounds;
using LostChapters.Modules.Custom.Feats;
using LostChapters.Modules.Custom.Feats.ArcanistExploits;
using LostChapters.Modules.Custom.Feats.SlayerTalents;
using LostChapters.Modules.Custom.Other;
using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

namespace LostChapters.Modules.Custom;

internal class CustomModule
{
    internal static readonly string IconPath = "assets/custom/icons";

    internal static void Configure()
    {
        PlagueKnightClass.Configure();

        //Feats
        ArmoredMarauderFeature.Configure();
        ArmoredSwiftnessFeature.Configure();
        ReapingStalkerFeature.Configure();

        //Archetypes
        FalseKnightArchetype.Configure();
        CircuitJudgeArchetype.Configure();
        CowledPilgrimArchetype.Configure();
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

        //Feats
        ArcanistFamiliarFeature.Configure();
        MetamagicKnowledgeFeature.Configure();
        MetamagicKnowledgeGreaterFeature.Configure();

        return;






        BackgroundFisherman.Configure();
        BackgroundForager.Configure();
        BackgroundHighborn.Configure();
        BackgroundGravedigger.Configure();
        BackgroundTavernServer.Configure();


        ScarredLegionFeature.Configure();  
        DistractingChargeFeature.Configure();

    }
}
