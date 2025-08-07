using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button button01;
    public Text message;
    public Text icon_text;

    // �迭�� �� ���� ���� ä�� �����˴ϴ�.
    // �ڷ���[] �迭�� = new �ڷ���[] {
    // ��1, ��2, ��3
    // };
    public string[] materials = new string[]
    {
        "��� 100",
        "��� 100+���",
        "��� 200+�����̾�+���¼�",
        "�ִ� ��ȭ �Ϸ�"
    };

    // max_level�� ����� ��� �迭�� ���� -1�� ���� ������ �˴ϴ�.

    [HideInInspector]
    public int upgrade = 0;
    [HideInInspector]
    public int max_level => materials.Length -1;
    // �迭���� Index��� ������ �����մϴ�.
    // ex) materials�� �ϳ��� �����̰�, �ű⼭ 2��° �����ʹ� materials[1]�Դϴ�.
    //     ī��Ʈ�� 0���� ����.

    private void Start()
    {
        button01.onClick.AddListener(OnUpgradeBtnClick);
        // AddListener�� ����Ƽ�� UI�� �̺�Ʈ�� ����� �������ִ� �ڵ�
        // ������ �� �ִ� ���� ���°� �������־ �� ���´�� ���� ����� �մϴ�.
        // �ٸ� ���·� ���� ���(�Ű������� �ٸ� ���)��� delegate�� Ȱ���մϴ�.
        // Ư¡) �� ����� ���� �̺�Ʈ�� ����� �����Ѵٸ�
        // ����Ƽ �ν����Ϳ��� ����� �� Ȯ�� �� �� �����ϴ�.

        // ���� : ���� ������� �ʾƼ� �߸� ���� Ȯ���� �������ϴ�.
        UpdateUI();
        // ���� �� UI�� ���� ������ ����


    }
    // ��ư Ŭ�� �� ȣ���� �޼ҵ� ����
    private void OnUpgradeBtnClick()
    {
        if (upgrade < max_level)
        {
            UnitInventory iv = GetComponent<UnitInventory>();
            if (upgrade == 0)
            {
                if (iv.g < 100)
                {
                    Debug.Log("��ȭ�� �ʿ��� ��ȭ�� �����ϴ�");
                }
                else
                {
                    upgrade++;
                    UpdateUI();
                    iv.g -= 100;
                }
            }
            else if (upgrade == 1)
            {
                if (iv.g < 100 || iv.r < 1)
                {
                    Debug.Log("��ȭ�� �ʿ��� ��ȭ�� �����ϴ�");
                }
                else
                {
                    upgrade++;
                    UpdateUI();
                    iv.g -= 100;
                    iv.r -= 1;
                }
            }
            else if (upgrade == 2)
            {
                if (iv.g < 200 || iv.s < 1 || iv.m < 1)
                {
                    Debug.Log("��ȭ�� �ʿ��� ��ȭ�� �����ϴ�");
                }
                else
                {
                    upgrade++;
                    UpdateUI();
                    iv.g -= 200;
                    iv.s -= 1;
                    iv.m -= 1;
                }
            }
        }
    }

    private void UpdateUI()
    {
        icon_text.text = $"Wizard + {upgrade}";
        
        message.text = materials[upgrade].ToString();
        
        UnitStat stat = GetComponent<UnitStat>();
        stat.Upgrade();
    }
}
