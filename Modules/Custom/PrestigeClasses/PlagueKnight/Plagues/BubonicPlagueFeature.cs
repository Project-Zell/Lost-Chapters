using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using dnlib.DotNet;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class BubonicPlagueFeature
{
    public static readonly string Guid = "{3a031ac7-e292-45c3-b654-b1a2a256a8e7}";

    private static readonly string FeatureName = "BubonicPlagueFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly int DiseaseDC = 17;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        //3: Bubonic plague
        //B: At the start of the day roll for 1d4 damage to Constitution and 8 hours of exaustion
        //C: Get inherit +4 to Constitution. Can summon 1d3 plague rats 3 times per day. Rat apply Bubonicplague.

        SelfBuff.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddFacts([SelfBuff.Guid])
            .AddSpecificBuffImmunity(buff: BuffRefs.DiseaseBubonicPlagueBuff.ToString(), checkCasterFact: true, factToCheck: Guid)
            .AddSpecificBuffImmunity(buff: BuffRefs.ContagionBubonicPlagueBuff.ToString(), checkCasterFact: true, factToCheck: Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class SelfBuff
    {
        public static readonly string Guid = "{92776a4e-0daf-4d10-8e84-4b9fb91a0c04}";

        private static readonly string BuffName = $"{FeatureName}.SelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var action = ActionsBuilder.New().SavingThrow(type: SavingThrowType.Fortitude, customDC: ContextValues.Constant(DiseaseDC), onResult:
                ActionsBuilder.New().ConditionalSaved(
                    failed: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Fatigued.ToString(), durationValue: ContextDuration.Fixed(value: 24, rate: DurationRate.Hours))));

            var formula = new DiceFormula() { m_Dice = DiceType.D4, m_Rolls = 1 };

            var plague = new Plague
            {
                RunActions = true,
                Actions = action.Build(),

                DealStatDamage = true,
                DamageDice = formula,
                StatType = StatType.Constitution,

                SavingThrowDC = DiseaseDC
            };
            
            BuffConfigurator.New(BuffName, Guid)
                .AddComponent(plague)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
