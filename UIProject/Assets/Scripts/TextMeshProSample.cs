using UnityEngine;
using TMPro;

public class TextMeshProSample : MonoBehaviour
{
    //TMP (Text Mesh Pro)�� ����ϴ� UI ������Ʈ
    public TextMeshProUGUI textUI;

    private void Start()
    {
        //��ġ �ؽ�Ʈ(HTML �±� ���� ����) ����
        textUI.text = "<size=150%>�ȳ��ϼ���</size> <s>�� �� ���</s>";
    }

    public void SetText(bool warn)
    {
        if (warn)
        {
            textUI.text = "<color=red><b>WARNING!!!</b><color>";
        }
        else
        {
            textUI.text = "<color=green>NORMAL</color>";
        }
    }
}
