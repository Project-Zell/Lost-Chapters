using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using LostChapters.Modules.GraySisterhood;
using LostChapters.Modules.GraySisterhood.Components;

namespace LostChapters.Modules.Custom.Archetypes.HoodedWanderer;

internal class CrossroadsAmbushFeature
{
    public static readonly string Guid = "{42bf49a3-71b6-4fac-8096-8493b6ec8b8c}";

    private static readonly string FeatureName = "CrossroadsAmbush";
    private static readonly string DisplayName = "CrossroadsAmbush.Name";
    private static readonly string Description = "CrossroadsAmbush.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/crossroadambush.png";

    internal static void Configure()
    {
        PounceBuff.Configure();
        ArmorClassBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddBuffExtraEffects(checkedBuff: BuffRefs.ChargeBuff.ToString(), extraEffectBuff: ArmorClassBuff.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();

        AbilityConfigurator.For(AbilityRefs.ChargeAbility.ToString())
            .AddComponent<CrossroadsAmbush>()
            .Configure();
    }

    internal class PounceBuff
    {
        public static readonly string Guid = "{225233f1-4fb5-4d40-9a1b-54781ea6a0bf}";

        private static readonly string BuffName = "CrossroadsAmbush.PounceBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.Pounce)
                .AddToFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class ArmorClassBuff
    {
        public static readonly string Guid = "{cfa99526-f0e4-4c92-a6d2-b12ce820d9ae}";

        private static readonly string BuffName = "CrossroadsAmbush.ArmorClassBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddContextStatBonus(stat: StatType.AC, value: 2, multiplier: 1)
                .AddToFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
