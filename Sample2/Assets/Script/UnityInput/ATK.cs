using UnityEngine;
using UnityEngine.UI;

public class ATK : MonoBehaviour
{
    public Text atk;
    Enchant enchant;

    private void Start()
    {
        enchant = GetComponent<Enchant>();
    }

    private void Update()
    {
        atk.text = $"���ݷ� : {50 + enchant.level * 5}";
    }
}
