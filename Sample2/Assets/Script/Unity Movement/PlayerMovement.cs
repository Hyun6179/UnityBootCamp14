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
        // 키 입력
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        // 방향 설계
        Vector3 dir = new Vector3 (x, 0, y);

        // 이동 속도 설정
        Vector3 velocity = dir * speed;

        rb.linearVelocity = velocity;
        // 리지드바디의 속성
        // linearVelocity = 선형 속도(물체가 공간 상에서 이동하는 속도)
        // angularVelocity = 각 속도 (물체가 회전하는 속도)

        // 점프 기능 추가
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded()) 
        {
            rb.AddForce(Vector3.up * jump, ForceMode.Impulse);
            // ForceMoce.Impulse : 순간적인 힘
            // ForceMode.Force : 지속적인 힘 
        }


    }

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.0f, ground);
    }


}
