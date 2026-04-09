using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.HellknightCodex.Archetypes.Deacon.Incense;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.HellknightCodex.Archetypes.Deacon;

internal class DeaconIncenseFeature
{
    public static readonly string Guid = "{1219026c-1406-4971-a1b7-7ca87da45049}";

    private static readonly string FeatureName = "DeaconIncense";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    public static void Configure()
    {
        ActivatableAbility.Configure();

        //ContextActionRemoveBuff StandartRage/Rage Spell
        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([ActivatableAbility.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class ActivatableAbility
    {
        public static readonly string Guid = "{7cf8d9d0-97d4-44e9-ba01-8ea2bcdee443}";

        private static readonly string AbilityName = "DeaconIncense.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            Buff.Configure();

            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(Buff.Guid)
                .AddComponent<DeaconIncenseDC>()
                .SetActivationType(AbilityActivationType.WithUnitCommand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{1005297c-7933-4c19-b004-3ffbc4bd9ddd}";

        private static readonly string BuffName = "DeaconIncense.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            AbilityArea.Configure();

            BuffConfigurator.New(BuffName, Guid)
                .AddAreaEffect(areaEffect: AbilityArea.Guid)
                .SetFxOnStart("54b14a687d7af52418f23485ca51d690")
                .SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath)
                .SetIsClassFeature(true)
                .Configure();
        }
    }

    internal class AbilityArea
    {
        public static readonly string Guid = "{4545f197-8d7d-4630-8e75-4dba423fca61}";

        private static readonly string AbilityAreaName = "DeaconIncense.AbilityArea";

        internal static void Configure()
        {
            EffectBuff.Configure();

            AbilityAreaEffectConfigurator.New(AbilityAreaName, Guid)
                .AddAbilityAreaEffectBuff(EffectBuff.Guid)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(30.Feet())
                .AddContextSetAbilityParams(dC: 0)
                .Configure();
        }
    }

    internal class EffectBuff
    {
        public static readonly string Guid = "{5a36fe50-9a1f-4131-acdc-87c93f5b16a2}";

        private static readonly string BuffName = "DeaconIncense.EffectBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.HauntingMists.Reference.Get().Icon)
                .Configure();
        }
    }
}
