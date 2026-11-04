using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic.Mechanics;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class PlantBlessedIncense
{
    private static readonly string BaseName = "PlantBlessedIncense";
    private static readonly string Domain = FeatureRefs.PlantDomainAllowed.ToString();

    internal static void Configure()
    {
        MinorFeature.Configure();
        MajorFeature.Configure();

        var minorBuffContainer = (MinorFeature.Buff.Guid, DeaconInsenceHelper.TargetType.Ally);
        var majorBuffContainer = (MajorFeature.Buff.Guid, DeaconInsenceHelper.TargetType.Ally);

        DeaconInsenceHelper.CreateInsence(
            baseName: BaseName,
            domainGuid: Domain,
            minorFeatureGuid: MinorFeature.Guid,
            majorFeatureGuid: MajorFeature.Guid,
            extraIncenceGuid: ExtraIncenseProgression.Guid,
            minorBuffs: [minorBuffContainer],
            majorBuffs: [majorBuffContainer]);
    }

    internal class MinorFeature
    {
        public static readonly string Guid = "{c445d1a3-5abd-4202-ac10-333b2ac8732b}";
        
        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{1812bda6-0601-4ab8-9fae-c211d92fb779}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                var diceValue = new ContextDiceValue
                {
                    DiceType = DiceType.D6,
                    DiceCountValue = 1,
                    BonusValue = 0
                };

                var damageType = new DamageTypeDescription
                {
                    Type = DamageType.Physical,
                    Physical = new DamageTypeDescription.PhysicalData
                    {
                        Form = PhysicalDamageForm.Piercing
                    }
                };

                BuffConfigurator.New(BuffName, Guid)
                    .AddTargetAttackRollTrigger(
                        actionsOnAttacker: ActionsBuilder.New().DealDamage(damageType: damageType, value: diceValue, ignoreCritical: true),
                        onlyHit: true,
                        onlyMelee: true,
                        notReach: true,
                        doNotPassAttackRoll: true)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{75558868-fb0d-418d-a3a9-9c8cb1ea6cf1}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{86897bb0-f8ad-4475-a897-ead822e1e114}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                var diceValue = new ContextDiceValue
                {
                    DiceType = DiceType.D6,
                    DiceCountValue = 1,
                    BonusValue = ContextValues.Rank()
                };

                var damageType = new DamageTypeDescription
                {
                    Type = DamageType.Physical,
                    Physical = new DamageTypeDescription.PhysicalData
                    {
                        Form = PhysicalDamageForm.Piercing
                    }
                };

                var config = ContextRankConfigs.ClassLevel([CharacterClassRefs.WarpriestClass.ToString()], min: 0, max: 20).WithDiv2Progression();

                BuffConfigurator.New(BuffName, Guid)
                    .AddTargetAttackRollTrigger(
                        actionsOnAttacker: ActionsBuilder.New().DealDamage(damageType: damageType, value: diceValue, ignoreCritical: true),
                        onlyHit: true,
                        onlyMelee: true,
                        notReach: true,
                        doNotPassAttackRoll: true)
                    .AddContextRankConfig(config)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{73b9dba7-8095-4452-8559-eb12f0f1b7c6}";
    }
}