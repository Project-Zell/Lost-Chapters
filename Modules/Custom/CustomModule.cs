using LostChapters.Modules.Custom.Archetypes.CowledPilgrim;
using LostChapters.Modules.Custom.Archetypes.Deacon;
using LostChapters.Modules.Custom.Archetypes.Demonologist;
using LostChapters.Modules.Custom.Archetypes.FalseKnight;
using LostChapters.Modules.Custom.Archetypes.Magistrate;
using LostChapters.Modules.Custom.Archetypes.Neutralizer;

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
        FalseKnightArchetype.Configure();
        NeutralizerArchetype.Configure();
        MagistrateArchetype.Configure();

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


    }
}
