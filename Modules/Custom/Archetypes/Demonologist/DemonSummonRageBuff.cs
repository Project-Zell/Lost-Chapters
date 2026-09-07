using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;

namespace LostChapters.Modules.Custom.Archetypes.Demonologist;

internal class DemonSummonRageBuff
{
    public static readonly string Guid = "{8e0bd389-2c81-454d-8168-4c678047649a}";

    private static readonly string BaseName = "DemonSummonRage";

    private static readonly string BuffName    = $"{BaseName}Buff";
    private static readonly string DisplayName = $"{BuffName}.Name";
    private static readonly string Description = $"{BuffName}.Description";

    internal static void Configure()
    {
        BuffConfigurator.New(BuffName, Guid)
            .AddFactsFromCaster(facts: [
                FeatureRefs.ProtectVitalsFeature.ToString(),
                FeatureRefs.ReflexiveDodgeFeature.ToString(),
                FeatureRefs.DeadlyAccuracyFeature.ToString(),
                FeatureRefs.LethalAccuracyFeature.ToString(),
                FeatureRefs.AnimalFuryFeature.ToString(),
                FeatureRefs.BeastTotemFeature.ToString(),
                FeatureRefs.BeastTotemGreaterFeature.ToString(),
                FeatureRefs.BeastTotemLesserFeature.ToString(),
                FeatureRefs.FearlessRageFeature.ToString(),
                FeatureRefs.IncreasedDamageReductionFeature.ToString(),
                FeatureRefs.InternalFortitudeFeature.ToString(),
                FeatureRefs.RenewedVigorFeature.ToString(),
                FeatureRefs.SwiftFootFeature.ToString(),
                FeatureRefs.SkaldDR.ToString(),
                FeatureRefs.ScentFeature.ToString(),
                FeatureRefs.CelestialTotemFeature.ToString(),
                FeatureRefs.CelestialTotemGreaterFeature.ToString(),
                FeatureRefs.CelestialTotemLesserFeature.ToString(),
                FeatureRefs.DaemonTotemFeature.ToString(),
                FeatureRefs.DaemonTotemGreaterFeature.ToString(),
                FeatureRefs.DaemonTotemLesserFeature.ToString(),
                FeatureRefs.FiendTotemFeature.ToString(),
                FeatureRefs.FiendTotemGreaterFeature.ToString(),
                FeatureRefs.FiendTotemLesserFeature.ToString(),
                FeatureRefs.RollingDodgeFeature.ToString(),
                FeatureRefs.CripplingBlowsFeature.ToString(),
                FeatureRefs.WreckingBlowsFeature.ToString(),
                FeatureRefs.RagingSongSneakAttack1d6Feature.ToString(),
                FeatureRefs.RagingSongSneakAttack2d6Feature.ToString(),
                FeatureRefs.RagingSongSneakAttack3d6Feature.ToString(),
                FeatureRefs.ClearMindFeature.ToString(),
                FeatureRefs.ComeAndGetMeFeature.ToString()])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();
    }
}