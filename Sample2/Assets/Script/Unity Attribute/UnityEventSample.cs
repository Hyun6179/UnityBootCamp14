using UnityEngine;
using UnityEngine.Events;

public class UnityEventSample : MonoBehaviour
{

    [Tooltip("�̺�Ʈ ����Ʈ�� �߰��ϰ�, ������ ����� ���� ���� ������Ʈ�� ����ϼ���.")]
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
