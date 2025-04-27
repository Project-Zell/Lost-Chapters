using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Properties;
using LostChapters.Modules.GraySisterhood.Components;

namespace LostChapters.Modules.GraySisterhood.Orders.Cavalier.EnneadStar
{
    public class OrderOfTheEnneadStar
    {
        private static readonly string OrderName = "OrderOfTheEnneadStar";
        private static readonly string OrderGuid = "e0f7d339-db42-4e1e-910b-778c34b34633";

        private static readonly string OrderDisplayName = "OrderOfTheEnneadStar.BuffName";
        private static readonly string OrderDescription = "OrderOfTheEnneadStar.Description";
        private static readonly string OrderIcon = "assets/icons/orderofhte.png";

        public static void Configure()
        {
            var orderProgression = ProgressionConfigurator.New(OrderName, OrderGuid)
                .AddToLevelEntry(1, FeatureSelectionRefs.HellKnightOrderSelection.ToString(), EnneadSkillFeat(), CreateChallenge())
                .AddToLevelEntry(2, CreateOpress())
                .AddToLevelEntry(8, CreateSubjugate())
                .AddToLevelEntry(15, CreateHandOfTheLaw())
                .SetDisplayName(OrderDisplayName)
                .SetDescription(OrderDescription)
                .SetIcon(OrderIcon)
                .AddToUIDeterminatorsGroup(FeatureSelectionRefs.HellKnightOrderSelection.ToString())
                .SetClasses(CharacterClassRefs.CavalierClass.ToString())
                .Configure();

            FeatureSelectionConfigurator.For(FeatureSelectionRefs.CavalierOrderSelection.ToString())
                .AddToAllFeatures(orderProgression)
                .Configure();
        }

        #region Skills
        private static readonly string Skills = "OrderOfTheEnneadStar.BuffName";
        private static readonly string SkillsGuid = "54ea51e9-bc66-4573-8e66-04436dcda32d";

        private static readonly string SkillsDisplayName = "OrderOfTheEnneadStar.BuffName.BuffName";
        private static readonly string SkillsDescription = "OrderOfTheEnneadStar.BuffName.Description";

        private static BlueprintFeature EnneadSkillFeat()
        {
            return FeatureConfigurator.New(Skills, SkillsGuid)
                .AddClassSkill(StatType.SkillPerception)
                .SetIsClassFeature(true)
                .SetDisplayName(SkillsDisplayName)
                .SetDescription(SkillsDescription)
                .Configure();
        }
        #endregion

        #region Challenge
        private static readonly string Challenge = "OrderOfTheEnneadStar.Challenge";
        private static readonly string ChallengeGuid = "e6b79fdf-627c-449b-85d4-ca5c563a9981";

        private static readonly string ChallengeDisplayName = "OrderOfTheEnneadStar.Challenge.BuffName";
        private static readonly string ChallengeDescription = "OrderOfTheEnneadStar.Challenge.Description";

        private static BlueprintFeature CreateChallenge()
        {
            return FeatureConfigurator.New(Challenge, ChallengeGuid)
                .AddComponent<OrderOfTheEnneadStarChallenge>()
                .SetIsClassFeature(true)
                .SetDisplayName(ChallengeDisplayName)
                .SetDescription(ChallengeDescription)
                .Configure();
        }
        #endregion

        #region Opress
        public static string OpressGuid => OpressFeatureGuid;

        private static readonly string OpressFeature = "OrderOfTheEnneadStar.Enchantment.Opress";
        private static readonly string OpressFeatureGuid = "0e54e9bd-08b1-41c0-a2ce-6f2f67221760";

        private static readonly string OpressFeatureDisplayName = "OrderOfTheEnneadStar.Enchantment.Opress.BuffName";
        private static readonly string OpressFeatureDescription = "OrderOfTheEnneadStar.Enchantment.Opress.LocalizedDescription";

        private static BlueprintFeature CreateOpress()
        {
            return FeatureConfigurator.New(OpressFeature, OpressFeatureGuid)
                .SetIsClassFeature(true)
                .SetDisplayName(OpressFeatureDisplayName)
                .SetDescription(OpressFeatureDescription)
                .Configure();
        }
        #endregion

        #region Subjugate
        private static readonly string SubjugateFeature = "OrderOfTheEnneadStar.Enchantment.Subjugate";
        private static readonly string SubjugateFeatureGuid = "cd418113-4c0d-4985-8754-b89905dc53a0";

        private static readonly string SubjugateFeatureDisplayName = "OrderOfTheEnneadStar.Enchantment.Subjugate.BuffName";
        private static readonly string SubjugateFeatureDescription = "OrderOfTheEnneadStar.Enchantment.Subjugate.LocalizedDescription";

        private static readonly string SubjugateAbility = "OrderOfTheEnneadStar.Enchantment.Subjugate.Ability";
        private static readonly string SubjugateAbilityGuid = "6356c489-e625-4eda-b27a-4aaa3e126a4f";

        private static BlueprintFeature CreateSubjugate()
        {
            return FeatureConfigurator.New(SubjugateFeature, SubjugateFeatureGuid)
                .AddDamageBonusAgainstAlignment(
                    alignment: AlignmentComponent.Chaotic,
                    bonus: ContextValues.Property(UnitProperty.StatBonusCharisma, true))
                .SetIsClassFeature(true)
                .SetDisplayName(SubjugateFeatureDisplayName)
                .SetDescription(SubjugateFeatureDescription)
                .Configure();
        }
        #endregion

        #region Hand of the Law
        private static readonly string HandOfTheLawFeature = "OrderOfTheEnneadStar.Enchantment.HandOfTheLaw";
        private static readonly string HandOfTheLaweGuid = "bd65db93-e00f-41e6-b9d1-901e4d4b9276";

        private static readonly string HandOfTheLawDisplayName = "OrderOfTheEnneadStar.Enchantment.HandOfTheLaw.BuffName";
        private static readonly string HandOfTheLawDescription = "OrderOfTheEnneadStar.Enchantment.HandOfTheLaw.LocalizedDescription";

        private static BlueprintFeature CreateHandOfTheLaw()
        {
            return FeatureConfigurator.New(HandOfTheLawFeature, HandOfTheLaweGuid)
                .AddCritAutoconfirmAgainstAlignment(AlignmentComponent.Chaotic)
                .SetIsClassFeature(true)
                .SetDisplayName(HandOfTheLawDisplayName)
                .SetDescription(HandOfTheLawDescription)
                .Configure();
        }
        #endregion
    }

}
