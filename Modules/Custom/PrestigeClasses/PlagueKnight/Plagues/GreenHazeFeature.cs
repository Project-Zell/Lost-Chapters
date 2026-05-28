using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class GreenHazeFeature
{
    public static readonly string Guid = "{0e2a7936-4df1-4dcf-b175-bfa3f85f8d3f}";

    private static readonly string FeatureName = "GreenHazeFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly int DiseaseDC = 18;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        //1: Green Haze
        //B: At the start of the day roll for blindness 8 hour. Permanennt -2 to perseptions checks
        //C: Permablind without negative condition (Immune to Blind and Gaze attacks) has blind vision 30ft. 

        SelfBuff.Configure();
        TargetBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([SelfBuff.Guid])
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.SetIcon(Icon)
            .Configure();
    }

    internal class SelfBuff
    {
        public static readonly string Guid = "{26ceac36-3942-4d40-ad16-1e536466e0ee}";

        private static readonly string BuffName = $"{FeatureName}.SelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var action = ActionsBuilder.New().SavingThrow(type: SavingThrowType.Fortitude, customDC: ContextValues.Constant(DiseaseDC), onResult:
                ActionsBuilder.New().ConditionalSaved(
                    failed: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Blind.ToString(), durationValue: ContextDuration.Fixed(value: 24, rate: DurationRate.Hours))));

            var plague = new Plague
            {
                RunActions = true,
                Actions = action.Build(),

                DealStatDamage = false,

                SavingThrowDC = DiseaseDC
            };

            BuffConfigurator.New(BuffName, Guid)
                .AddComponent(plague)
                .AddContextStatBonus(stat: StatType.SkillPersuasion, value: -2)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class TargetBuff
    {
        public static readonly string Guid = "{0980c7ed-1458-42ba-aaa2-2b1cc1010f8b}";

        private static readonly string BuffName = $"{FeatureName}.TargetBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var action = ActionsBuilder.New().SavingThrow(type: SavingThrowType.Fortitude, customDC: ContextValues.Constant(DiseaseDC), onResult:
                            ActionsBuilder.New().ConditionalSaved(
                                failed: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Blind.ToString(), durationValue: ContextDuration.Fixed(value: 24, rate: DurationRate.Hours))));

            BuffConfigurator.New(BuffName, Guid)
                .AddContextStatBonus(stat: StatType.SkillPersuasion, value: -2)
                .AddFactContextActions(activated: action)
                .AddSpellDescriptorComponent(SpellDescriptor.Disease)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
