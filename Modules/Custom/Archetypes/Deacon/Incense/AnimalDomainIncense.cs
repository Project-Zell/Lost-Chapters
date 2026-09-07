using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.UnitLogic.FactLogic;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class AnimalDomainIncense
{
    private static readonly string BaseName = "SavageBreath";
    private static readonly string Domain = FeatureRefs.AnimalDomainAllowed.ToString();

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
        public static readonly string Guid = "{6c8becb8-a7b6-4018-a96a-2aa7607a85de}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{d44f5eb7-e857-4b9e-ad83-f41e425915d7}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsEnemy(),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.Bleed1d6Buff.ToString(), asChild: true));

                BuffConfigurator.New(BuffName, Guid)
                    .AddInitiatorAttackWithWeaponTrigger(action: action, onlyOnFirstAttack: true)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{f31e63ce-6092-4bce-b9e6-b8a3059b89f0}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{a017314d-46db-444e-a1ca-c90416f15e40}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                var action = ActionsBuilder.New().Conditional(ConditionsBuilder.New().IsEnemy(),
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff: BuffRefs.Bleed2d6Buff.ToString(), asChild: true));

                BuffConfigurator.New(BuffName, Guid)
                    .AddInitiatorAttackWithWeaponTrigger(action: action, onlyOnFirstAttack: true)
                    .AddMechanicsFeature(AddMechanicsFeature.MechanicsFeatureType.Pounce)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{b8f59b5a-4e79-46ca-b611-f8a696f34195}";
    }
}