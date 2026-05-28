using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class MeltingMadnessFeature
{
    public static readonly string Guid = "{9b7d8edd-6a7c-44bc-83f0-3c4596bb3f88}";

    private static readonly string FeatureName = "MeltingMadnessFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly int DiseaseDC = 17;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        //4: Melting Madness
        //C: At the start of the day roll for 1d6 damage to Intelegense. Get -2 against mind affected effects
        //B: Get two bite attacks, any of your bites apply melting madness, get inherit +2 to fear affects

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
        public static readonly string Guid = "{364075aa-c7e4-41c4-8a18-d3d008685ec9}";

        private static readonly string BuffName = $"{FeatureName}.SelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var damageDice = new DiceFormula() { m_Dice = DiceType.D6, m_Rolls = 1 };

            var plague = new Plague
            {
                RunActions = false,
                Actions = ActionsBuilder.New().Build(),

                DealStatDamage = true,
                DamageDice = damageDice,
                StatType = StatType.Intelligence,

                SavingThrowDC = DiseaseDC
            };

            var bonus = ContextValues.Constant(-2);

            BuffConfigurator.New(BuffName, Guid)
                .AddComponent(plague)
                .AddSavingThrowContextBonusAgainstDescriptor(
                    value: bonus, 
                    modifierDescriptor: ModifierDescriptor.UntypedStackable, 
                    spellDescriptor: SpellDescriptor.MindAffecting)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class TargetBuff
    {
        public static readonly string Guid = "{94bf7171-fed2-4d82-9b49-7bcaea915090}";

        private static readonly string BuffName = $"{FeatureName}.TargetBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var damageDice = new DiceFormula() { m_Dice = DiceType.D6, m_Rolls = 1 };

            var bonus = ContextValues.Constant(-2);

            BuffConfigurator.New(BuffName, Guid)
                .AddBuffPoisonStatDamage(
                    saveType: SavingThrowType.Fortitude,
                    stat: StatType.Intelligence,
                    value: damageDice,
                    ticks: 1000,
                    succesfullSaves: 2,
                    weaknessForPoison: BuffRefs.PlagueHexConstitutionDamagefromDiseasesBuff.ToString())
                .AddSavingThrowContextBonusAgainstDescriptor(
                    value: bonus,
                    modifierDescriptor: ModifierDescriptor.UntypedStackable,
                    spellDescriptor: SpellDescriptor.MindAffecting)
                .AddSpellDescriptorComponent(SpellDescriptor.Disease)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
