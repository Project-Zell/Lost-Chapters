using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Items.Armors;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.DisciplineOld;

internal class FeedOnFearFeature
{
    public static readonly string Guid = "{ef010a7a-8e99-4b62-a0dc-584c099a2c8c}";

    private static readonly string FeatureName = "FeedOnFearFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        FeatureConfigurator.New(FeatureName, Guid)
            .AddHasArmorFeatureUnlock(
                filterByArmorProficiencyGroup: true,
                armorProficiencyGroupEntries: ArmorProficiencyGroupFlag.Heavy,
                newFact: ArmorFeature.Guid)
            .SetIsClassFeature(true)
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            //.AddFeatureTagsComponent()
            //.SetIcon(Icon)
            .Configure();
    }

    internal class ArmorFeature
    {
        public static readonly string Guid = "{e2e6146c-e23e-4bfc-81cb-62a8458f136b}";

        private static readonly string FeatureName = $"{FeedOnFearFeature.FeatureName}.ArmorFeature";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var value = ContextValues.Rank();

            //Mobility, Stealth, Trickery, 
            FeatureConfigurator.New(FeatureName, Guid)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
