using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInventory : MonoBehaviour
{
    string[] items;
    string[] item_inventory;

    public Text Inventroy;
    private string gold;
    public int g = 0; // 총 골드 개수
    public int r = 0; // 총 루비 개수
    public int s = 0; // 총 사파이어 개수
    public int m = 0; // 총 마력석 개수
    void Start()
    {
                     
        
    }


    void Update()
    {
        UpgradeUI upgradeUI = GetComponent<UpgradeUI>();
        item_inventory[upgradeUI.upgrade] = upgradeUI.materials[upgradeUI.upgrade];
        items[0] = item_inventory[0];
        gold = items[0].Split(' ')[0];
        
        





        Inventroy.text = $"인벤토리\n{item_inventory[0]} : {g}\n{item_inventory[1]} : {r}\n{item_inventory[2]} : {s}\n{item_inventory[3]} : {m}";
    }
}
