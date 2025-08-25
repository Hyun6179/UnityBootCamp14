using UnityEngine;

public class ItemGathering : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public DropTableSO[] dropTables;

    // 플레이어와 상호작용시 호출
    public void Interact(string actionName)
    {
        DropTableSO table = System.Array.Find(dropTables, t => t.actionName == actionName);
        if (table == null) return;

        foreach (var drop in table.drops)
        {
            if( Random.value <= drop.dropRate)
            {
                int amount = Random.Range(drop.minAmount, drop.maxAmount + 1);
                inventoryManager.AddItem(drop.item.itemID, amount);
            }
        }
    }    
}

