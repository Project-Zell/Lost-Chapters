using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class BleakBreathFeature
{
    public static readonly string Guid = "{2e326563-3557-44a4-9641-57a0e36be00f}";

    private static readonly string FeatureName = "BleakBreathFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly int DiseaseDC = 18;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        //5: Bleak Breath
        //B: At the start of the day roll for get -1 negative level. -1 reflex saves
        //C: All who steps in the aura shold roll for save of be nauseated for 1 round. Ummune to negative levels.

        SelfBuff.Configure();
        TargetBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([SelfBuff.Guid])
            .AddSpecificBuffImmunity(buff: TargetBuff.Guid, checkCasterFact: true, factToCheck: Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class SelfBuff
    {
        public static readonly string Guid = "{662b8130-83de-4860-902b-097fde414452}";

        private static readonly string BuffName = $"{FeatureName}.SelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var action = ActionsBuilder.New().SavingThrow(type: SavingThrowType.Fortitude, customDC: ContextValues.Constant(DiseaseDC), onResult:
                ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().DealDamageTemporaryNegativeLevels(
                    duration: ContextDuration.Fixed(value: 24, rate: DurationRate.Hours), value: ContextDice.Value(DiceType.Zero, bonus: 1))));

            var plague = new Plague
            {
                RunActions = false,
                Actions = action.Build(),

                DealStatDamage = false,
                SavingThrowDC = DiseaseDC
            };

            BuffConfigurator.New(BuffName, Guid)
                .AddComponent(plague)
                .AddContextStatBonus(stat: StatType.SaveReflex, value: ContextValues.Constant(-1))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }

    internal class TargetBuff
    {
        public static readonly string Guid = "{3c285610-4b19-4ec0-ab2e-ecc7cce496e9}";

        private static readonly string BuffName = $"{FeatureName}.TargetBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            BuffConfigurator.New(BuffName, Guid)
                .AddSpellDescriptorComponent(descriptor: SpellDescriptor.Disease | SpellDescriptor.NegativeLevel)
                .AddNegativeLevelComponent()
                .AddContextStatBonus(stat: StatType.SaveReflex, value: ContextValues.Constant(-1))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
