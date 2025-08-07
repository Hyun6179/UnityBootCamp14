using UnityEngine;
using UnityEngine.UI;

public class UnitStat : MonoBehaviour
{
    public Text stat;
    private int hp = 10;
    private int mp = 50;
    private int intelligence = 15;

    private void Start()
    {
        stat.text = $"HP : {hp}\nMP : {mp}\nINT : {intelligence}";
    }
    [HideInInspector]
    public void Upgrade()
    {
        UpgradeUI ui = GetComponent<UpgradeUI>();
        if (ui.upgrade <= ui.max_level)
        {
            mp += 10;
            hp += 10;
            intelligence += 5;
            stat.text = $"HP : {hp}\nMP : {mp}\nINT : {intelligence}";
        }
    }
}
