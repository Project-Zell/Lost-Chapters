using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class StrengthBlessedIncense
{
    private static readonly string BaseName = "StrengthBlessedIncense";
    private static readonly string Domain = FeatureRefs.StrengthDomainAllowed.ToString();

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
        public static readonly string Guid = "{34464676-4716-42ab-b2d5-51249eead8ca}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{a776b62f-0293-4e1c-af4b-359cf1f35648}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Strength, value: 2)
                    .AddCMBBonusForManeuver(value: 2, maneuvers: [CombatManeuver.BullRush], descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{439eef1e-5a5f-42c9-a2d5-402aa9331b1e}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{b9277fb6-e782-4854-b7fb-dde66c5cfcdf}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Strength, value: 4)
                    .AddCMBBonusForManeuver(value: 4, maneuvers: [CombatManeuver.BullRush], descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }

    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{351fbef6-9648-42a7-821e-d6ab644f7a5a}";
    }
}