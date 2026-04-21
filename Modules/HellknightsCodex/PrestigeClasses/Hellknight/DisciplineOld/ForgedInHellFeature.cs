using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Enums.Damage;
using Kingmaker.UnitLogic.Mechanics.Actions;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.DisciplineOld;

internal class ForgedInHellFeature
{
    public static readonly string Guid = "{7c35e17c-4899-49a8-8ce9-6aa3d583d9f4}";

    private static readonly string FeatureName = "ForgedInHellFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        var action = ActionsBuilder.New();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddIncomingDamageTrigger(
                checkEnergyDamageType: true,
                energyType: DamageEnergyType.Fire)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{0514c8bd-cc59-43ea-afc8-33865240cdbe}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";
        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddEffectFastHealing(5)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
