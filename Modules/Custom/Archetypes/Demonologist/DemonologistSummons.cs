using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonologistSummons
{
    internal static void Configure()
    {
        SummonDemonVisual.ConfigureAppear();
        
        SummonDemonI.Configure();
        SummonDemonII.Configure();
        SummonDemonIII.Configure();
        SummonDemonIV.Configure();
        SummonDemonV.Configure();
        SummonDemonVI.Configure();
        SummonDemonVII.Configure();
        SummonDemonVIII.Configure();
        SummonDemonIX.Configure();

        SummonDemonVisual.ConfigureDismemberFx();
    }

    internal void Configure3()
    {
        //Lv01 - SD1 - Dretch
        //Lv04 - SD2 - Quasit
        //Lv06 - SD3 - Schir 
        //Lv08 - SD4 - Babau
        //LV10 - SD5 - Nabasu
        //Lv12 - SD6 - Vrock
        //Lv14 - SD7 - Kalavakus
        //Lv16 - SD8 - Gallu
        //Lv18 - SD9 - Balor

        //Lvl20 - Glabrezu

    }
}
