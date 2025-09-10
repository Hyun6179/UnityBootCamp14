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
            Debug.LogWarning($"�߸��� �÷� �ڵ�: {hexCode}");
            return Color.white; 
        }
    }
}
