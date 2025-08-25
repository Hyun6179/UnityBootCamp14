using UnityEngine;

[System.Serializable]
public class DropItem
{
    public ItemDataSO item;
    [Range(0, 100)]
    public float dropRate;
    public int minAmount = 1;
    public int maxAmount = 3;
}



[CreateAssetMenu(fileName = "NewDropTable", menuName = "Drop/DropTable")]
public class DropTableSO : ScriptableObject
{
    public string actionName;
    public DropItem[] drops;
}