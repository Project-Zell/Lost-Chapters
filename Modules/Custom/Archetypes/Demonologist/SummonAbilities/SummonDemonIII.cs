using LostChapters.Modules.Custom.Archetypes.Demonologist.SummonUnits;
using LostChapters.Modules.Custom.Archetypes.Demonologist.Tools;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist.SummonAbilities;

internal class SummonDemonIII
{
    public static readonly string Guid = "{383664eb-2d0b-4af1-b3d9-27156f203812}";

    private static readonly string BaseName = "SummonDemonIII";

    private static readonly string Icon = $"{CustomModule.IconPath}/summondemon1.png";

    internal static void Configure()
    {
        SchirSummonUnit.Configure();
        BaseAbility.Configure();
    }

    internal class BaseAbility
    {
        public static readonly string Guid = "{25587a9c-a104-4b43-9c51-cb185d54d61f}";

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
        public static readonly string Guid = "{b1266681-8d26-4c11-9e9e-19d927b17c1f}";

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
                summonUnitID: SchirSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.single);
        }
    }

    internal class OneToThree
    {
        public static readonly string Guid = "{dc953d1e-ee30-49d9-96b1-f83929cfa004}";

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
                summonUnitID: DretchSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d3);
        }
    }

    internal class OneToFourPlusOne
    {
        public static readonly string Guid = "{82daca8b-2344-4031-a161-9ffc7ca7656a}";

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
                summonUnitID: QuasitSummonUnit.Guid,
                countType: DemonologistSummonAbilityHelper.SummonCountType.d4plus1);
        }
    }
}
