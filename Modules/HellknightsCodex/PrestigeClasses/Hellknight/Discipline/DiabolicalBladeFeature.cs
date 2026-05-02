using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Items.Ecnchantments;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Utils.Assets;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.EquipmentEnchants;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UI.GenericSlot;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.Utility;
using Kingmaker.Visual.Animation.Kingmaker.Actions;
using Kingmaker.Visual.Particles;
using LostChapters.Modules.Custom.Items.Weapons.Exotic;
using LostChapters.Modules.HellknightCodex.PrestigeClasses.Hellknight;
using LostChapters.Tools;
using UnityEngine;

namespace LostChapters.Modules.HellknightsCodex.PrestigeClasses.Hellknight.Discipline;

internal class DiabolicalBladeFeature
{
    public static readonly string Guid = "{4227449c-70da-47f6-b45a-6cc5f1699ce4}";

    private static readonly string FeatureName = "DiabolicalBladeFeature";
    private static readonly string DisplayName = $"{FeatureName}.Name";
    private static readonly string Description = $"{FeatureName}.Description";

    internal static void Configure()
    {
        Ability.Configure();
        //Bloodboiler Item
        //Hit dice is equal to character level?

        FeatureConfigurator.New(FeatureName, Guid)
            .AddToFeatureSelection(HellknightDisciplineSelection.Guid)
            .AddFacts([Ability.Guid])
            .SetDisplayName(DisplayName)
            .SetDescription(Description)
            .Configure();

    }

    internal class Ability
    {
        public static readonly string Guid = "{394b176c-1617-4383-9ea4-5fdbddeda58f}";

        private static readonly string AbilityName = $"{FeatureName}.Ability";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            Buff.Configure();

            var contextDuration = ContextDuration.Fixed(value: 1, rate: DurationRate.Minutes, isExtendable: false);

