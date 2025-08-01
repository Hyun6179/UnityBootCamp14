using UnityEngine;


[RequireComponent (typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float jump;
    public LayerMask ground;

    private Rigidbody rb;
    private bool isGrounded;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Ű �Է�
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        // ���� ����
        Vector3 dir = new Vector3 (x, 0, y);

        // �̵� �ӵ� ����
        Vector3 velocity = dir * speed;

        rb.linearVelocity = velocity;
        // ������ٵ��� �Ӽ�
        // linearVelocity = ���� �ӵ�(��ü�� ���� �󿡼� �̵��ϴ� �ӵ�)
        // angularVelocity = �� �ӵ� (��ü�� ȸ���ϴ� �ӵ�)

        // ���� ��� �߰�
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // ForceMoce.Impulse : �������� ��
            // ForceMode.Force : �������� �� 
        }


    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, ground);
    }


}
