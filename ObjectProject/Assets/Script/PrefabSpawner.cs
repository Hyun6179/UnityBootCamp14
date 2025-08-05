using UnityEngine;
// 1. ������(Prefab)�� ���� ����Ѵ�.
// 2. ������ Object�� ���� ������ ���ο��� ������.
// 3. ���� �Ŀ� �ı��� ���� Delay �ð��� ������.

// �ش� ��ũ��Ʈ�� ���� ������Ʈ�� �����ϸ�, ������ �����ϰ� ���� �ð� ��
// �ı��ϵ��� ó���մϴ�.
// ����) �������� ����� �Ǿ����� �� �ش� �۾� ����, �ƴ� ��� ��� �޽����� �ȳ��մϴ�.

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefab;
    private GameObject spawned;
    public float delay = 3.0f;
    // Ŭ�������� �ʿ��� ���� , ��ü�� ������ �� ��� �迭�� ����.


     void Start()
    {
      if(prefab != null)
        {
            spawned = Instantiate(prefab);
            // �����ڵ� Instantiate()
            // 1. Instantiate(prefab); �ش� �������� ������ �°� ��ġ�� ȸ�� �� ���� �����ǰ� �����˴ϴ�.
            // 2. Instantiate(prefab, transform.position, Quaternion.identity);
            // --> �ش� �������� �����ϰ�, ��ġ�� ȸ�� ���� ������� ������Ʈ�� ��ġ�� ȸ�� ���� �����մϴ�.
            // 3. Instantiate(prefab, parent); // parent�� transform.position�� �޾ƿ�
            // ������Ʈ�� �����ϰ� �� ������Ʈ�� ������ ��ġ�� �ڽ����ν� ����մϴ�.
            // 4. Instantiate(prefab, position, quaternion, parent);

            spawned.name = "������ ������Ʈ";
            // ������ ������Ʈ�� �̸��� �����ϴ� �ڵ�

            //spawned.AddComponent<Rigidbody>();
            // ���� ������ ������Ʈ�� ������Ʈ�� �߰��մϴ�.

            Debug.Log(spawned.name + "�� �����Ǿ����ϴ�.");

            Destroy(spawned, delay); 
            // delay �ð� ���� ������Ʈ �ı�
        }
      else
        {
            Debug.LogWarning("��ϵ� Prefab�� ���� �����ϴ�.");
        }
    }
}
