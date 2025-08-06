using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// �Ѿ˿� ���� ����, �Ѿ� �ݳ�, �Ѿ� �̵�
public class Bullet : MonoBehaviour
{
    public GameObject enemy;
    public float speed = 5.0f; // �Ѿ� �̵� �ӵ�
    public float life_time = 2.0f; // �Ѿ� �ݳ� �ð�
    public GameObject effect_prefab; // ����Ʈ ������
    public int damage = 10;

    public GameObject Score;

    public int hp;
    private int score;

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
        hp = enemy.GetComponent<Enemy>().hp;
        life_coroutine = StartCoroutine(BulletReturn());

    }

    private void Start()
    {
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

        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log($"�������� {damage}��ŭ �����ϴ�.");

            if (hp <= damage)
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject, 1.0f);
                score += 10;
            }
            else
            {
                hp -= damage;
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
