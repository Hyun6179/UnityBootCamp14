using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // 몬스터 프리펩
    public Transform spawnPoint; // 소환장소
    public float interval = 5.0f; // 소환 간격

    public EnemyPool pool; // 몬스터 저장소

    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Spawn());
    }

    private void Update()
    {
        if (Player == null)
        {
            StopCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        while (true) 
        {
            var enemy = Instantiate(enemyPrefab);
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
            Debug.Log($"{enemyPrefab.name}이 깨어났습니다.");

            yield return new WaitForSeconds(interval);
        }
    }
}
