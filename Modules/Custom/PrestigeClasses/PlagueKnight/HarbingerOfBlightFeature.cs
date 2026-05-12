using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using LostChapters.Modules.Custom.Components;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UI.ServiceWindow;
using BlueprintCore.Blueprints.Configurators.Root.Fx;
using BlueprintCore.Blueprints.References;
using Kingmaker.UI.MVVM._PCView.ServiceWindows.Inventory;
using UnityEngine;
using LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class HarbingerOfBlightFeature
{
    public static readonly string Guid = "{cf95f4f0-6aed-4fbf-ad83-79ecb1ca9959}";

    private static readonly string FeatureName = "HarbingerOfBlightFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/blackrot.png";
    public static void Configure()
    {
        //1: Green Haze
        //B: At the start of the day roll for blindness. Permanennt -2 to perseptions checks
        //C: Permablind without negative condition (Immune to Blind and Gaze attacks) has blind vision 50ft. 
        //2: Glacier plague
        //B: At the start of the day roll fo fatigue, -2 to atletic
        //C: Immune to cold, Blackroot deal additional 2d6 cold damage
        //3: Bubonic plague
        //B: At the start of the day roll for 1d4 damage to Constitution
        //C: Get inherit +4 to Constitution. Can summon 1d3 plague rats 3 times per day. Rat apply Bubonicplague.
        //4: Melting Madness
        //C: At the start of the day roll for 1d4 damage to Intelegense.
        //B: Get two bite attacks, any of your bites apply melting madness, get inherit +2 to fear affects
        //5: Bleak Breath
        //B: At the start of the day roll for nauseated. 
        //C: All who steps in the aura shold roll for save of be nauseated.
        //6: Demonplague
        //B: At the start of the day roll for strengts drain 1d4, -1 to charisma.
        //C: Scoring Critical hit allow to all disease effects on the target to trigger aggain.
        //7: Necrotic boils
        //C: Get some on been hitted
        //B: First time been hitet in round you deal acid damage to all enmies in 15 feet radius and try to apply Nectrotic Boils on them

        BleakBreathFeature.Configure();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddToAllFeatures([BleakBreathFeature.Guid])
            //.AddComponent<IgnoreDesease>()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
