using UnityEngine;


public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        //�������� �ֽ� �̼�
        /*
         * Obstacle ��ũ��Ʈ�� ���� ��ֹ��� �����ϼ���.

        ����1)  ��ֹ��� �±״� "obstacle"
            	��ֹ��� Ʈ���� �浹 �� ��� �÷��̾��� speed�� 1 ����
            	��ֹ� ����
         */
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("�浹 �߻�!");
            gameObject.SetActive(false);
        }
    }
}
