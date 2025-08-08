using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DTrigger : MonoBehaviour
{
    public List<Dialog> scripts; // IEnumerable은 열거형 모음이기 때문에 List 사용 가능

    public void OnDTriggerEnter()
    {
        if(scripts != null && scripts.Count > 0)
        {
            DialogManager.Instance.StartLine(scripts);
            // 클래스명.Instance.메소드명()과 같이 클래스의 값을 바로 사용할 수 있습니다.
            // 따로 값을 GetComponent나 public등으로 등록해서 사용할 필요가 없어 편합니다.
        }
    }
}
