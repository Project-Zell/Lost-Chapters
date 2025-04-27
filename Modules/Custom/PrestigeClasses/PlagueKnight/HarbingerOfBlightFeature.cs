using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using LostChapters.Modules.Custom.Components;

namespace LostChapters.Modules.Custom.PrestigeClasses.PlagueKnight;

internal class HarbingerOfBlightFeature
{
    public static readonly string Guid = "{5cb51b7b-3f25-49b4-b3b6-f10ee86464f7}";

    private static readonly string FeatureName = "HarbingerOfBlight";
    private static readonly string DisplayName = "HarbingerOfBlight.Name";
    private static readonly string Description = "HarbingerOfBlight.Description";

    private static readonly string Icon = $"{CustomModule.IconPath}/blackrot.png";
    public static void Configure()
    {
        //DiseaseShakes.Configure();
        //DiseaseMindFire.Configure();
        //DiseaseCackleFever.Configure(); 
        //DiseaseBubonicPlague.Configure();   
        //DiseaseBlindingSickness.Configure();    
        //DiseaseAthrakitis.Configure();
        //DiseaseEntericFever.Configure();
        //DiseaseTuberculosis.Configure();

        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .AddComponent<IgnoreDesease>()
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }

    internal class DiseaseShakes
    {
        public static readonly string Guid = "{ccadb51b-afcc-40f0-ba57-f4050f764dd6}";

        private static readonly string FeatureName = "HarbingerOfBlight.Shakes";
        private static readonly string DisplayName = "HarbingerOfBlight.Shakes.Name";
        private static readonly string Description = "HarbingerOfBlight.Shakes.Description";
        
        public static void Configure()
        {
            //1d8 dex

            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{b6299372-3ea0-41a5-aaba-e46cbb097e25}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class DiseaseMindFire
    {
        public static readonly string Guid = "{f25f15d8-c239-43be-8323-a14325fc0b45}";

        private static readonly string FeatureName = "HarbingerOfBlight.MindFire";
        private static readonly string DisplayName = "HarbingerOfBlight.MindFire.Name";
        private static readonly string Description = "HarbingerOfBlight.MindFire.Description";

        public static void Configure()
        {
            //1d4 int
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{53a30c1b-0999-422e-bab5-f0b882e4c527}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class DiseaseCackleFever
    {
        public static readonly string Guid = "{713bbb47-692f-4ae3-9b34-74d18a77c153}";

        private static readonly string FeatureName = "HarbingerOfBlight.CackleFever";
        private static readonly string DisplayName = "HarbingerOfBlight.CackleFever.Name";
        private static readonly string Description = "HarbingerOfBlight.CackleFever.Description";
        
        public static void Configure()
        {
            //1d6 wis
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{6484e56a-8ced-443c-9660-a5e9140c16e1}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class DiseaseBubonicPlague
    {
        public static readonly string Guid = "{aef8d1de-2395-4869-8036-c6acfcbcf4ee}";

        private static readonly string FeatureName = "HarbingerOfBlight.BubonicPlague";
        private static readonly string DisplayName = "HarbingerOfBlight.BubonicPlague.Name";
        private static readonly string Description = "HarbingerOfBlight.BubonicPlague.Description";
        
        public static void Configure()
        {
            //1d4 con and 1 cha, fatigued
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{5d5cd1a0-a3c6-4394-9d7b-3f00fecec74e}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class DiseaseBlindingSickness
    {
        public static readonly string Guid = "{51af70e8-7fa4-4af4-9a16-288c07376100}";

        private static readonly string FeatureName = "HarbingerOfBlight.BlindingSickness";
        private static readonly string DisplayName = "HarbingerOfBlight.BlindingSickness.Name";
        private static readonly string Description = "HarbingerOfBlight.BlindingSickness.Description";
        
        public static void Configure()
        {
            //1d4 str and blind
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{d54fe41c-5a79-4426-a4e3-d4be4cfbc8da}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class DiseaseAthrakitis
    {
        public static readonly string Guid = "{e7209acd-a06d-4058-8870-bdc310f6d6d2}";

        private static readonly string FeatureName = "HarbingerOfBlight.Athrakitis";
        private static readonly string DisplayName = "HarbingerOfBlight.Athrakitis.Name";
        private static readonly string Description = "HarbingerOfBlight.Athrakitis.Description";
        
        public static void Configure()
        {
            //1d8 str
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{5531e17a-79d6-410f-9c11-e3f9b6120c17}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class DiseaseEntericFever
    {
        public static readonly string Guid = "{c9633c8e-72e5-4746-9678-23c65ecc2df3}";

        private static readonly string FeatureName = "HarbingerOfBlight.EntericFever";
        private static readonly string DisplayName = "HarbingerOfBlight.EntericFever.Name";
        private static readonly string Description = "HarbingerOfBlight.EntericFever.Description";
        
        public static void Configure()
        {
            //1d4 str 1d4 con sickened
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{df6099c6-9610-47bb-ae66-54459eb3560c}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }

    internal class DiseaseTuberculosis
    {
        public static readonly string Guid = "{dc94674a-7c00-4f23-af58-b56b3b7c8b8c}";

        private static readonly string FeatureName = "HarbingerOfBlight.Tuberculosis";
        private static readonly string DisplayName = "HarbingerOfBlight.Tuberculosis.Name";
        private static readonly string Description = "HarbingerOfBlight.Tuberculosis.Description";
        
        public static void Configure()
        {
            //1d4 str 1d4 con sickened
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddFacts([Buff.Guid])
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{8a5c5403-6e8e-40f1-bbc7-0dc8dc011a39}";

            private static readonly string BuffName = "HarbingerOfBlight.Shakes.Buff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .Configure();
            }
        }
    }
}
