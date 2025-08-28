using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlotData
{
    public string itemID;  // ���Կ� ����ִ� ������ ID
    public int count;      // ���Կ� ����ִ� ����
}

[System.Serializable]
public class PlayerInventoryData
{
    public InventorySlotData[] slots;  // ��� ���� ����
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("���� �迭")]
    public InventorySlot[] slots;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public bool AddItem(ItemDataSO item, int amount = 1)
    {
       
        foreach (var slot in slots)
        {
            if (slot.item != null && slot.item.itemID == item.itemID)
            {
                slot.AddCount(amount);
                return true;
            }
        }

        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.SetItem(item, amount);
                return true;
            }
        }

        Debug.Log("�κ��丮�� ���� á���ϴ�.");
        return false;
    }

    public bool RemoveItem(ItemDataSO item, int amount = 1)
    {
        // 1. �ش� ������ ���� ã��
        foreach (var slot in slots)
        {
            if (slot.item != null && slot.item.itemID == item.itemID)
            {
                // 2. ���� �� ���� ����
                slot.count -= amount;

                // 3. ������ 0 �����̸� ���� ����
                if (slot.count <= 0)
                {
                    slot.ClearSlot();
                }
                else
                {
                    slot.UpdateCountUI(); // UI ����
                }

                return true; // ���� �Ϸ�
            }
        }

        Debug.LogWarning($"�κ��丮���� '{item.name}' �������� ã�� �� �����ϴ�.");
        return false; // ���� ����
    }


    public void ClearInventory()
    {
        foreach (var slot in slots)
        {
            slot.ClearSlot();
        }
    }

    public List<InventoryItem> GetCurrentInventory()
    {
        List<InventoryItem> inventory = new List<InventoryItem>();

        foreach (var slot in slots)
        {
            if (slot.item != null)
            {
                inventory.Add(new InventoryItem
                {
                    itemID = slot.item.itemID,
                    count = slot.count
                });
            }
        }

        return inventory;
    }
}