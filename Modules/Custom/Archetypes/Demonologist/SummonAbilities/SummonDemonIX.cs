using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonIX
{
    public static readonly string Guid = "{d6e39f56-450c-4492-8059-e13dc424d5f2}";

    private static readonly string BaseName = "SummonDemonIX";

    internal static readonly string Icon = $"{CustomModule.IconPath}/{DemonologistArchetype.BaseName}/{BaseName}.png".ToLower();

    internal static void Configure()
    {
        BalorSummonUnit.Configure();
        BaseAbility.Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{724aacc4-e0f5-4aff-a37e-572f206ba3ab}";

        private static readonly string AbilityName = $"{BaseName}Base";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            Single.Configure();
            OneToThree.Configure();
            OneToFourPlusOne.Configure();

            DemonologistSummonAbilityHelper.CreateBaseAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                abilities: [Single.Guid, OneToThree.Guid, OneToFourPlusOne.Guid]);
        }
    }

    internal class Single
    {
        public static readonly string Guid = "{a361bb77-0b9a-4f4c-90cf-84a3de98e6b9}";

        private static readonly string AbilityName = $"{BaseName}Single";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: BalorSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.Single,
                fxSize: BalorSummonUnit.FxSize);
        }
    }

    internal class OneToThree
    {
        public static readonly string Guid = "{6ad1d218-1b05-4661-843b-afbcd42298bd}";

        private static readonly string AbilityName = $"{BaseName}OneToThree";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: SummonDemonVIII.Icon,
                summonUnitID: GalluSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d3, 
                fxSize: GalluSummonUnit.FxSize);
        }
    }

    internal class OneToFourPlusOne
    {
        public static readonly string Guid = "{e7757cad-1d2c-40da-9e73-c818ef5281e2}";

        private static readonly string AbilityName = $"{BaseName}OneToFourPlusOne";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: SummonDemonVII.Icon,
                summonUnitID: KalavakusSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d4plus1, 
                fxSize: KalavakusSummonUnit.FxSize);
        }
    }
}
