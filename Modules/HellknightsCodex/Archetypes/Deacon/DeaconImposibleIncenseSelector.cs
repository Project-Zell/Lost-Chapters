using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using LostChapters.Modules.HellknightsCodex.Archetypes.Deacon.ImposibleIncense;

namespace LostChapters.Modules.HellknightsCodex.Archetypes.Deacon;

internal class DeaconImposibleIncenseSelector
{
    public static readonly string Guid = "{3f9df65e-26b1-4fb4-b2df-770c360ef931}";

    private static readonly string FeatureName = "DeaconImposibleIncenseSelection";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        AirDomainImposibleIncense.Configure();
        AnimalDomainImposibleIncense.Configure();
        ArtificeDomainImposibleIncense.Configure();
        ChaosDomainImposibleIncense.Configure();
        CharmDomainImposibleIncense.Configure();
        CommunityDomainImposibleIncense.Configure();
        DarknessDomainImposibleIncense.Configure();
        DeathDomainImposibleIncense.Configure();
        DestructionDomainImposibleIncense.Configure();
        EarthDomainImposibleIncense.Configure();
        EvilDomainImposibleIncense.Configure();
        FireDomainImposibleIncense.Configure();
        GloryDomainImposibleIncense.Configure();
        GoodDomainImposibleIncense.Configure();
        HealingDomainImposibleIncense.Configure();
        KnowledgeDomainImposibleIncense.Configure();
        LawDomainImposibleIncense.Configure();
        LiberationDomainImposibleIncense.Configure();
        LuckDomainImposibleIncense.Configure();
        MadnessDomainImposibleIncense.Configure();
        MagicDomainImposibleIncense.Configure();
        NobilityDomainImposibleIncense.Configure();
        PlantDomainImposibleIncense.Configure();
        ProtectionDomainImposibleIncense.Configure();
        ReposeDomainImposibleIncense.Configure();
        RuneDomainImposibleIncense.Configure();
        ScalykindDomainImposibleIncense.Configure();
        StrengthDomainImposibleIncense.Configure();
        SunDomainImposibleIncense.Configure();
        TravelDomainImposibleIncense.Configure();
        TrickeryDomainImposibleIncense.Configure();
        WarDomainImposibleIncense.Configure();
        WaterDomainImposibleIncense.Configure();
        WeatherDomainImposibleIncense.Configure();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddToAllFeatures(
                AirDomainImposibleIncense.Guid,
                AnimalDomainImposibleIncense.Guid,
                ArtificeDomainImposibleIncense.Guid,
                ChaosDomainImposibleIncense.Guid,
                CharmDomainImposibleIncense.Guid,
                CommunityDomainImposibleIncense.Guid,
                DarknessDomainImposibleIncense.Guid,
                DeathDomainImposibleIncense.Guid,
                DestructionDomainImposibleIncense.Guid,
                EarthDomainImposibleIncense.Guid,
                EvilDomainImposibleIncense.Guid,
                FireDomainImposibleIncense.Guid,
                GloryDomainImposibleIncense.Guid,
                GoodDomainImposibleIncense.Guid,
                HealingDomainImposibleIncense.Guid,
                KnowledgeDomainImposibleIncense.Guid,
                LawDomainImposibleIncense.Guid,
                LiberationDomainImposibleIncense.Guid,
                LuckDomainImposibleIncense.Guid,
                MadnessDomainImposibleIncense.Guid,
                MagicDomainImposibleIncense.Guid,
                NobilityDomainImposibleIncense.Guid,
                PlantDomainImposibleIncense.Guid,
                ProtectionDomainImposibleIncense.Guid,
                ReposeDomainImposibleIncense.Guid,
                RuneDomainImposibleIncense.Guid,
                ScalykindDomainImposibleIncense.Guid,
                StrengthDomainImposibleIncense.Guid,
                SunDomainImposibleIncense.Guid,
                TravelDomainImposibleIncense.Guid,
                TrickeryDomainImposibleIncense.Guid,
                WarDomainImposibleIncense.Guid,
                WaterDomainImposibleIncense.Guid,
                WeatherDomainImposibleIncense.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();

        FeatureSelectionConfigurator.For(FeatureSelectionRefs.MythicAbilitySelection.ToString())
            .AddToAllFeatures(Guid)
            .Configure();
    }
}
