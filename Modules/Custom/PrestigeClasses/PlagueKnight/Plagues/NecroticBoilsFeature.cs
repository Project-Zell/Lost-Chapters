using BlueprintCore.Actions.Builder;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem;
using LostChapters._wip;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight.Plagues;

internal class NecroticBoilsFeature
{
    public static readonly string Guid = "{24e5d5fd-03c5-4849-a958-4e60d022c08f}";

    private static readonly string FeatureName = "NecroticBoilsFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    private static readonly int DiseaseDC = 17;

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        ///Disease - One time per day, target should succesed on fortitude save, or get 1d6 points of charisma damage. 
        ///Additionaly target suffer -2 profane penalty to AC.
        ///Requiem - First time in the round, when Plague Knight recieve damage, 
        ///he deal 3d8 acid damage to all enemies in 15ft radius. That damage is apply Necrotic Boils.

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
        public static readonly string Guid = "{33aa16b3-956b-412b-8fdf-deb9c6c1aa31}";

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
                StatType = StatType.Charisma,

                SavingThrowDC = DiseaseDC
            };

            var bonus = ContextValues.Constant(-2);

            BuffConfigurator.New(BuffName, Guid)
                .AddComponent(plague)
                .AddContextStatBonus(stat: StatType.AC, descriptor: ModifierDescriptor.Profane, value: bonus)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class TargetBuff
    {
        public static readonly string Guid = "{64ba547b-809f-412d-8bbd-8b52acfe66b6}";

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
                    stat: StatType.Charisma,
                    value: damageDice,
                    ticks: 1000,
                    succesfullSaves: 2,
                    weaknessForPoison: BuffRefs.PlagueHexConstitutionDamagefromDiseasesBuff.ToString())
                .AddContextStatBonus(stat: StatType.AC, descriptor: ModifierDescriptor.Profane, value: bonus)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.SetIcon(Icon)
                .Configure();
        }
    }
}