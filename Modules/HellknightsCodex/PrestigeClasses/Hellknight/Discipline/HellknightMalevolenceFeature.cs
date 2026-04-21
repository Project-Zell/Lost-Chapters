using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Items.Armors;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class HellknightMalevolenceFeature
{
    public static readonly string Guid = "{f63dedc9-d772-4e24-96b2-0ee211a9261c}";

    private static readonly string FeatureName = "HellknightMalevolenceFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

    internal static void Configure()
    {
        ArmorFeature.Configure();

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
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
        public static readonly string Guid = "{6434b19b-2ad8-4291-87f2-bfe9f640b36c}";

        private static readonly string FeatureName = $"{HellknightMalevolenceFeature.FeatureName}.ArmorFeature";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddAdditionalLimb(ItemWeaponRefs.Slam1d8.ToString())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetHideInUI(true)
                .SetHideNotAvailibleInUI(true)
                .Configure();
        }
    }
}
