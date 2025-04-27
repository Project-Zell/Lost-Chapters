using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters.Modules.GraySisterhood.Components;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats;

internal class BodyguardFeature
{
    public static readonly string Guid = "{6b84aea5-db20-4bf9-96b2-cd6b18ec446e}";

    private static readonly string FeatureName = "Bodyguard";
    private static readonly string DisplayName = "Bodyguard.Name";
    private static readonly string Description = "Bodyguard.Description";

    private static readonly string Icon = $"{GraySisterhoodModule.IconPath}/bodyguard.png";
    public static void Configure()
    {
        CooldownBuff.Configure();
        AreaBuff.Configure();
        AbilityAreaEffect.Configure();
        AbilityBuff.Configure();
        ActivatableAbility.Configure();

        FeatureConfigurator.New(FeatureName, Guid, FeatureGroup.Feat | FeatureGroup.CombatFeat)
            .AddPrerequisiteFeature(feature: FeatureRefs.CombatReflexes.ToString())
            .AddFacts([ActivatableAbility.Guid])
            .AddFeatureTagsComponent(FeatureTag.Defense)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .SetIcon(Icon)
            .Configure();
    }

    internal class CooldownBuff
    {
        public static readonly string Guid = "{ce3e0b04-fbca-4c59-b4cd-f755f8106183}";

        private static readonly string BuffName = "Bodyguard.CooldownBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<RemoveSelfOnCasterNewTurn>()
                .SetFxOnStart("358e9c4bd0b52f443b72ad2332e038a4")
                .SetFlags([BlueprintBuff.Flags.HiddenInUi])
                .SetStacking(StackingType.Stack)
                .SetDisplayName(BuffName)
                .Configure();
        }
    }

    internal class AreaBuff
    {
        public static readonly string Guid = "{81270bfb-0b03-4d45-8fa2-9e07d16fd56e}";
        
        private static readonly string BuffName = "Bodyguard.AreaBuff";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent<Bodyguard>()
                .SetStacking(StackingType.Stack)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .SetDisplayName(DisplayName)
                .SetDescription(DisplayName)
                .Configure();
        }
    }
    internal class AbilityAreaEffect
    {
        public static readonly string Guid = "{c7adfb7c-e8f4-41d6-9d49-acd06b96fd13}";

        private static readonly string AreaEffectName = "Bodyguard.AbilityAreaEffect";

        internal static void Configure()
        {
            AbilityAreaEffectConfigurator.New(AreaEffectName, Guid)
                .AddAbilityAreaEffectBuff(buff: AreaBuff.Guid)
                .SetAffectEnemies(false)
                .SetAggroEnemies(false)
                .SetShape(AreaEffectShape.AllArea)
                .Configure();
        }
    }

    internal class AbilityBuff
    {
        public static readonly string Guid = "{9dc5e008-a1d8-4efd-ad9f-a96c3589de49}";

        private static readonly string BuffName = "Bodyguard.AbilityBuff";
        private static readonly string DisplayName = "Bodyguard.AbilityBuff.Name";
        private static readonly string Description = "Bodyguard.AbilityBuff.Description";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddAreaEffect(areaEffect: AbilityAreaEffect.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class ActivatableAbility
    {
        public static readonly string Guid = "{9bbb74e6-f16f-4596-8260-a56682ece017}";

        private static readonly string AbilityName = "Bodyguard.ActivatableAbility";

        internal static void Configure()
        {
            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(AbilityBuff.Guid)
                .SetDeactivateImmediately(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
