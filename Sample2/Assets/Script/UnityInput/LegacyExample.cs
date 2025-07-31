using UnityEngine;
using UnityEngine.UI;

public class LegacyExample : MonoBehaviour
{
    public Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text = GetComponentInChildren<Text>(); 
        
        // GetComponentInChildren<T>
        // �� ������Ʈ�� �ڽ����κ��� ������Ʈ�� ������ ���
    }

    // Update is called once per frame
    void Update()
    {
        #region 
        /*if (Input.GetKeyDown(KeyCode.Space)) // spacebar
        {
            text.text = "pata";
        }
        if (Input.GetKeyDown(KeyCode.Return)) // enter
        {
            text.text = "pong";

        }
        if (Input.GetKeyDown(KeyCode.Escape)) // esc
        {
            text.text = "";
        }*/
        #endregion

        // �迭�� ���� �������� �����Ǵ� �����͸� ���������� �����ϴ� �ڵ�
        // foreach(������ ������ in ����)
        // {
        //
        // }

        // KeyCode ������ ������ ��ü�� �����մϴ�.
        foreach(KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(key))
            {
                switch (key)
                {
                    case KeyCode.Escape:
                        text.text = "";
                        break;
                    case KeyCode.Space:
                        text.text = "pata";
                        break;
                    case KeyCode.Return:
                        text.text = "pong";
                        break;
                }
            }
        }

    }
}
