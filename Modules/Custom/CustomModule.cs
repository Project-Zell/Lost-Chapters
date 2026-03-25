using LostChapters.Modules.Custom.Archetypes.BlackKnight;
using LostChapters.Modules.Custom.Archetypes.HoodedWanderer;
using LostChapters.Modules.Custom.Backgrounds;
using LostChapters.Modules.Custom.Components;
using LostChapters.Modules.Custom.Feats;
using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

namespace LostChapters.Modules.Custom;

internal class CustomModule
{
    internal static readonly string IconPath = "assets/custom/icons";

    internal static void Configure()
    {

        BlackKnight.Configure();
        HoodedWandererArchetype.Configure();

        return;

        PlagueKnightClass.Configure();




        FishermanBackground.Configure();
        ForagerBackground.Configure();
        HighbornBackground.Configure();
        GravediggerBackground.Configure();
        TavernServerBackground.Configure();


        ScarredLegionFeature.Configure();  
        DistractingChargeFeature.Configure();

    }
}
