using UnityEngine;

public class ItemGathering : MonoBehaviour
{
    public DropTableSO[] dropTables;
    public GameObject itemDropPrefab;

    public void Interact(string actionName)
    {
        DropTableSO table = System.Array.Find(dropTables, t => t.actionName == actionName);
        if (table == null) return;

        foreach (var drop in table.drops)
        {
            if (Random.value <= drop.dropRate / 100f)
            {
                int amount = Random.Range(drop.minAmount, drop.maxAmount + 1);

                // ���� ��ġ ���
                Vector3 spawnPos = transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));

                // ������ ��� ������ ����
                GameObject dropObj = Instantiate(itemDropPrefab, spawnPos, Quaternion.identity);
                ItemDrop itemDrop = dropObj.GetComponent<ItemDrop>();
                itemDrop.SetItem(drop.item, amount);
                Debug.Log($"Dropped {amount} x {drop.item.itemName}");

            }
        }
    }    
}

