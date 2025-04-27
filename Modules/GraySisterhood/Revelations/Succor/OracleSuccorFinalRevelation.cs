using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.Blueprints.Classes.Spells;

namespace LostChapters.Revelations
{
    internal class OracleSuccorFinalRevelation
    {
        public static readonly string Guid = "{3f1e5f5d-f5b3-4cff-ae77-971fbbe4bdfd}";

        private static readonly string FeatureName = "OracleSuccorFinalRevelation";
        private static readonly string DisplayName = "OracleSuccorFinalRevelation.Name";
        private static readonly string Description = "OracleSuccorFinalRevelation.Description";

        internal static void Configure()
        {
            FeatureConfigurator.New(FeatureName, Guid)
                .AddAutoMetamagic(
                    allowedAbilities: AutoMetamagic.AllowedType.SpellOnly, 
                    metamagic: Metamagic.Reach | Metamagic.Maximize,
                    descriptor: SpellDescriptor.Cure | SpellDescriptor.RestoreHP | SpellDescriptor.TemporaryHP)
                .SetIsClassFeature(true)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .Configure();
        }
    }
}
