using UnityEngine;
// �÷��̾�� ���� ����
// �÷��̾� : ��Ʈ���� ����ڰ� �����մϴ�.
// �� : ��Ƽ ������ �ƴ϶��, ���� ������ ��ɿ� ���� �ڵ����� �����̰� �˴ϴ�.

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Down, Chase // �Ʒ��� �������� ����, �÷��̾ �����ϴ� ����
    }

    public GameObject explosionFactory;
    public float speed = 5.0f;
    public EnemyType type = EnemyType.Down;
    Vector3 dir;

    // ���� ���� ����
    private void Start()
    {
        // �Լ� �и�
        // ���� : ������ ������
        //        ���뼺�� ������ �� ����(���� ���� ����, ����� ���� ���� ���� ��)
        PatternSetting();
    }

    void PatternSetting()
    {
        int rand = Random.Range(0, 10); // 0 ~ 9������ �� �� �ϳ��� ���� �������� �������ڽ��ϴ�.

        if (rand < 3) // 0, 1, 2 30%
        {
            type = EnemyType.Chase;
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            dir = target.transform.position - transform.position; // Ÿ�� ��ġ - ���� ��ġ = ����
            dir.Normalize(); // ������ ũ��� 1�� �����մϴ�.
        }
        else
        {
            type = EnemyType.Down;
            // �Ʒ��� �������� ���
            dir = Vector3.down;
        }
    }

    void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    // �浹 �̺�Ʈ ����
    // ������Ʈ�� ������Ʈ ���� ������ �浹 �߻� �� ȣ��˴ϴ�.
    // ���� �ϳ��� Rigidbody�� ������ �־�� ó���˴ϴ�.

    // OnCollisionEnter : �浹 �߻� �� 1�� ȣ��
    // OnCollisionStay : �浹 �����Ǵ� ���� ȣ��
    // OnCollisionExit : �浹 �߻� �� �浹 �۾����� ��� ��� 1�� ȣ��

    // Ʈ���ŵ� OnTriggerXXX�� ���� ���� ������ ������ ������ �ֽ��ϴ�.
    // 2D�� ��� OnCollisionEnter2Dó�� �������� 2D�� ����մϴ�.

    // �Ϲ����� ������ �浹 Collision (���������� ���� ���� ������ ȸ���ϰų� �̵���)
    // isTrigger üũ�� ����� ������Ʈ���� Ʈ���� �浹 Trigger

    private void OnCollisionEnter(Collision collision)
    {
        // Ŭ������.Instance.�޼ҵ��()���� ��ɸ� ����ϴ� ���� ����������.
        ScoreManager.Instance.SetScore(5);
        ScoreManager.Instance.SetKilledEnemy();

        GameObject explosion = Instantiate(explosionFactory, collision.transform.position, Quaternion.identity);
        Destroy(gameObject); // �ڽ� �ı�

        if(collision.gameObject.name.Contains("Bullet"))
        {
            collision.gameObject.SetActive(false);
        }
        else
            Destroy(collision.gameObject); // ���� �ı�

    }
}
