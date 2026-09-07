using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using LostChapters.Modules.Custom.Archetypes.CowledPilgrim.Components;

namespace LostChapters.Modules.Custom.Archetypes.CowledPilgrim;

internal class CrossroadsAmbushFeature
{
    public static readonly string Guid = "{42bf49a3-71b6-4fac-8096-8493b6ec8b8c}";

    private static readonly string BaseName = "CrossroadsAmbush";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/{CowledPilgrimArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        PounceBuff.Configure();
        ArmorClassBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddBuffSubstitutionOnApply(
                gainedFact: BuffRefs.ChargeBuff.ToString(),
                substituteBuff: ArmorClassBuff.Guid)
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

        private static readonly string BuffName = $"{BaseName}BuffPounce";

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

        private static readonly string BuffName = $"{BaseName}BuffArmorClass";

        internal static void Configure()
        {
            var chargeDisplayName = "972f3036-b125-4565-baf1-4ca544cdbcab";

            BuffConfigurator.New(BuffName, Guid)
                .AddCondition(Kingmaker.UnitLogic.UnitCondition.StealthForbidden)
                .AddAttackBonusConditional(bonus: 2)
                .AddToFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(chargeDisplayName)
                .Configure();
        }
    }
}