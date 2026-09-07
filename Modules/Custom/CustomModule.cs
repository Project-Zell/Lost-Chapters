using LostChapters.Modules.Custom.Archetypes.CowledPilgrim;
using LostChapters.Modules.Custom.Archetypes.Deacon;
using LostChapters.Modules.Custom.Archetypes.Demonologist;
using LostChapters.Modules.Custom.Backgrounds;
using LostChapters.Modules.Custom.Feats.General;
using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;
using LostChapters.Tools;

namespace LostChapters.Modules.Custom;

internal class CustomModule
{
    internal static readonly string IconPath = "Assets/Custom/Icons";

    internal static void Configure()
    {
        //Archetypes
        CowledPilgrimArchetype.Configure();
        DeaconArchetype.Configure();
        DemonologistArchetype.Configure();
        //MagistrateArchetype.Configure();
        //FalseKnightArchetype.Configure();
        //MageSlayerArchetype.Configure();

        ////Feats
        //ArmoredMarauderFeature.Configure();
        //ArmoredSwiftnessFeature.Configure();
        //ReapingStalkerFeature.Configure();

        ////Backgrounds
        //BackgroundFisherman.Configure();
        //BackgroundForager.Configure();
        //BackgroundGravedigger.Configure();
        //BackgroundGrayEminence.Configure();
        //BackgroundHighborn.Configure();
        //BackgroundPrisoner.Configure();
        //BackgroundSentryGuard.Configure();
        //BackgroundTavernServer.Configure();

        ////Feats
        //ArcanistFamiliarFeature.Configure();
        //MetamagicKnowledgeFeature.Configure();
        //MetamagicKnowledgeGreaterFeature.Configure();

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
