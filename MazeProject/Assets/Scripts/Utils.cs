using UnityEngine;

public class Utils
{
    public static Color GetColor(string hexCode)
    {
        Color color;
        if (ColorUtility.TryParseHtmlString(hexCode, out color))
        {
            return color;
        }
        else
        {
            Debug.LogWarning($"잘못된 컬러 코드: {hexCode}");
            return Color.white; 
        }
    }
}
