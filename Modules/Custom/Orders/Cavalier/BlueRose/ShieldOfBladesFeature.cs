using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;

namespace LostChapters.Modules.Custom.Orders.Cavalier.BlueRose
{
    internal class ShieldOfBladesFeature
    {
        public static readonly string Guid = "{0a3a4d5b-eca6-4bd0-9111-1de11692234e}";

        private static readonly string FeatureName = "ShieldOfBlades";
        private static readonly string DisplayName = "ShieldOfBlades.Name";
        private static readonly string Description = "ShieldOfBlades.Description";

        public static void Configure()
        {
            Buff.Configure();

            FeatureConfigurator.New(FeatureName, Guid)
                .AddBuffExtraEffects(
                    checkedBuff: BuffRefs.FightDefensivelyBuff.ToString(),
                    extraEffectBuff: Buff.Guid)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .Configure();
        }

        internal class Buff
        {
            public static readonly string Guid = "{3820e7d8-5b51-4dce-bfb6-01b36791d030}";

            private static readonly string BuffName = "ShieldOfBlades.ArmorClassBuff";

            public static void Configure()
            {
                BuffConfigurator.New(BuffName, Guid)
                    .AddStatBonus(descriptor: ModifierDescriptor.Dodge, stat: StatType.AC, value: 2)
                    .SetDisplayName(DisplayName)
                    .Configure();
            }
        }
    }
}
