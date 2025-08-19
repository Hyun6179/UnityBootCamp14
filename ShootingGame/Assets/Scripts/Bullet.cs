using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;

    private BulletPool pool;

    public void SetPool(BulletPool pool)
    {
        this.pool = pool;
    }
    void Update()
    {
        Vector3 dir = Vector3.up;

        transform.position += dir * speed * Time.deltaTime;

        if(gameObject.activeSelf == false)
        {
            ReturnBullet();
        }
    }

    void ReturnBullet() => pool.ReturnBullet(gameObject);
}
