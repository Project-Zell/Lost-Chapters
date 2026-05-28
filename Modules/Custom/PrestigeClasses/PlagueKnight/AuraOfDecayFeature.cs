using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using LostChapters.Modules.HellknightCodex.Components;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class AuraOfDecayFeature
{
    public static readonly string Guid = "{fe2aa0ee-8d17-4d09-8252-3d02f32e6a4a}";

    private static readonly string FeatureName = "AuraOfDecayFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Ability
    {
        public static readonly string Guid = "{8117abe0-03f0-4304-b423-151e0dc47f5d}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            AbilityBuff.Configure();

            ActivatableAbilityConfigurator.New(AbilityName, Guid)
                .SetBuff(AbilityBuff.Guid)
                .SetActivationType(AbilityActivationType.WithUnitCommand)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class AbilityBuff
    {
        public static readonly string Guid = "{4e882937-a9ac-42ac-bb05-a1f25ec561d6}";

        private static readonly string BuffName = $"{FeatureName}.AbilityBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            AbilityArea.Configure();

            BuffConfigurator.New(BuffName, Guid)
                .AddAreaEffect(areaEffect: AbilityArea.Guid)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi, BlueprintBuff.Flags.StayOnDeath)
                .SetIsClassFeature(true)
                .Configure();
        }
    }

    internal class AbilityArea
    {
        public static readonly string Guid = "{fe2ccf78-eb07-4ee4-978e-648d87ffd198}";

        private static readonly string AreaName = $"{FeatureName}.AbilityArea";
        private static readonly string DisplayName = $"{AreaName}.Name";
        private static readonly string Description = $"{AreaName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            Buff.Configure();

            AbilityAreaEffectConfigurator.New(AreaName, Guid)
                .AddAbilityAreaEffectBuff(Buff.Guid)
                .SetShape(AreaEffectShape.Cylinder)
                .SetSize(15.Feet())
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{ed69e2d9-197d-4541-bffc-35fb95d8057a}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSavingThrowBonusAgainstDescriptor(value: -4, spellDescriptor: SpellDescriptor.Disease)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
