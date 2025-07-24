using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 5;
        rb = GetComponent<Rigidbody>();
        //GetComponent<T>(); ���� ������Ʈ�� �پ��ִ� ������Ʈ�� �������� ���.
        //T : Type
        Debug.Log("������ �Ϸ�Ǿ����ϴ�!");
    }

    // Update is called once per frame
    void Update()
    {
        //speed += 1;
        //Debug.Log($"�ӵ��� 1 �����մϴ�. ���� �ӵ��� {speed}�Դϴ�.");

        //�����̵�
        float horizontal = Input.GetAxis("Horizontal");
        //�����̵�
        float vertical = Input.GetAxis("Vertical");

        //�̵� ��ǥ(����) ����
        Vector3 movement = new Vector3 (horizontal, 0, vertical);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        //�浹ü�� ���� ������Ʈ�� �±װ� ItemBox���?
        if(other.gameObject.CompareTag("Itembox"))
        {
            Debug.Log("������ ȹ��!");
            //�浹ü�� ���� ������Ʈ�� ��Ȱ��ȭ �մϴ�.
            other.gameObject.SetActive(false);
        }

        //�������� �ֽ� �̼�
        /*
         * Obstacle ��ũ��Ʈ�� ���� ��ֹ��� �����ϼ���.

        ����1)  ��ֹ��� �±״� "obstacle"
            	��ֹ��� Ʈ���� �浹 �� ��� �÷��̾��� speed�� 1 ����
            	��ֹ� ����
         */
        if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("�浹 �߻�!");
            other.gameObject.SetActive(false);
            speed -= 1;
        }

    }
}
