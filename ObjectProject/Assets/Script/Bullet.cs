using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// �Ѿ˿� ���� ����, �Ѿ� �ݳ�, �Ѿ� �̵�
public class Bullet : MonoBehaviour
{
    public float speed = 5.0f; // �Ѿ� �̵� �ӵ�
    public float life_time = 2.0f; // �Ѿ� �ݳ� �ð�
    public GameObject effect_prefab; // ����Ʈ ������
    public int damage = 10;
    public int count = 0;

    public GameObject Score;

    private GameObject Enemy;
    private BulletPool pool; // Ǯ
    private Coroutine life_coroutine;

    // Ǯ ����(Ǯ���� �ش� �� ȣ��)
    public void SetPool(BulletPool pool)
    {
        this.pool = pool;
    }

    // Ȱ��ȭ �ܰ�
    private void OnEnable()
    {
        life_coroutine = StartCoroutine(BulletReturn());

    }

    private void Start()
    {
        Score = GameObject.FindWithTag("Score");
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // ��Ȱ��ȭ �ܰ�
    private void OnDisable()
    {
        // if�� �ۼ��� ��ɹ��� 1���� ��� {} ���� �����մϴ�.
        if (life_coroutine != null)
        {
            StopCoroutine(life_coroutine);
        }
    }


    IEnumerator BulletReturn()
    {
        yield return new WaitForSeconds(life_time);
        ReturnPool();
    }    

    private void OnTriggerEnter(Collider other)
    {
        // �ε��� ����� Enemy �±׸� ������ �ִ� ������Ʈ�� ���
        // �������� �����ϴ�.�� ���� ������ ���� �ڵ� �ۼ�
        void Critical()
        {
            int critical = Random.Range(0, 2);
            if (critical > 0)
            {
                Debug.Log($"ũ��Ƽ�� ��Ʈ!");
                damage = damage * 2;
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //Critical();
            Debug.Log($"�������� {damage}��ŭ �����ϴ�.");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy.hp <= damage)
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject, 1.0f);
                Score sc = Score.GetComponent<Score>();
                sc.score += 10;
                count++;
            }
            else
            {
                enemy.hp -= damage;
            }
        }

        // ����Ʈ ����(��ƼŬ)
        if (effect_prefab != null)
        {
            Instantiate(effect_prefab, transform.position, Quaternion.identity);
        }
        
        ReturnPool();
    }

    //�޼ҵ��� ����� 1���� ���, => �� ����� �� �ֽ��ϴ�.
    void ReturnPool() => pool.Return(gameObject);
}
