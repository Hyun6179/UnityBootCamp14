using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float plusSp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
        speed = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        plusSp = player.transform.GetComponent<SkeletonController>.score;
        transform.Translate(0, speed * Time.deltaTime + plusSp, 0);

        //���Ϲ��� y���� -2���� �۴ٸ� ���Ϲ��� �ı��ϴ� �ڵ�
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }

        //�浹 ���� ó��
        //���� ���� �浹 ���� ���� ���
        Vector3 v1 = transform.position;
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2; // v1�� v2 ������ ��ġ

        //magnitude
        float d = dir.magnitude; // ������ ũ�� �Ǵ� ���̸� �ǹ��մϴ�. (�� �� ������ �Ÿ��� ����� �� ����մϴ�.

        float obj_r1 = 0.5f; //���Ϲ�
        float obj_r2 = 1.0f; //���̷��� �Ӹ�

        //�� �� ������ �Ÿ��� d�� ���� ������ �������� �պ��� ũ�ٸ� �浹���� �ʴ� ��Ȳ
        if (d < obj_r1 + obj_r2)
        {
            Destroy(gameObject);
        }


    }
}
