using UnityEngine;

// ������ ��� ���¿��� Update, OnEnable, OnDisable�� ������ ������ �� �ֽ��ϴ�.
// Play�� ������ �ʾƵ� Editor ������ Update � ������ ��ɵ��� �����غ� �� �ֽ��ϴ�.
// [ExecuteInEditMode]
public class EditModeSample : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // �����Ϳ����� �����غ��� �ڵ�
        if (!Application.isPlaying) 
        {
            Vector3 pos = transform.position;
            pos.y = 0;
            transform.position = pos;
            Debug.Log("Editor Test...(�� ��ũ��Ʈ�� �� ������Ʈ�� Y���� 0���� �����˴ϴ�.)");
        }
    }
}
