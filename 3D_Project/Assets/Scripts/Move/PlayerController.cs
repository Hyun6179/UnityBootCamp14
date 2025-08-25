using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float rotateSpeed = 5f;

    // �߰�: �������� üũ��
    public float probeForward = 0.6f; // ĳ���� �� �� m ���� �˻�
    public float probeDown = 2f;      // �Ʒ��� �� m ����

    private Rigidbody rb;
    //public float mouseSensitivity = 1f;
    //private float rotationY = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 moveDir = transform.right * h + transform.forward * v; // ĳ���� ���� ����
        Vector3 moveDir = new Vector3(h, 0, v); // ���� ���� ����
        Vector3 desiredMove = moveDir.normalized * moveSpeed * Time.deltaTime;

       /* float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // ���콺 ������ ��ġ 
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);*/

        Vector3 playerCenter = transform.position + Vector3.up;


        // ���� ���������� '���� ����'�� ����  = ���� ���� �̶�� ���� ���� �̵��� ���Ϳ��� ������ ���� �κ��� �����Ѵ� ���� ���� �������� ��
        if (Vector3.Dot(transform.forward, desiredMove) > 0f) // Dot�� transform.forward �־ �̵��Ϸ��� ���Ͱ� ���� forward ����(��������) ������ Ȯ�� �ϴ� �Լ�
        {
            Vector3 probeOrigin = playerCenter + transform.forward * probeForward;
            Debug.DrawLine(probeOrigin, probeOrigin + Vector3.down * probeDown, Color.red);

            if (!Physics.Raycast(probeOrigin, Vector3.down, out RaycastHit hit, probeDown))
            {
                // ������ ������ ���и� �����ϰ� ��/��/������ ����
                Vector3 forwardOnly = Vector3.Project(desiredMove, transform.forward);
                desiredMove -= forwardOnly;
            }
        }
        if (h == 0 && v == 0) return;
        Quaternion dir = Quaternion.LookRotation(desiredMove);
        rb.MovePosition(transform.position + desiredMove);
        rb.rotation = Quaternion.Slerp (rb.rotation, dir, rotateSpeed * Time.deltaTime);
    }
}