using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using LostChapters._test;
using LostChapters.Modules.GraySisterhood.Feats;

namespace LostChapters.Modules.GraySisterhood;

internal class BasicProgression
{
    internal static void Configure()
    {
        var ability = AbilityConfigurator.New($"Testinngsds.Ability", "{7d89ae63-4dc6-4ba1-aef6-b7672b5121dd}")
            .AllowTargeting(point: false, enemies: false, friends: false, self: true)
            .AddComponent<TestInventoryCharacter>()
            .AddAbilityEffectRunAction(actions: ActionsBuilder.New().ApplyBuffPermanent(BuffRefs.Fx_HellHound00.ToString()))
            .AddHideDCFromTooltip()
            .AddHideFeatureInInspect()
            .SetType(AbilityType.Special)
            .SetDisplayName("{HHProgression.Name}")
            .SetDescription("{HHProgression.Description}")
            .SetIcon(AbilityRefs.Eyebite.Reference.Get().Icon)
            .Configure();

        var fact = FeatureConfigurator.New($"Testinngsds.Feat", "{a2ab8d99-846b-43f5-8431-b5cf56e6a8a8}")
            .AddFacts([ability])
            .SetDisplayName("HHAbilityName")
            .SetDescription("HHwhatervers")
            .Configure();




        FeatureConfigurator.For(FeatureRefs.SkillAbilities)
            .AddFacts([AidAnotherFeature.Guid, fact])
            .Configure();
    }
}
