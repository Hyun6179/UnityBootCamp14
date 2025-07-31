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
        percent.text = $"다음 성공 확률 : {10 - enchant.level}0%";
    }
}
