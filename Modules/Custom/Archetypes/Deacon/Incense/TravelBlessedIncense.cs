using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class TravelBlessedIncense
{
    private static readonly string BaseName = "TravelBlessedIncense";
    private static readonly string Domain = FeatureRefs.TravelDomainAllowed.ToString();

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
        public static readonly string Guid = "{fd293d1b-5f18-48d8-9937-efa33db47ae6}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{584a4112-0b3d-403f-9b39-041b0e57e883}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Constitution, value: 2)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Fatigue, value: 2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Exhausted, value: 2, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{6ac7251f-4d35-4110-96aa-af3bd09b2d33}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{9e1d0f3d-cd80-4e40-932b-4ac4d4b0ec9c}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Alchemical, stat: StatType.Constitution, value: 4)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Fatigue, value: 4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Exhausted, value: 4, modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{a7b94503-0021-49a6-b330-af2541553872}";
    }
}