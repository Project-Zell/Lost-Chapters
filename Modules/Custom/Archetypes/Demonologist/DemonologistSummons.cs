using BlueprintCore.Utils.Assets;
using Kingmaker.View;
using Kingmaker.Visual.Particles;
using LostChapters._tools;
using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;
using UnityEngine;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistSummons
{
    internal static void Configure()
    {
        SummonDemonVisual.ConfigureAppear();
        
        SummonDemonIFeature.Configure();
        SummonDemonIIFeature.Configure();

        SummonDemonVisual.ConfigureDismemberFx();
    }

    internal void Configure3()
    {
        //Lvl1 - Dretch
        //Lvl2 - Quasit
        //Lvl3 - Schir
        //Lvl4 - Babau
        //Lvl5 - Nabasu
        //Lvl6 - Vrock
        //Lvl7 - Kalavakus
        //Lvl8 - Gallu
        //Lvl9 - Balor

        //Lvl20 - Glabrezu

    }
}
