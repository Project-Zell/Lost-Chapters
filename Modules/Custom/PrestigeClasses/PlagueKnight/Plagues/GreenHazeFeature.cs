using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class GreenHazeFeature
{
    public static readonly string Guid = "{0e2a7936-4df1-4dcf-b175-bfa3f85f8d3f}";

    private static readonly string FeatureName = "GreenHazeFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        Buff.Configure();
        Capstone.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([Buff.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class Capstone
    {
        public static readonly string Guid = "{1cdf184f-05a3-47f8-9aa0-a7f0cfdda077}";

        private static readonly string FeatureName = "GreenHazeFeature.Capstone";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddBuffDescriptorImmunity(descriptor: SpellDescriptor.SightBased)
                .AddSpellImmunityToSpellDescriptor(descriptor: SpellDescriptor.SightBased)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{26ceac36-3942-4d40-ad16-1e536466e0ee}";

        private static readonly string BuffName    = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().CasterHasFact(BuffRefs.Blind.ToString()),
                ifFalse: ActionsBuilder.New().SavingThrow(SavingThrowType.Fortitude).ConditionalSaved(
                    failed: ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.Blind.ToString())));

            BuffConfigurator.New(BuffName, Guid)
                .AddSpellDescriptorComponent(SpellDescriptor.Disease)
                .AddRestTrigger(action)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
