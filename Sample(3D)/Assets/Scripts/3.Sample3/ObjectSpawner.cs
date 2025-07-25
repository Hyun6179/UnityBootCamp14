using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;

    float spawnTime = 2.0f;
    float time = 0.0f;

    // �ð��� ���� ����ؼ�, ������ �����ϰ�
    // �� ������ ���� Ÿ�Ӻ��� Ŀ���� ������Ʈ ����
    // ������ 0���� �ʱ�ȭ


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > spawnTime)
        {
            GameObject go = Instantiate(objectPrefab);
            time = 0.0f;

            int rand = Random.Range(-5, 6);
            //-5���� 6 ������ ���� �������� ������ �˴ϴ�
            go.transform.position = new Vector3(rand, 5, 0);
        }

        
    }
}
