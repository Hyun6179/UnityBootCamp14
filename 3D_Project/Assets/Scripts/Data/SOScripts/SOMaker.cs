using UnityEngine;
using System.Collections.Generic;

public enum ItemType
{
    Tool, Material
}

[CreateAssetMenu(fileName ="NewItem", menuName ="Item/Basic Item")]
public class ItemDataSO : ScriptableObject
{
    public string itemID;
    public string itemName;
    public int maxStack;
    public bool isEquipable;
    public ItemType type;
}

public class ItemDatabase : MonoBehaviour
{
    public static ItemDatabase Instance;
    public ItemDataSO[] items;


    private void Awake()
    {
        if(Instance == null) Instance = this;
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
