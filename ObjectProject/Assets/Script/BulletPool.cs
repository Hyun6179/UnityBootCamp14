using System.Collections.Generic;
using UnityEngine;
// ������Ʈ Ǯ��(Object Pooling)
// ���� �����ǰ� �Ҹ�Ǵ� ������Ʈ�� �̸� ������ �����صΰ�
// �ʿ��� �� Ȱ��ȭ�ϰ� ������� ���� �� ��Ȱ��ȭ�ϴ� ������ ������ �����ϴ� ���
// ���� ����


// ��� ����
// ź��, ����Ʈ, ������ �ؽ�Ʈ, ���� ó�� ���� �����ǰ� ������� ������
// �Ź� new, destroy�� ���� ���� ������ �߻��ϸ� GC�� ���� ȣ��ǰ� �ǰ� �̴�
// ���� ���Ϸ� �̾��� �� �ֱ⿡ ���� ����� �������� ����մϴ�.

// ����) �߻� �Ѿ� �� 30�� / ������ ���� 20������ �̸� �ѹ��� �� ����
//       �Ⱦ��� ���� ��Ȱ��ȭ

public class BulletPool : MonoBehaviour
{
    public GameObject bullet_prefab;
    public int size = 30;

    // Ǯ�� ���� ���Ǵ� �ڷᱸ��
    // 1. ����Ʈ(List) : �����͸� ���������� �����ϰ�, �߰�, ������ �����ӱ� ������ ȿ���� (LIFO)
    // 2. ť(Queue) : �����Ͱ� ���� ������� �����Ͱ� ���������� ������ �ڷᱸ�� �Դϴ�.(FIFO)
    private List<GameObject> pool;

    private void Start()
    {
        // �Ѿ� ����
        pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            var bullet = Instantiate(bullet_prefab);
            bullet.transform.parent = transform;
            // ������ �Ѿ��� ���� ��ũ��Ʈ�� ���� ������Ʈ�� �ڽ����� �����˴ϴ�.   

            bullet.SetActive(false);

            bullet.GetComponent<Bullet>().SetPool(this);

            pool.Add(bullet);
            //����Ʈ��.Add(��); ����Ʈ�� �ش� ���� �߰��ϴ� ����
        }
    }


    public GameObject GetBullet()
    {
        // ��Ȱ��ȭ �Ǿ��ִ� �Ѿ��� ã�� Ȱ��ȭ �մϴ�.
        foreach (var bullet in pool)
        {
            //���� â���� Ȱ��ȭ�� �ȵǾ� �ִٸ� (������� �ʰ� �ִٸ�)
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        // �Ѿ��� ������ ��쿡�� ���Ӱ� ���� ����Ʈ�� ����մϴ�.
        var new_Bullet = Instantiate(bullet_prefab);
        new_Bullet.transform.parent = transform;
        new_Bullet.GetComponent<Bullet>().SetPool(this);
        pool.Add(new_Bullet);
        return new_Bullet;

    }

    public void Return(GameObject bullet)
    {
        bullet.SetActive(false);
    }

}
