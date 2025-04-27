using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Loot;
using LostChapters.Enchantment;
using LostChapters.Modules.Custom.Archetypes.HoodedWanderer;
using LostChapters.Modules.Custom.Backgrounds;
using LostChapters.Modules.Custom.Feats;
using LostChapters.Modules.Custom.Orders.Cavalier.Bastion;
using LostChapters.Modules.Custom.Orders.Cavalier.BlueRose;
using LostChapters.Modules.Custom.Orders.Cavalier.Calamity;
using LostChapters.Modules.Custom.Orders.Cavalier.EmeraldPath;
using LostChapters.Modules.Custom.Orders.Cavalier.Fishbone;
using LostChapters.Modules.Custom.Orders.Cavalier.Tome;
using LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;
using LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;
using LostChapters.Modules.GraySisterhood.Backgrounds;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Modules.GraySisterhood.Items.Weapons;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon;
using LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;
using LostChapters.Modules.GraySisterhood.Revelations;
using LostChapters.Modules.GraySisterhood.Spells;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood;

internal class GraySisterhoodModule
{
    internal static readonly string IconPath = "assets/graysisterhood/icons";

    internal static void Configure()
    {
        //Basic Progression
        BasicProgression.Configure();

        //Archetypes
        Dreadnought.Configure();
        HoodedWandererArchetype.Configure();
        SisterInArms.Configure();

        //Backgrounds
        BattlefieldDiscipleBackground.Configure();
        FishermanBackground.Configure();
        ForagerBackground.Configure();
        HighbornBackground.Configure();
        GravediggerBackground.Configure();
        TavernServerBackground.Configure();

        ////Enchantments
        BenevolentArmorEnchantment.Configure();
        BenevolentWeaponEnchantment.Configure();    

        ////Features
        AidAnotherFeature.Configure();
        BodyguardFeature.Configure();
        DistractingChargeFeature.Configure();
        HarryingPartnersFeature.Configure();
        HelpfulFeature.Configure();
        ScarredLegionFeature.Configure();
        SwiftAid.Configure();

        ////Orders
        CavalierOrderOfTheBastion.Configure();
        CavalierOrderOfTheBlueRose.Configure();
        CavalierOrderOfTheCalamity.Configure();
        CavalierOrderOfTheDragon.Configure();
        CavalierOrderOfTheEmeraldPath.Configure();
        CavalierOrderOfTheFishbone.Configure();
        CavalierOrderOfTheTome.Configure();

        ////Presige Classes
        SanguineAngelClass.Configure();

        ////Revelations
        OracleSuccorMysteryFeature.Configure();

        ////Spells
        ShieldOfFortification.Configure();
        ShieldOfFortificationGreater.Configure();

        ////Items
        ConfigureItems();
    }

    private static void ConfigureItems()
    {
        //Armor

        //Ohter
        //RingOfAltruismItem.Configure();

        //Weapons
        BastardSwordPlus1BenevolentItem.Configure();
        BastardSwordPlus2BenevolentAdamantineItem.Configure();
        BastardSwordPlus3BenevolentShockFrostItem.Configure();
        BastardSwordPlus4AxiomaticBenevolentItem.Configure();
        BladeBreakerItem.Configure();
        CrimsonDancerItem.Configure();
        DragonspikeItem.Configure();
        EstocPlus2BenevolentAlchemicalSilverItem.Configure();
        EstocPlus4BenevolentKeenCruelItem.Configure();
        EyeOfScornItem.Configure();
        FadingLightItem.Configure();
        FallensMercyItem.Configure();
        HeralOfWinterItem.Configure();
        LongsordPlus1BenevolentItem.Configure();
        LongsordPlus2BenevolentHolyItem.Configure();
        LongsordPlus3BenevolentItem.Configure();
        LongsordPlus4BenevolentBrilliantEnergyItem.Configure();
        LongspearPlus2BenevolentSacrificialItem.Configure();
        LongspearPlus3BenevolentColdIronBleedItem.Configure();
        LongspearPlus4BenevolentHeartseekerSpeedItem.Configure();
        ShortspearPlus1BenevolentMithralItem.Configure();
        ShortspearPlus2BenevolentSpeedItem.Configure();
        ShortspearPlus3BenevolentGreaterShockItem.Configure();
        ShortspearPlus4BenevolentDruchiteLivingBaneItem.Configure();
        ShortspearPlus5BenevolentUnstoppableNecroticItem.Configure();
        ShortswordPlus1BenevolentItem.Configure();
        ShortswordPlus2BenevolentAnarchicItem.Configure();
        ShortswordPlus4BenevolentAdamantineGreaterCorrosiveItem.Configure();
        StaffPlus3BenevolentUnholyItem.Configure();
        StaffPlus4BenevolentDisruptionRadiantItem.Configure();

        var heraxa = SharedVendorTableRefs.HerraxaVendorTable;
        var wilcer2 = SharedVendorTableRefs.WarCamp_BlacksmithVendorTable;

        SharedVendorTableConfigurator.For(SharedVendorTableRefs.WarCamp_QuartermasterVendorTable)
            .AddLootItemsPackFixed(1, new LootItem() {m_Item = Toolbox.GetWeaponItemReference(BastardSwordPlus1BenevolentItem.Guid) })
            .Configure();
    }
}
