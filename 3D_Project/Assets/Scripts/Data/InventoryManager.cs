using UnityEngine;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System;
using UnityEditor.VersionControl;

public class InventoryManager : MonoBehaviour
{
    public Text GatheringItem;
    public static InventoryManager Instance;
    public List<InventoryItem> inventory = new List<InventoryItem>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void AddItem(string itemID, int amount)
    {
        InventoryItem existing = inventory.Find(i => i.itemID == itemID);
        if (existing != null) existing.count += amount;
        else inventory.Add(new InventoryItem() { itemID = itemID, count = amount });

        Debug.Log($"{itemID} {amount}�� ȹ��!");
        GatheringItem.text = $"{itemID} {amount}�� ȹ��!";

        //������ ȹ�� �� �ڵ�����
        SaveLoadManager.Instance?.SaveData(GetCurrentData());
    }

    public void ToggleEquip(string itemID)
    {
        InventoryItem item = inventory.Find(i => i.itemID == itemID);
        if (item == null)
        {
            Debug.LogWarning("�ش� ������ ����");
            return;
        }

        ItemDataSO so = ItemDatabase.Instance.GetItemByID(itemID);
        if (so == null || !so.isEquipable)
        {
            Debug.LogWarning("���� �Ұ� ������");
            return;
        }

        // ���� Ÿ�� ������ �ϳ��� ����
        foreach (var inv in inventory)
        {
            ItemDataSO invSO = ItemDatabase.Instance.GetItemByID(inv.itemID);
            if (invSO != null && invSO.type == so.type && inv.equipped)
                inv.equipped = false;
        }

        // ������ ������ ���
        item.equipped = true;

        Debug.Log($"{so.itemName} ���� �Ϸ�");

        // ���� ���� ����
        SaveLoadManager.Instance?.SaveData(GetCurrentData());
    }


    public PlayerDataList GetCurrentData()
    {
        return new PlayerDataList()
        {
            playerData = new PlayerData() { nickname = "Player", gold = 0, position = Vector3.zero},
            inventory = inventory,
            worldState = new World_state() { time = "12:00", weather = "sun", season = "spring" }
        };
    }
}