using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float rotateSpeed = 5f;

    // 추가: 낭떠러지 체크용
    public float probeForward = 0.6f; // 캐릭터 앞 몇 m 지점 검사
    public float probeDown = 2f;      // 아래로 몇 m 쏠지

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

        //Vector3 moveDir = transform.right * h + transform.forward * v; // 캐릭터 기준 방향
        Vector3 moveDir = new Vector3(h, 0, v); // 월드 기준 방향
        Vector3 desiredMove = moveDir.normalized * moveSpeed * Time.deltaTime;

       /* float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; // 마우스 포인터 위치 
        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);*/

        Vector3 playerCenter = transform.position + Vector3.up;


        // 앞이 낭떠러지면 '전진 성분'만 제거  = 전진 성분 이라는 말은 최종 이동될 백터에서 앞으로 가는 부분을 제거한단 말임 왼쪽 오른쪽은 됨
        if (Vector3.Dot(transform.forward, desiredMove) > 0f) // Dot에 transform.forward 넣어서 이동하려는 벡터가 현재 forward 방향(전진방향) 쪽인지 확인 하는 함수
        {
            Vector3 probeOrigin = playerCenter + transform.forward * probeForward;
            Debug.DrawLine(probeOrigin, probeOrigin + Vector3.down * probeDown, Color.red);

            if (!Physics.Raycast(probeOrigin, Vector3.down, out RaycastHit hit, probeDown))
            {
                // 앞으로 가려는 성분만 제거하고 좌/우/후진은 유지
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