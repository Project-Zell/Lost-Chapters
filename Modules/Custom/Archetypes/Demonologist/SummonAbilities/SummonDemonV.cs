using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonV
{
    public static readonly string Guid = "{84aaabf8-bcdb-4b4b-949d-c088fd46c0e4}";

    private static readonly string BaseName = "SummonDemonV";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

    internal static void Configure()
    {
        NabasuSummonUnit.Configure();
        BaseAbility.Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{b36fe33f-29af-481f-9da2-6fe15002c528}";

        private static readonly string AbilityName = $"{BaseName}.BaseAbility";
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
        public static readonly string Guid = "{0d32ec2c-dc39-4271-a8f7-0b0e1daecbdd}";

        private static readonly string AbilityName = $"{BaseName}.Single";
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
                summonUnitID: NabasuSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.single);
        }
    }

    internal class OneToThree
    {
        public static readonly string Guid = "{7804ca2a-ec00-45a0-bacf-c9cb61f7cf5d}";

        private static readonly string AbilityName = $"{BaseName}.d3";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: BabauSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d3);
        }
    }

    internal class OneToFourPlusOne
    {
        public static readonly string Guid = "{f5374338-fdf4-4816-a1ce-00c2e8a531bc}";

        private static readonly string AbilityName = $"{BaseName}.d4plus1";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

        internal static void Configure()
        {
            DemonologistSummonAbilityHelper.CreateSummonAbility(
                guid: Guid,
                name: AbilityName,
                displayName: DisplayName,
                description: Description,
                icon: Icon,
                summonUnitID: SchirSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d4plus1);
        }
    }
}