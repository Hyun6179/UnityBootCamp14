using UnityEngine;

public class ItemGathering : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public DropTableSO[] dropTables;

    // �÷��̾�� ��ȣ�ۿ�� ȣ��
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

