using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public float speed = 1.0f; // ������ �ӵ�

    private EnemyPool enemy_Pool;
    private Transform player_pos; // �÷��̾� ��ġ ����

    private void Start()
    {
        player_pos = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player_pos == null)
        {
            Debug.LogWarning("�÷��̾ ã�� �� �����ϴ�.");
        }
        else
        {
            StartCoroutine(Move());
        }
    }

    public void SetEnemyPool(EnemyPool pool)
    {
        this.enemy_Pool = pool;
    }

    IEnumerator Move()
    {
        while (player_pos != null)
        {
            transform.LookAt(player_pos.position);
            transform.position = Vector3.MoveTowards(transform.position, player_pos.position, speed * Time.deltaTime);
            yield return null;
        }
    }
}
