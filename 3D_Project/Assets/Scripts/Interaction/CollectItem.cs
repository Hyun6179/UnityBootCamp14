using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetKeyDown(KeyCode.Space)) // ��ȣ�ۿ� SpaceŰ
        {
            int count = 0;
            if (collision.gameObject.CompareTag("Tree")) // ��ȣ�ۿ� ����� 
            {
                while (count < 3)
                {
                    Debug.Log("���� ���� ��...");
                    count++;
                }
                // ������, ��������, ��, ������ �������
            }
            else
                return;
        }
    }
}
