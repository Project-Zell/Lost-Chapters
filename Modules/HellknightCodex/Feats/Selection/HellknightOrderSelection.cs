using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes.Selection;

namespace LostChapters.Modules.GraySisterhood.Feats.Selection
{
    internal class HellknightOrderSelection
    {
        public static string FakeOrderSelector => FakeOrderGuid;
        public static string HellknightOrderVariantRef => HellknightOrderVariantGuid;

        private static readonly string HellknightOrderName = "Hellknight.OrderSelection.BuffName";
        private static readonly string HellknightOrderDescription = "Hellknight.OrderSelection.Description";

        private static readonly string HellknightOrderVariant = "Hellknight.OrderVariant";
        private static readonly string HellknightOrderVariantGuid = "f56c5132-84dd-40c4-bac7-95510867da61";

        private static readonly string HellknightOrderVariantDisplayName = "Hellknight.OrderVariant.BuffName";
        private static readonly string HellknightOrderVariantDescription = "Hellknight.OrderVariant.Description";

        private static readonly string FakeOrder = "Hellknight.ArmorTraining";
        private static readonly string FakeOrderGuid = "6dc2a4ca-62bf-4ee3-90d0-390e7e44d443";

        public static void Configure()
        {
            FeatureSelectionConfigurator.New(HellknightOrderVariant, HellknightOrderVariantGuid)
                .AddToAllFeatures(CreateOrderSelection())
                .AddToAllFeatures(CreateFakeOrderSelection())
                .SetDisplayName(HellknightOrderVariantDisplayName)
                .SetDescription(HellknightOrderVariantDescription)
                .Configure();
        }

        private static BlueprintFeatureSelection CreateOrderSelection()
        {
            return FeatureSelectionConfigurator.For(FeatureSelectionRefs.HellKnightOrderSelection)
                .ClearAllFeatures()
                .SetDisplayName(HellknightOrderName)
                .SetDescription(HellknightOrderDescription)
                .Configure();
        }

        private static BlueprintFeatureSelection CreateFakeOrderSelection()
        {
            return FeatureSelectionConfigurator.New(FakeOrder, FakeOrderGuid)
                .AddPrerequisiteFeature(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
                .SetDisplayName(HellknightOrderName)
                .SetDescription(HellknightOrderDescription)
                .Configure();
        }
    }
}
