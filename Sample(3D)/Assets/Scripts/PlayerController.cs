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
        //GetComponent<T>(); 게임 오브젝트에 붙어있는 컴포넌트를 가져오는 기능.
        //T : Type
        Debug.Log("설정이 완료되었습니다!");
    }

    // Update is called once per frame
    void Update()
    {
        //speed += 1;
        //Debug.Log($"속도가 1 증가합니다. 현재 속도는 {speed}입니다.");

        //수평이동
        float horizontal = Input.GetAxis("Horizontal");
        //수직이동
        float vertical = Input.GetAxis("Vertical");

        //이동 좌표(벡터) 설정
        Vector3 movement = new Vector3 (horizontal, 0, vertical);

        rb.AddForce(movement * speed);

    }

    private void OnTriggerEnter(Collider other)
    {
        //충돌체의 게임 오브젝트의 태그가 ItemBox라면?
        if(other.gameObject.CompareTag("Itembox"))
        {
            Debug.Log("아이템 획득!");
            //충돌체의 게임 오브젝트를 비활성화 합니다.
            other.gameObject.SetActive(false);
        }

        //선생님이 주신 미션
        /*
         * Obstacle 스크립트를 만들어서 장애물을 구현하세요.

        조건1)  장애물의 태그는 "obstacle"
            	장애물과 트리거 충돌 할 경우 플레이어의 speed가 1 감소
            	장애물 제거
         */
        if (other.gameObject.CompareTag("obstacle"))
        {
            Debug.Log("충돌 발생!");
            other.gameObject.SetActive(false);
            speed -= 1;
        }

    }
}
