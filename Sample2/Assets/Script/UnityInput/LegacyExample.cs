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
        // 현 오브젝트의 자식으로부터 컴포넌트를 얻어오는 기능
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

        // 배열과 같은 묶음으로 관리되는 데이터를 순차적으로 조사하는 코드
        // foreach(데이터 변수명 in 묶음)
        // {
        //
        // }

        // KeyCode 형태의 데이터 전체를 조사합니다.
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
