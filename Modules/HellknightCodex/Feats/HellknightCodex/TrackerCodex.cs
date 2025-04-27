using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;

namespace LostChapters.Modules.GraySisterhood.Feats.HellknightCodex
{
    internal class TrackerCodex
    {
        public static readonly string Guid = "e6182bd4-ff29-426e-833b-0345931dc025";

        private const string CodexName = "TrackerCodex";
        private const string CodexDisplayName = "TrackerCodex.BuffName";
        private const string CodexDescription = "TrackerCodex.LocalizedDescription";

        public static readonly string UnitGuid = "d6ed9b34-a6dc-40d4-80ec-4498e26317da";

        private const string UnitName = "HellhoundCompanion";
        private const string UnitDisplayName = "Hellhound.BuffName";

        public static void Confgig()
        {

            //no mount
            //chack fx reset

            HellhoundCompanionUnit.Configure();

            FeatureConfigurator.New(CodexName, Guid)
                .AddToFeatureSelection(FeatureSelectionRefs.BasicFeatSelection.ToString())
                .AddPet(
                    pet: HellhoundCompanionUnit.Guid,
                    useContextValueLevel: true,
                    levelContextValue: ContextValues.Constant(5))
                .SetReapplyOnLevelUp(true)
                .SetIsClassFeature(true)
                .SetDisplayName(CodexDisplayName)
                .SetDescription(CodexDescription)
                .Configure();
        }
    }
}
