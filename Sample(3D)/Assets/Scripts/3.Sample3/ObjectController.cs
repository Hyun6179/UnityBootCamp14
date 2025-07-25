using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float plusSp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("mini simple skeleton demo");
        speed = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        plusSp = player.transform.GetComponent<SkeletonController>.score;
        transform.Translate(0, speed * Time.deltaTime + plusSp, 0);

        //낙하물의 y축이 -2보다 작다면 낙하물을 파괴하는 코드
        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }

        //충돌 판정 처리
        //원에 의한 충돌 판정 로직 사용
        Vector3 v1 = transform.position;
        Vector3 v2 = player.transform.position;

        Vector3 dir = v1 - v2; // v1과 v2 사이의 위치

        //magnitude
        float d = dir.magnitude; // 벡터의 크기 또는 길이를 의미합니다. (두 점 사이의 거리를 계산할 때 사용합니다.

        float obj_r1 = 0.5f; //낙하물
        float obj_r2 = 1.0f; //스켈레톤 머리

        //두 값 사이의 거리인 d의 값이 설정한 지점들의 합보다 크다면 충돌하지 않는 상황
        if (d < obj_r1 + obj_r2)
        {
            Destroy(gameObject);
        }


    }
}
