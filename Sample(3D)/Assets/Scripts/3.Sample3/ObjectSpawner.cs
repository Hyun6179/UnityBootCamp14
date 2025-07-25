using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject objectPrefab;

    float spawnTime = 2.0f;
    float time = 0.0f;

    // 시간을 따로 계산해서, 변수로 저장하고
    // 그 변수가 스폰 타임보다 커지면 오브젝트 생성
    // 변수를 0으로 초기화


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > spawnTime)
        {
            GameObject go = Instantiate(objectPrefab);
            time = 0.0f;

            int rand = Random.Range(-5, 6);
            //-5부터 6 사이의 값을 랜덤으로 가지게 됩니다
            go.transform.position = new Vector3(rand, 5, 0);
        }

        
    }
}
