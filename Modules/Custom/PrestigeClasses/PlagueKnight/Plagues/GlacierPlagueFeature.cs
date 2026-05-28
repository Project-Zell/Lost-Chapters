using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class GlacierPlagueFeature
{
    public static readonly string Guid = "{481ff703-6505-4ff5-904f-93deba93865c}";

    private static readonly string FeatureName = "GlacierPlagueFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly int DiseaseDC = 17;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
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
        public static readonly string Guid = "{bb778a45-6cb3-441a-9e30-e04c27159f73}";

        private static readonly string BuffName = $"{FeatureName}.SelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var duration = ContextDuration.FixedDice(DiceType.D3, diceCount: 1);

            var action = ActionsBuilder.New().SavingThrow(type: SavingThrowType.Fortitude, customDC: ContextValues.Constant(DiseaseDC), onResult:
                ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Slowed.ToString(), durationValue: duration)));

            BuffConfigurator.New(BuffName, Guid)
                .AddIncomingDamageTrigger(
                    actions: action,
                    checkEnergyDamageType: true,
                    energyType: DamageEnergyType.Cold)
                .AddContextStatBonus(stat: StatType.SkillAthletics, value: -2)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class TargetBuff
    {
        public static readonly string Guid = "{6b9760bb-dc7a-4ed9-9f97-079da0290967}";

        private static readonly string BuffName = $"{FeatureName}.TargetBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var duration = ContextDuration.FixedDice(DiceType.D3, diceCount: 1);

            var action = ActionsBuilder.New().SavingThrow(type: SavingThrowType.Fortitude, customDC: ContextValues.Constant(DiseaseDC), onResult:
                ActionsBuilder.New().ConditionalSaved(failed: ActionsBuilder.New().ApplyBuff(buff: BuffRefs.Slowed.ToString(), durationValue: duration)));

            BuffConfigurator.New(BuffName, Guid)
                .AddSpellDescriptorComponent(descriptor: SpellDescriptor.Disease)
                .AddIncomingDamageTrigger(
                    actions: action,
                    checkEnergyDamageType: true,
                    energyType: DamageEnergyType.Cold)
                .AddContextStatBonus(stat: StatType.SkillAthletics, value: -2)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
