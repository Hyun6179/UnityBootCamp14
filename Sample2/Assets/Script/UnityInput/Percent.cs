using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Percent : MonoBehaviour
{
    public Text percent;
    Enchant enchant;

    private void Start()
    {
        enchant = GetComponent<Enchant>();
    }

    private void Update()
    {
        percent.text = $"���� ���� Ȯ�� : {10 - enchant.level}0%";
    }
}
