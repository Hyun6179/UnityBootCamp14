using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventorySlotData
{
    public string itemID;  // 슬롯에 들어있는 아이템 ID
    public int count;      // 슬롯에 들어있는 수량
}

[System.Serializable]
public class PlayerInventoryData
{
    public InventorySlotData[] slots;  // 모든 슬롯 정보
}

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("슬롯 배열")]
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

        Debug.Log("인벤토리가 가득 찼습니다.");
        return false;
    }

    public bool RemoveItem(ItemDataSO item, int amount = 1)
    {
        // 1. 해당 아이템 슬롯 찾기
        foreach (var slot in slots)
        {
            if (slot.item != null && slot.item.itemID == item.itemID)
            {
                // 2. 슬롯 내 수량 감소
                slot.count -= amount;

                // 3. 수량이 0 이하이면 슬롯 비우기
                if (slot.count <= 0)
                {
                    slot.ClearSlot();
                }
                else
                {
                    slot.UpdateCountUI(); // UI 갱신
                }

                return true; // 제거 완료
            }
        }

        Debug.LogWarning($"인벤토리에서 '{item.name}' 아이템을 찾을 수 없습니다.");
        return false; // 제거 실패
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