using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.RuleSystem.Rules;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class NobilityBlessedIncense
{
    private static readonly string BaseName = "NobilityBlessedIncense";
    private static readonly string Domain = FeatureRefs.NobilityDomainAllowed.ToString();

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
        public static readonly string Guid = "{0f15d79b-59a5-48d5-86a2-3e183741fb79}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{f80392ac-e8c2-4ee4-a2c3-e4261b85af6a}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(stat: StatType.SaveWill, value: 1, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveReflex, value: 1, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveFortitude, value: 1, descriptor: ModifierDescriptor.Alchemical)
                    .AddCMBBonusForManeuver(value: 2, maneuvers: [CombatManeuver.Disarm], descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{e69b0cb6-a56e-48ac-91bc-5b354a0bc778}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{04074df2-f237-4b14-b424-2c0706cc4491}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(stat: StatType.SaveWill, value: 2, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveReflex, value: 2, descriptor: ModifierDescriptor.Alchemical)
                    .AddStatBonus(stat: StatType.SaveFortitude, value: 2, descriptor: ModifierDescriptor.Alchemical)
                    .AddCMBBonusForManeuver(value: 4, maneuvers: [CombatManeuver.Disarm], descriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{f3b0fbf4-91bc-43b1-9629-9e11103716a3}";
    }
}
