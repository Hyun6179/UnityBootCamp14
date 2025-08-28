using UnityEngine;

public enum ItemType
{
    Tool, Material
}

[CreateAssetMenu(fileName ="NewItem", menuName ="Item/Basic Item")]
public class ItemDataSO : ScriptableObject
{
    public Sprite icon;
    public string itemID;
    public string itemName;
    public int maxStack;
    public bool isEquipable;
    public ItemType type;
}

