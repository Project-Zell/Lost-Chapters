using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightCodex.Archetypes;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Modules.HellknightsCodex.Orders.Hellknight.Base;
using LostChapters.Tweaks;

namespace LostChapters.Modules.HellknightCodex;

internal class HellknightCodexModule
{
    internal static readonly string IconsPath = "assets/hellknightcodex/icons";

    internal static void Configure()
    {
        AnimalCompanionTweaks.Configure();

        //Classes
        Armiger.Configure();
        DeaconArchetype.Configure();

        //Prestige Classes
        HellknightClassChanger.Configure();

        //Orders
        OrderOfTheChainsFeature.Configure();
        //OrderOfTheGateFeature.Configure();
        //OrderOfTheGodclawFeature.Configure();
        //OrderOfTheNailFeature.Configure();
        //OrderOfThePyreFeature.Configure();
        //OrderOfTheRackFeature.Configure();
    }

    internal static void ConfigureItems()
    {
        //Act 3 - Hellknight Outpost Paralictor Aminos Renth
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.HellKnight_Chapter3VendorTable)
            .Configure();

        //Act 5 - Hellknight Outpost Paralictor Aminos Renth
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.Aminas_Chapter5VendorTable)
            .Configure();
    }
}
