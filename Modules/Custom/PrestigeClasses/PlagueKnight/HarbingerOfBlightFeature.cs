using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using LostChapters.Modules.Custom.Components;
using Kingmaker.Enums;
using Kingmaker.EntitySystem.Stats;

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
        //B: At the start of the day roll for blindness, -2 perseption C: Permablind without negative condition, has blind vision 50ft, +2 perseption
        //2: Glacier plague
        //B: At the start of the day roll fo fatigue, -10 feet speed C: Immune to cold, +10 feet speed
        //3: Bubonic plague
        //B: At the start of the day roll for strengts drain 1d4, C: Gain +4 strenght


        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddComponent<IgnoreDesease>()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}
