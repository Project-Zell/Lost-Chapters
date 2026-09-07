using UnityEngine;
using Color = UnityEngine.Color;

namespace LostChapters.Tools;

internal static class UnityHelper
{
    public static Color HexColor(string hexValue, float alpha = 1f)
    {
        if (ColorUtility.TryParseHtmlString($"#{hexValue}", out Color result))
        {
            result.a = alpha;
            return result;
        }
        return Color.white;
    }
}
