using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI countText;

    [HideInInspector] public ItemDataSO item;
    [HideInInspector] public int count;

    public void SetItem(ItemDataSO newItem, int amount = 1)
    {
        item = newItem;
        count = amount;
        icon.sprite = newItem.icon;
        icon.enabled = true;

        UpdateCountUI();
    }

    public void AddCount(int amount)
    {
        count += amount;
        UpdateCountUI();
    }
    public void ClearSlot()
    {
        item = null;
        count = 0;
        icon.sprite = null;
        icon.enabled = false;
        countText.text = "";
    }


    public void UpdateCountUI()
    {
        countText.text = count > 1 ? "x" + count : "";
    }
}
