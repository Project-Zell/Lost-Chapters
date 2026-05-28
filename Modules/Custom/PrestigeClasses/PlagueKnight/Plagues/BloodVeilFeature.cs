using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class BloodVeilFeature
{
    public static readonly string Guid = "{cc9c6217-db50-46c9-a0dd-f07874d3e1b1}";

    private static readonly string FeatureName = "BloodVeilFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly int DiseaseDC = 18;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        //6: Blood Veil
        //B: At the start of the day roll for strengts drain 1d6, -2 to diplomacy.
        //C: Scoring Critical hit allow to all disease effects on the target to trigger aggain. Get +4 inherit to strenght.

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
        public static readonly string Guid = "{222c5c29-57ab-4dad-ba41-acb4aa2454a9}";

        private static readonly string BuffName = $"{FeatureName}.SelfBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var damageDice = new DiceFormula() { m_Dice = DiceType.D6, m_Rolls = 1 };

            var plague = new Plague
            {
                RunActions = false,
                Actions = ActionsBuilder.New().Build(),

                DealStatDamage = true,
                StatType = StatType.Strength,
                DamageDice = damageDice,

                SavingThrowDC = DiseaseDC
            };

            BuffConfigurator.New(BuffName, Guid)
                .AddComponent(plague)
                .AddContextStatBonus(stat: StatType.CheckDiplomacy, value: -2)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class TargetBuff
    {
        public static readonly string Guid = "{5bbcbea6-6488-4a18-9a4d-58dad501bc65}";

        private static readonly string BuffName = $"{FeatureName}.TargetBuff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            var damageDice = new DiceFormula() { m_Dice = DiceType.D6, m_Rolls = 1 };

            BuffConfigurator.New(BuffName, Guid)
                .AddSpellDescriptorComponent(descriptor: SpellDescriptor.Disease)
                .AddBuffPoisonStatDamage(
                    saveType: SavingThrowType.Fortitude, 
                    stat: StatType.Strength, 
                    value: damageDice, 
                    ticks: 1000, 
                    succesfullSaves: 2,
                    weaknessForPoison: BuffRefs.PlagueHexConstitutionDamagefromDiseasesBuff.ToString())
                .AddContextStatBonus(stat: StatType.CheckDiplomacy, value: -2)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
