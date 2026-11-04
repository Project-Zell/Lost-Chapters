using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using LostChapters.Modules.Custom.Archetypes.FalseKnight.Tools;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight.FallenOrder;

internal class ImpostorFeature
{
    public static readonly string Guid = "{d0c9b52f-faf9-4dd1-82b2-e813fb2a4036}";

    private static readonly string BaseName = "Impostor";

    private static readonly string FeatureName = $"{BaseName}Feature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        FeatureSelectionConfigurator.New(FeatureName, Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

        Lion.Configure();
        Star.Configure();
        Sword.Configure();
        Shroud.Configure();
        Cockatrice.Configure();
    }

    internal class Lion
    {
        public static readonly string Guid = "{dc7249d9-1b33-4ce9-a20f-ccd235a5a9ae}";

        private static readonly BlueprintProgression Progression = ProgressionRefs.CavalierOrderOfTheLionProgression.Reference;

        internal static void Configure()
        {
            FalseKnightImpostorTool.CreateAndAddToImpostorSelection(guid: Guid, orderProgression: Progression);
        }
    }

    internal class Star
    {
        public static readonly string Guid = "{d21ebb03-a312-45b8-8158-5eae7baeea00}";

        private static readonly BlueprintProgression Progression = ProgressionRefs.CavalierOrderOfTheStarProgression.Reference;

        internal static void Configure()
        {
            FalseKnightImpostorTool.CreateAndAddToImpostorSelection(guid: Guid, orderProgression: Progression);
        }
    }

    internal class Sword
    {
        public static readonly string Guid = "{4336a964-d8d9-4c18-98f1-1e5e61178002}";

        private static readonly BlueprintProgression Progression = ProgressionRefs.CavalierOrderOfTheSwordProgression.Reference;

        internal static void Configure()
        {
            FalseKnightImpostorTool.CreateAndAddToImpostorSelection(guid: Guid, orderProgression: Progression);
        }
    }

    internal class Shroud
    {
        public static readonly string Guid = "{852da633-d2f9-47b7-a058-44280aeaba53}";

        private static readonly BlueprintProgression Progression = ProgressionRefs.CavalierOrderOfTheShroudProgression.Reference;

        internal static void Configure()
        {
            FalseKnightImpostorTool.CreateAndAddToImpostorSelection(guid: Guid, orderProgression: Progression);
        }
    }

    internal class Cockatrice
    {
        public static readonly string Guid = "{64b1e2b5-c716-4841-af57-48eaddef505a}";

        private static readonly BlueprintProgression Progression = ProgressionRefs.CavalierOrderOfTheCockatriceProgression.Reference;

        internal static void Configure()
        {
            FalseKnightImpostorTool.CreateAndAddToImpostorSelection(guid: Guid, orderProgression: Progression);
        }
    }
}