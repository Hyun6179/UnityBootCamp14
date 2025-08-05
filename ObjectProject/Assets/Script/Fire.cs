using UnityEngine;

// 이 코드는 총알에 대한 발사(생성) 기능만 담당합니다.
public class Fire : MonoBehaviour
{
    // 총알 발사를 위한 풀
    public BulletPool pool;

    // 총알 발사 지점
    public Transform pos;

    // 총알 발사 속도
    public float speed = 2.0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = pool.GetBullet();
            bullet.transform.position = pos.position;
            bullet.transform.rotation = pos.rotation;
        }
    }

}
