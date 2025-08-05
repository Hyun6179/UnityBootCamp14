using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemyDead : MonoBehaviour
{
    public int hp = 10;
    public Enemy enemy;
    public GameObject Bullet;
    public int damage;
    public int score;


    void GetPoint()
    {
        score += 10;
        Debug.Log($"현재 점수를 {score}만큼 획득했습니다.");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damage = Bullet.gameObject.GetComponent<Bullet>().damage;
        score = 0;
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (damage >= hp)
        {
            gameObject.SetActive(false);
            Debug.Log($"{gameObject.name}을 처치했습니다.");
            GetPoint();
        }
        else
            hp -= damage;
    }
}
