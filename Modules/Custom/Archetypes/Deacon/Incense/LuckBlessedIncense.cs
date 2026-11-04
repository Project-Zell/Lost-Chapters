using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Designers.Mechanics.Facts;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class LuckBlessedIncense
{
    private static readonly string BaseName = "LuckBlessedIncense";
    private static readonly string Domain = FeatureRefs.LuckDomainAllowed.ToString();

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
        public static readonly string Guid = "{0805bbd9-51aa-41fa-8023-b65692545ef0}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{7b0cd6a2-8f03-49dc-a8d6-b99a88038fec}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddModifyD20(
                        rule: RuleType.SavingThrow | RuleType.SkillCheck, 
                        rollsAmount: 1, 
                        takeBest: true,
                        withChance: true,
                        chance: 33)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{416ab08d-0610-47c7-b697-776f0616d650}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{3f2e8aea-ad83-44f6-9325-406422acc807}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddModifyD20(
                        rule: RuleType.SavingThrow | RuleType.AttackRoll | RuleType.SkillCheck, 
                        rollsAmount: 2, 
                        withChance: true,
                        takeBest: true, 
                        chance: 33)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{b517db75-c5f8-4fcf-98d7-862414873a89}";
    }
}