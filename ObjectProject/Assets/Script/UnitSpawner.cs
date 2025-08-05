using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitPrefab; // 유닛 프리펩
    public Transform spawnPoint; // 생성 위치
    public float interval = 5.0f; // 유닛 생성 간격

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            // 유닛을 생성합니다.
            // 생성 위치는 spawnPoint로 부터 받습니다.
            Instantiate(unitPrefab, spawnPoint.position, Quaternion.identity);

            // 생성 간격만큼 대기합니다.
            yield return new WaitForSeconds(interval);

            Debug.Log($"{spawnPoint.name}에서 {unitPrefab.name}이 생성 되었습니다.");
        }
    }
}