            var action = ActionsBuilder.New().ApplyBuff(buff: Buff.Guid, durationValue: contextDuration, isNotDispelable: true, toCaster: true);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddAbilityCasterNotPolymorphed()
                .SetType(AbilityType.Special)
                .SetRange(AbilityRange.Personal)
                .AllowTargeting(self: true)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class Buff
    {
        public static readonly string Guid = "{ea9272c5-c7e4-4a06-8abe-736df557ad20}";

        private static readonly string BuffName = $"{FeatureName}.Buff";
        private static readonly string DisplayName = $"{BuffName}.Name";
        private static readonly string Description = $"{BuffName}.Description";

        internal static void Configure()
        {
            Enchantment.Configure();

            BuffConfigurator.New(BuffName, Guid)
                .AddBuffEnchantAnyWeapon(Enchantment.Guid, EquipSlotBase.SlotType.PrimaryHand)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }

    internal class Enchantment
    {
        public static readonly string Guid = "{0358ab5d-2896-45de-8147-6e44b5fe265e}";

        private static readonly string EnchantmentName = $"{FeatureName}.Enchantment";
        private static readonly string DisplayName = $"{EnchantmentName}.Name";
        private static readonly string Description = $"{EnchantmentName}.Description";

        internal static void Configure()
        {
            var sourceFx = "91e5a56dd421a2941984a36a2af164b6";
            var newFx = "{a84af1b7-9103-499f-a0b8-76a625de68e2}";

            AssetTool.RegisterDynamicPrefabLink(assetId: newFx, source: sourceFx, ModifyFx);

            static void ModifyFx(GameObject gameObject)
            {
                var transform = gameObject.transform;
                var alpha = new GradientAlphaKey[] { new(1, 0), new(1, 1) };

                var flame = transform.Find("BigFlames").gameObject;
                var flameColors = new GradientColorKey[]
                {
                    new(new(0.000f, 0.059f, 0.224f), 0.2621042f),
                    new(new(0.176f, 0.518f, 0.820f), 0.5584039f),
                    new(new(0.616f, 0.820f, 1.000f), 0.7834745f),
                    new(new(0.333f, 0.651f, 0.925f), 0.8831922f),
                    new(new(0.718f, 0.867f, 1.000f), 1.0000000f),
                };
                ChangeColorAlphaRamp(flameColors, alpha, flame);

                var flamesUp = transform.Find("FlamesUp+OverDistance").gameObject;
                ChangeColorAlphaRamp(flameColors, alpha, flamesUp);

                var fill = transform.Find("FillFlames").gameObject;
                var fillColors = new GradientColorKey[]
                {
                    new(new(0.224f, 0.322f, 0.608f), 0.2621042f),
                    new(new(0.176f, 0.518f, 0.820f), 0.5584039f),
                    new(new(0.616f, 0.820f, 1.000f), 0.7834745f),
                    new(new(0.333f, 0.651f, 0.925f), 0.8831922f),
                    new(new(0.718f, 0.867f, 1.000f), 1.0000000f),
                };
                ChangeColorAlphaRamp(fillColors, alpha, fill);

                var sparks = transform.Find("Sparks").gameObject;
                var sparksColors = new GradientColorKey[]
                {
                    new(new(0.043f, 0.741f, 1.000f), 0.002944991f),
                    new(new(1.000f, 1.000f, 1.000f), 0.6147097f),
                };
                ChangeColorAlphaRamp(sparksColors, alpha, sparks);
                var system = sparks.GetComponent<ParticleSystem>();
                var sparkParticleColor = new GradientColorKey[]
                {
                    new(new(0.208f, 0.635f, 1.000f), 0f),
                    new(new(0.035f, 0.286f, 0.502f), 1f)
                };
                var sparkParticleAlpha = new GradientAlphaKey[]
                {
                    new(1f, 0.3161212f),
                    new(1f, 0.6735485f),
                    new(0f, 1f)
                };
                var sparkGradient = new UnityEngine.Gradient();
                sparkGradient.SetKeys(sparkParticleColor, sparkParticleAlpha);
                var max = sparks.GetComponent<ParticleSystem>().colorOverLifetime;
                max.color = sparkGradient;

                var trail = transform.Find("DropsWithTrail (1)").gameObject;
                var trailAlpha = new GradientAlphaKey[]
                {
                    new(0.9843137f, 0.1155718f),
                    new(1f, 1f)
                };
                var trailGradient = new UnityEngine.Gradient();
                trailGradient.SetKeys(sparkParticleColor, trailAlpha);
                var trailLifeTime = trail.GetComponent<ParticleSystem>().colorOverLifetime;
                trailLifeTime.color = trailGradient;

                var fire = transform.Find("DropsWithTrail (1)/FireTiny").gameObject;
                var fireColors = new GradientColorKey[]
                {
                    new(new(0.718f, 0.867f, 1.000f), 0.0000000f),
                    new(new(0.616f, 0.820f, 1.000f), 0.1823606f),
                    new(new(0.176f, 0.518f, 0.820f), 0.4764782f),
                    new(new(0.616f, 0.820f, 1.000f), 1.0000000f),
                };
                ChangeColorAlphaRamp(fireColors, alpha, fire);

                var puddle = transform.Find("DropsWithTrail (1)/PuddleTiny").gameObject;
                var puddleColors = new GradientColorKey[]
                {
                    new(new(0.224f, 0.322f, 0.608f), 0f),
                    new(new(0.035f, 0.286f, 0.502f), 1f)
                };
                var puddleAlpha = new GradientAlphaKey[]
{
                    new(0.9843137f, 0.4720379f),
                    new(1f, 1f)
};
                var puddleGradient = new UnityEngine.Gradient();
                puddleGradient.SetKeys(puddleColors, puddleAlpha);
                var puddleLifeTime = puddle.GetComponent<ParticleSystem>().colorOverLifetime;
                puddleLifeTime.color = puddleGradient;

                Toolbox.ChangeMaterialColor(puddle, Color.white);
            }

            static void ChangeColorAlphaRamp(GradientColorKey[] colors, GradientAlphaKey[] alpha, GameObject gameObject)
            {
                var main = gameObject.GetComponent<ParticleSystem>().main;
                main.startColor = Color.white;

                var controller = gameObject.GetComponent<ParticlesMaterialController>();
                controller.TexColorAlphaRamp = null;
                controller.ColorAlphaRamp.SetKeys(colors, alpha);
                controller.ApplySettings();
                controller.UpdateColorRamp(ColorRampType.Particles, false);
            }

            var action = ActionsBuilder.New().CastSpell(AbilityAction.Guid).MarkForceDismemberOwner();

            WeaponEnchantmentConfigurator.New(EnchantmentName, Guid)
                .AddInitiatorAttackWithWeaponTrigger(reduceHPToZero: true, action: action)
                .AddWeaponEnergyDamageDice(element: DamageEnergyType.Cold, energyDamageDice: new DiceFormula(rollsCount: 2, diceType: DiceType.D6))
                .AddIgnoreResistanceForDamageFromEnchantment(type: IgnoreResistanceForDamageFromEnchantment.IgnoreType.ReductionAndImmunities)
                .SetWeaponFxPrefab(newFx)
                .SetEnchantName(DisplayName)
                .SetDescription(Description)
                .Configure();

            CrimsonDancerItem.Configure();
        }
    }

    internal class AbilityAction
    {
        public static readonly string Guid = "{46e3843b-7c6e-4430-a351-350cca1b3e64}";

        private static readonly string AbilityName = $"{FeatureName}.AbilityAction";
        private static readonly string DisplayName = $"{AbilityName}.Name";
        private static readonly string Description = $"{AbilityName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
            var diceValue = new ContextDiceValue()
            {
                DiceType = DiceType.D6,
                DiceCountValue = 2,
                BonusValue = 0,
            };

            var action = ActionsBuilder.New().DealDamage(
                damageType: new DamageTypeDescription()
                {
                    Type = DamageType.Energy,
                    Energy = DamageEnergyType.Fire, 
                },
                value: diceValue,
                isAoE: true, 
                ignoreCritical: true);

            AbilityConfigurator.New(AbilityName, Guid)
                .AddAbilityEffectRunAction(action)
                .AddAbilityTargetsAround(radius: 20.Feet(), targetType: TargetType.Enemy, spreadSpeed: 20.Feet())
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                //.AddFeatureTagsComponent()
                //.SetIcon(Icon)
                .Configure();
        }
    }
}
