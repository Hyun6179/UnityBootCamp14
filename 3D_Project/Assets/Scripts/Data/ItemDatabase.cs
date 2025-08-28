using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;
    public ItemDataSO[] items;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public ItemDataSO GetItemByID(string id)
    {
        foreach (var item in items)
        {
            if (item.itemID == id)
                return item;
        }
        return null;
    }
}
