using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    public float speed = 1.0f; // ������ �ӵ�

    private GameObject Score;
    private GameObject Player;

    private Transform player_pos; // �÷��̾� ��ġ ����



    private void Start()
    {
        player_pos = GameObject.FindGameObjectWithTag("Player")?.transform;
        Player = GameObject.FindGameObjectWithTag("Player");
        Score = GameObject.FindWithTag("Score");

        if (player_pos == null)
        {
            Debug.LogWarning("�÷��̾ ã�� �� �����ϴ�.");
        }
        else
        {
            StartCoroutine(Move());
        }
    }

    private void Update()
    {
        if (Player != null)
        {
            float distance = Vector3.Distance(transform.position, player_pos.position);
            if (distance < 3.0f)
            {
                gameObject.SetActive(false);
                Score sc = Score.GetComponent<Score>();
                sc.hp--;
                if (sc.hp == 0)
                {
                    Player.SetActive(false);
                }
            }
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("�÷��̾��� ������� ������ ���� �Ǿ����ϴ�.");
        }

    }

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
