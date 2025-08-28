using UnityEngine;
// ¾À µå¶ø¿ë
public class ItemDrop : MonoBehaviour
{
    public ItemDataSO item;
    public int count = 1;
    public void SetItem(ItemDataSO newItem, int newCount)
    {
        item = newItem;
        count = newCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventoryManager.Instance.AddItem(item, count);
            Destroy(gameObject);
        }
    }
}
