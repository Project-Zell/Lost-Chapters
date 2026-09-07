using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostChapters.Modules.Custom.Archetypes.FalseKnight
{
    internal class LastOfAKindFeature
    {
        public static readonly string Guid = "{6a5c7c8e-69b8-46b2-a4c9-e2143a3d9c7e}";

        private static readonly string BaseName = "LastOfAKind";

        private static readonly string FeatureName = $"{BaseName}Feature";
        private static readonly string DisplayName = $"{FeatureName}.Name";
        private static readonly string Description = $"{FeatureName}.Description";

        //private static readonly Sprite Icon = $"{_Module.IconPath}/ .png";

        internal static void Configure()
        {
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
