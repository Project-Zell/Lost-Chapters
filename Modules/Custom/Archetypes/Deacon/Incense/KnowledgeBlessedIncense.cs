using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using LostChapters.Modules.Custom.Archetypes.Deacon.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Deacon.Incense;

internal class KnowledgeBlessedIncense
{
    private static readonly string BaseName = "KnowledgeBlessedIncense";
    private static readonly string Domain = FeatureRefs.KnowledgeDomainAllowed.ToString();

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
        public static readonly string Guid = "{18cb7946-94b9-4f6d-b137-8919da4b38dd}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{bb75a261-66e4-46ad-800f-de34903251fe}";

            private static readonly string BuffName = $"{BaseName}MinorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(value: 2, stat: StatType.Intelligence, descriptor: ModifierDescriptor.Alchemical)
                    .AddSavingThrowBonusAgainstDescriptor(
                        value: 2, 
                        spellDescriptor: SpellDescriptor.Disease, 
                        modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class MajorFeature
    {
        public static readonly string Guid = "{fc3c8ac8-90a2-4874-8711-419f987713fe}";

        internal static void Configure()
        {
            Buff.Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{95000e0f-0a0d-448b-ad7a-edf8e25b3471}";

            private static readonly string BuffName = $"{BaseName}MajorBuff";

            internal static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(value: 4, stat: StatType.Intelligence, descriptor: ModifierDescriptor.Alchemical)
                    .AddSavingThrowBonusAgainstDescriptor(
                        value: 4,
                        spellDescriptor: SpellDescriptor.Disease,
                        modifierDescriptor: ModifierDescriptor.Alchemical)
                    .Configure();
            }
        }
    }

    internal class ExtraIncenseProgression
    {
        public static readonly string Guid = "{6388b53b-9d3e-47bb-a248-38e0247e354b}";
    }
}
