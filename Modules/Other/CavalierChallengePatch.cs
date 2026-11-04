using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using LostChapters._test;

namespace LostChapters.Modules.Other;

internal class CavalierChallengePatch
{
    internal static void Configure()
    {
        Buff.Configure();

        BuffConfigurator.For(BuffRefs.CavalierChallengeBuffTarget.ToString())
            .SetFlags(BlueprintBuff.Flags.HiddenInUi)
            .Configure();

        var action = ActionsBuilder.New()
            .ApplyBuffPermanent(buff: BuffRefs.CavalierChallengeBuffTarget.ToString(), asChild: true)
            .ApplyBuffPermanent(buff: Buff.Guid, asChild: true);

        AbilityConfigurator.For(AbilityRefs.CavalierCallingAbility.ToString())
            .AddAbilityEffectRunAction(actions: action)
            .Configure();
    }

    internal class Buff
    {
        public static readonly string Guid = "{5721f48b-4868-4192-b1c7-0e653cab6a33}";

        private static readonly string BaseName = "CavalierChallengeProxy";

        private static readonly string FeatureName = $"{BaseName}Feature";

        internal static void Configure()
        {
            var cavalieChallengeBuff = BuffRefs.CavalierChallengeBuffTarget.Reference.Get();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddComponent<LinkBuffRemoval>(x =>
                {
                    x.Target = BlueprintTool.Get<BlueprintBuff>(BuffRefs.CavalierChallengeBuffTarget.ToString());
                })
                .SetDisplayName(cavalieChallengeBuff.m_DisplayName)
                .SetDescription(cavalieChallengeBuff.Description)
                .SetIcon(cavalieChallengeBuff.Icon)
                .Configure();
        }
    }
}