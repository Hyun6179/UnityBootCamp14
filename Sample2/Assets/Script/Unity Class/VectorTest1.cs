using UnityEngine;

public class VectorTest1 : MonoBehaviour
{
    // ���� ������Ʈ�� Transform�� ���� Vector �� 

    public Transform A_CUBE;
    public Transform B_CUBE;

    void Start()
    {
        // ���� ť���� ��ġ�� ���ͷ� �����մϴ�.
        Vector3 posA = A_CUBE.position;
        Vector3 posB = B_CUBE.position;

        // �� ������ ���� => ���� ����
        Vector3 atob = posA - posB;
        Vector3 btoa = posB - posA;

        // �Ÿ� ����
        // Distance�� ������ ����
        // a = (ax, ay, az)
        // b = (bx, by, bz)��� �� ��,
        // �� ���� ������ �Ÿ���
        // �� �࿡ ���� ���� ������ �տ� ���� ��Ʈ (��Ÿ��� ����)
        // ��(bx - ax)^2 + (by - ay)^2 + (bz - az)^2

        // ����Ƽ�� Mathf Ŭ������ ������� �ٲٸ�?
        Vector3 dif = posB - posA;
        float distance = Mathf.Sqrt(dif.x * dif.x + dif.y*dif.y + dif.z * dif.z);
        Debug.Log(distance);

        distance = Vector3.Distance(posA, posB);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
