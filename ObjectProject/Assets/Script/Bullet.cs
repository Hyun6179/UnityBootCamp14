using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

// 총알에 대한 정보, 총알 반납, 총알 이동
public class Bullet : MonoBehaviour
{
    public float speed = 5.0f; // 총알 이동 속도
    public float life_time = 2.0f; // 총알 반납 시간
    public GameObject effect_prefab; // 이펙트 프리펩
    public int damage = 10;
    public int count = 0;

    public GameObject Score;

    private GameObject Enemy;
    private BulletPool pool; // 풀
    private Coroutine life_coroutine;

    // 풀 설정(풀에서 해당 값 호출)
    public void SetPool(BulletPool pool)
    {
        this.pool = pool;
    }

    // 활성화 단계
    private void OnEnable()
    {
        life_coroutine = StartCoroutine(BulletReturn());

    }

    private void Start()
    {
        Score = GameObject.FindWithTag("Score");
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    // 비활성화 단계
    private void OnDisable()
    {
        // if문 작성시 명령문이 1줄일 경우 {} 생략 가능합니다.
        if (life_coroutine != null)
        {
            StopCoroutine(life_coroutine);
        }
    }


    IEnumerator BulletReturn()
    {
        yield return new WaitForSeconds(life_time);
        ReturnPool();
    }    

    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 대상이 Enemy 태그를 가지고 있는 오브젝트일 경우
        // 데미지를 입힙니다.와 같은 데미지 관련 코드 작성
        void Critical()
        {
            int critical = Random.Range(0, 2);
            if (critical > 0)
            {
                Debug.Log($"크리티컬 히트!");
                damage = damage * 2;
            }
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            //Critical();
            Debug.Log($"데미지를 {damage}만큼 입힙니다.");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();

            if (enemy.hp <= damage)
            {
                other.gameObject.SetActive(false);
                Destroy(other.gameObject, 1.0f);
                Score sc = Score.GetComponent<Score>();
                sc.score += 10;
                count++;
            }
            else
            {
                enemy.hp -= damage;
            }
        }

        // 이펙트 연출(파티클)
        if (effect_prefab != null)
        {
            Instantiate(effect_prefab, transform.position, Quaternion.identity);
        }
        
        ReturnPool();
    }

    //메소드의 명령이 1줄일 경우, => 로 사용할 수 있습니다.
    void ReturnPool() => pool.Return(gameObject);
}
