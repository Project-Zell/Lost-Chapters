using BlueprintCore.Blueprints.Configurators;
using BlueprintCore.Utils.Assets;
using Kingmaker.Blueprints;
using Kingmaker.ResourceLinks;

namespace LostChapters.Modules.HellknightsCodex.AnimalCompanions.Hellhound;

internal class HellhoundPortrait
{
    public static readonly string Guid = "{35aaf3ac-80f1-492a-86b9-a3d1c53f4d83}";

    private static readonly string PortraitName = "HellhoundPortrait";
    
    private static readonly string PetEyeImage = $"{PortraitName}.PetEyeImage";
    private static readonly string PortraitImage = $"{PortraitName}.PortraitImage";
    private static readonly string HalfLengthImage = $"{PortraitName}.HalfLengthImage";
    private static readonly string FullLengthImage = $"{PortraitName}.FullLengthImage";


    internal static void Configure()
    {
        var portraitData = new PortraitData()
        {
            m_PetEyeImage = ((AssetLink<SpriteLink>)PetEyeImage).Get(),
            m_PortraitImage = ((AssetLink<SpriteLink>)PortraitImage).Get(),
            m_HalfLengthImage = ((AssetLink<SpriteLink>)HalfLengthImage).Get(),
            m_FullLengthImage = ((AssetLink<SpriteLink>)FullLengthImage).Get(),
        };

        PortraitConfigurator.New(PortraitName, Guid)
            .SetData(portraitData)
            .Configure();
    }
}
