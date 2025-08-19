using UnityEngine;

// ��ǥ : ���� �ð����� ���� ������ �� ��ġ�� ���� ��.
// �ʿ��� ������ : ���� �ð�, ���� �ð�, �� ���� ����
// �۾� ���� : 1. �ð��� üũ�ϰ�
//            2. ���� �ð��� ���� �ð��� �ȴٸ� (�� Ÿ��, ��Ÿ��...)
//            3. ���� �����մϴ�. 

public class EnemyManager : MonoBehaviour
{
    float min = 1, max = 5; // ��ȯ �ð� ���� (�ִ� �ּ�) ���� �ֱ� ����

    float currentTIme;
    public float createTime = 1;
    public GameObject enemyFactory;
    public GameObject spawnArea; // ���� ����

    private void Update()
    {
        currentTIme += Time.deltaTime;

        if (currentTIme > createTime)
        {
            var enemy = Instantiate(enemyFactory, spawnArea.transform.position, Quaternion.identity);
            // ��ȯ ���� (spawn area)�� ������ ������ ������,
            // ���� ��ġ�� ȸ�� �� ���� ���� �ʾƵ� �ȴ�.

            // ������ ���� ���� �Ǿ� �ִٸ� ���� ��ġ�� �����Ѵ�.
            currentTIme = 0; // ������ �ð��� ������, �ٽ� ���ǹ��� üũ�� �� �ֵ��� �����մϴ�.
            createTime = Random.Range(min, max);
        }
    }
}
