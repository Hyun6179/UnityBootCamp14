using System;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public Text name;
    Enchant enchant;
    // ��ȭ ��ġ�� ��ȭ Ȯ������ ȣ��
    // ��ȭ ��ġ�� level�̶�� �̸����� ȣ�� -> �̸� {level}��
    private void Start()
    {
       enchant = GetComponent<Enchant>();
    }

    private void Update()
    {
        name.text = $"���� ������ {enchant.level}��";
    }


}
