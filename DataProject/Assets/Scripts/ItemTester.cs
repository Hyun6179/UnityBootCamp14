using UnityEngine;

public class ItemTester : MonoBehaviour
{
    public SOMaker somaker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(somaker.description);
    }

    public void LevelUp()
    {
        somaker.level++;
        Debug.Log("레벨이 증가했습니다.");
    }
}
