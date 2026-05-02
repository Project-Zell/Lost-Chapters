using BlueprintCore.Blueprints.Configurators.Items;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Loot;
using LostChapters.Modules.Custom.Items.Weapons.Exotic;
using LostChapters.Modules.GraySisterhood.Archetypes.Dreadnought;
using LostChapters.Modules.GraySisterhood.Archetypes.SisterInArms;
using LostChapters.Modules.GraySisterhood.Backgrounds;
using LostChapters.Modules.GraySisterhood.Enchantments;
using LostChapters.Modules.GraySisterhood.Feats;
using LostChapters.Modules.GraySisterhood.Items.Accessories.Shoulders;
using LostChapters.Modules.GraySisterhood.Items.Armors.Light;
using LostChapters.Modules.GraySisterhood.Items.Armors.Unique;
using LostChapters.Modules.GraySisterhood.Items.GrayMaidensItems;
using LostChapters.Modules.GraySisterhood.Items.Weapons.Exotic;
using LostChapters.Modules.GraySisterhood.Items.Weapons.Martial;
using LostChapters.Modules.GraySisterhood.Items.Weapons.Simple;
using LostChapters.Modules.GraySisterhood.Items.Weapons.Unique;
using LostChapters.Modules.GraySisterhood.Orders.Cavalier.Dragon;
using LostChapters.Modules.GraySisterhood.PrestigeClasses.SanguineAngel;
using LostChapters.Modules.GraySisterhood.Revelations;
using LostChapters.Modules.GraySisterhood.Spells;
using LostChapters.Tools;

namespace LostChapters.Modules.GraySisterhood;

internal class GraySisterhoodModule
{
    internal static readonly string IconsPath = "assets/graysisterhood/icons";

    internal static void Configure()
    {
        //Archetypes
        DreadnoughtArchetype.Configure();
        SisterInArms.Configure();

        //Backgrounds
        BattlefieldDiscipleBackground.Configure();
        GrayMaidenInitiateBackground.Configure();

        //Enchantments
        BenevolentArmorEnchantment.Configure();
        BenevolentWeaponEnchantment.Configure();    

        //Features
        AidAnotherFeature.Configure();
        BodyguardFeature.Configure();
        GrayMaidensTrainingFeature.Configure();
        HarryingPartnersFeature.Configure();
        HelpfulFeature.Configure();
        SwiftAid.Configure();

        //Orders
        CavalierOrderOfTheDragon.Configure();

        //Presige Classes
        SanguineAngelClass.Configure();

        //Revelations
        OracleSuccorMysteryFeature.Configure();

        //Spells
        ShieldOfFortification.Configure();
        ShieldOfFortificationGreater.Configure();

        //Items
        ConfigureItems();

        //Basic Progression
        BasicProgression.Configure();
    }

    private static void ConfigureItems()
    {
        //Common Armor
        PaddedArmorPlus1BenevolentItem.Configure();

        //Unique Armor

        //Ohter
        //RingOfAltruismItem.Configure();

        //Common Weapons
        BastardSwordPlus1BenevolentItem.Configure();
        BastardSwordPlus2BenevolentAdamantineItem.Configure();
        BastardSwordPlus3BenevolentShockFrostItem.Configure();
        BastardSwordPlus5AxiomaticBenevolentItem.Configure();
        EstocPlus2BenevolentAlchemicalSilverItem.Configure();
        EstocPlus4BenevolentKeenCruelItem.Configure();
        LongsordPlus1BenevolentItem.Configure();
        LongsordPlus2BenevolentHolyItem.Configure();
        LongsordPlus3BenevolentItem.Configure();
        LongsordPlus5BenevolentBrilliantEnergyItem.Configure();
        LongspearPlus2BenevolentSacrificialItem.Configure(); 
        LongspearPlus3BenevolentColdIronBleedItem.Configure();
        LongspearPlus5BenevolentHeartseekerSpeedItem.Configure();
        ShortspearPlus1BenevolentMithralItem.Configure();
        ShortspearPlus2BenevolentSpeedItem.Configure();
        ShortspearPlus3BenevolentGreaterShockItem.Configure();
        ShortspearPlus5BenevolentUnstoppableNecroticItem.Configure();
        ShortswordPlus1BenevolentItem.Configure();
        ShortswordPlus2BenevolentAnarchicItem.Configure();
        ShortswordPlus5BenevolentAdamantineGreaterCorrosiveItem.Configure();
        StaffPlus3BenevolentUnholyItem.Configure();
        StaffPlus4BenevolentDisruptionRadiantItem.Configure();

        //Unique Weapon
        BladeBreakerItem.Configure();
        GutSkewerItem.Configure();
        EyeOfScornItem.Configure();
        FadingLightItem.Configure();
        RockslideItem.Configure();
        HeraldOfWinterItem.Configure();

        //Gray Set
        MaidensAegisItem.Configure();
        MaidensPanoplyItem.Configure();
        SwornProtectorItem.Configure();
        ErinyesCompanyCloakItem.Configure();    

        //Act 1 - Joran Vhane
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.Weapon_DefendersHeartVendorTable)
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(BastardSwordPlus1BenevolentItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(LongsordPlus1BenevolentItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(ShortswordPlus1BenevolentItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(ShortspearPlus1BenevolentMithralItem.Guid) })
            .Configure();

        //Act 2 - Wilcer Garms
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.WarCamp_QuartermasterVendorTable)
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(EstocPlus2BenevolentAlchemicalSilverItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(LongsordPlus2BenevolentHolyItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(EstocPlus2BenevolentAlchemicalSilverItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(LongspearPlus2BenevolentSacrificialItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(ShortspearPlus2BenevolentSpeedItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(ShortswordPlus2BenevolentAnarchicItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(StaffPlus3BenevolentUnholyItem.Guid) })
            .Configure();

        //Act 3 - Wilcer Garms
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.Quartermaster_Chapter3VendorTable)
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(CrimsonDancerItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(BastardSwordPlus3BenevolentShockFrostItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(LongsordPlus3BenevolentItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(LongspearPlus3BenevolentColdIronBleedItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(ShortspearPlus3BenevolentGreaterShockItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(StaffPlus4BenevolentDisruptionRadiantItem.Guid) })
            .Configure();
        
        //Act 4 - Wirlong Black Mask
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.VirlongVendorTable)
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(EyeOfScornItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(EstocPlus4BenevolentKeenCruelItem.Guid) })
            .Configure();

        //Act 5 - Wilcer Garms
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.Quartermaster_Chapter5VendorTable)
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(FadingLightItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(HeraldOfWinterItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(BastardSwordPlus5AxiomaticBenevolentItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(LongsordPlus5BenevolentBrilliantEnergyItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(LongspearPlus5BenevolentHeartseekerSpeedItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(ShortswordPlus5BenevolentAdamantineGreaterCorrosiveItem.Guid) })
            .Configure();

        //Act 3 - Skeletal Salesman
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.Exotic_Chapter3VendorTable)
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(BladeBreakerItem.Guid) })
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(GutSkewerItem.Guid) })
            .Configure();

        //Act 5 - Skeletal Salesman
        SharedVendorTableConfigurator.For(SharedVendorTableRefs.Exotic_Chapter5VendorTable)
            .AddLootItemsPackFixed(1, new LootItem() { m_Item = Toolbox.GetWeaponItemReference(RockslideItem.Guid) })
            .Configure();
    }
}
