using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public float speed = 1.0f; // 몬스터의 속도

    public GameObject Score;

    private EnemyPool enemy_Pool;
    private Transform player_pos; // 플레이어 위치 추적



    private void Start()
    {
        player_pos = GameObject.FindGameObjectWithTag("Player")?.transform;
        Score = GameObject.FindWithTag("Score");

        if (player_pos == null)
        {
            Debug.LogWarning("플레이어를 찾을 수 없습니다.");
        }
        else
        {
            StartCoroutine(Move());
        }
    }

    //private void Update()
    //{
    //    float distance = Vector3.Distance(transform.position, player_pos.position);
    //    if (distance < 1.0f)
    //    {
    //        gameObject.SetActive(false);
    //        Score sc = GetComponent<Score>();
    //        sc.hp--;
    //    }
    //}

    //public void SetEnemyPool(EnemyPool pool)
    //{
    //    this.enemy_Pool = pool;
    //}

    IEnumerator Move()
    {
        while (player_pos != null)
        {
            transform.LookAt(player_pos.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player_pos.position, speed * Time.deltaTime);
            yield return null;

            float distance = Vector3.Distance(transform.position, player_pos.position);
            if (distance < 1.0f)
            {
                gameObject.SetActive(false);
                Score sc = GetComponent<Score>();
                sc.hp--;
            }
        }
    }
}
