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

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class HarbingerOfBlightFeature
{
    public static readonly string Guid = "{5cb51b7b-3f25-49b4-b3b6-f10ee86464f7}";

    private static readonly string FeatureName = "HarbingerOfBlight";
    private static readonly string DisplayName = "HarbingerOfBlight.Name";
    private static readonly string Description = "HarbingerOfBlight.Description";

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
        //C: Get inherit +4 to Constitution. Can summon 1d3 plague rats two times per day. Rat apply Bubonicplague.
        //4: Melting Madness
        //C: At the start of the day roll for 1d4 damage to Intelegense.
        //B: Get two claw attacks while wearing heavy armor, get inherit +2 to fear affects
        //5: Bleak Breath
        //B: At the start of the day roll for nauseated. 
        //C: All who steps in the aura shold roll for save of be nauseated.
        //6: Demonplague
        //B: At the start of the day roll for strengts drain 1d4, C: Gain +4 strenght
        //7: Necrotic boils
        //C: Get some on been hitted
        //B: 

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddComponent<IgnoreDesease>()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
