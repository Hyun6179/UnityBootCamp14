using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // ���� ������
    public Transform spawnPoint; // ��ȯ���
    public float interval = 2.0f; // ��ȯ ����

    public EnemyPool pool; // ���� �����

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            var enemy = pool.GetEnemy();
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
            enemy.SetActive(true);
            Debug.Log($"{enemyPrefab.name}�� ������ϴ�.");

            yield return new WaitForSeconds(interval);

        }
    }
}
