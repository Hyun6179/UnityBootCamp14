using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInventory : MonoBehaviour
{
    string[] items;
    string[] item_inventory;
    string ruby;
    string Sapphiye;
    string Magic;
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
        gold = upgradeUI.materials[0].Split(' ')[0];
        ruby = upgradeUI.materials[1].Split('+')[1];
        Sapphiye = upgradeUI.materials[2].Split('+')[1];
        Magic = upgradeUI.materials[2].Split('+')[2];


        Inventroy.text = $"인벤토리\n{gold} : {g}\n{ruby} : {r}\n{Sapphiye} : {s}\n{Magic} : {m}";
    }
}
