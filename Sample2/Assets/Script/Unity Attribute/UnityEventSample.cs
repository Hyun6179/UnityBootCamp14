using UnityEngine;
using UnityEngine.Events;

public class UnityEventSample : MonoBehaviour
{

    [Tooltip("이벤트 리스트를 추가하고, 실행할 기능을 가진 게임 오브젝트를 등록하세요.")]
    public UnityEvent action;

    [ExecuteInEditMode]
    private void Update()
    {
        action.Invoke();
    }

    public void Move()
    {
        gameObject.transform.Translate(0, 1, 0);
    }
}
