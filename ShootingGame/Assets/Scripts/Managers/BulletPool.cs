using System.Collections.Generic;
using UnityEngine;

// 탄창을 적용하면 무분별한 난사를 막을 수 있을 것
public class BulletPool : MonoBehaviour
{
    public GameObject bulletFactory; // 총알 공장
    public int poolSize = 20; // 총알의 개수
    private List<GameObject> pool;
    public Transform fire;
        
    void Start()
    {
        pool = new List<GameObject> ();
        for(int i = 0; i < poolSize; i++)
        {
            var bullet = Instantiate(bulletFactory);
            bullet.transform.parent = transform;

            bullet.SetActive(false);

            bullet.GetComponent<Bullet>().SetPool(this);

            pool.Add(bullet);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject bullet = pool[i];
                if (bullet.activeSelf == false)
                {
                    bullet.SetActive(true);
                    bullet.transform.position = fire.position;
                    break;
                }
            }
        }
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }
}
