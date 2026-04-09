using BlueprintCore.Utils;
using Kingmaker.Visual.Trails;
using Owlcat.Runtime.Core.Utils;
using UnityEngine;

namespace LostChapters.Patches;

internal class DollroomParticleSystemPatch : MonoBehaviour
{
    private void Start()
    {
        if (gameObject.IsLayerMask(Layers.DollRoomMask) is false)
            return;

        var renderers = GetComponentsInChildren<ParticleSystemRenderer>();
        foreach(var renderer in renderers )
            renderer.material.SetFloat("_UseUnscaledTime", 1f);
    }
}
