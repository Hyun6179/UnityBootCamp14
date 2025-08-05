using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public GameObject bullet;
    public GameObject player;
    public float score;
    public float hp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = bullet.gameObject.GetComponent<Bullet>().score;
        hp = player.GetComponent<Player>().hp;
        text.text = $"���� ������ : {score}\n���� ���� ü�� : {hp}";
    }

    // Update is called once per frame
    void Update()
    {
        text.text = $"���� ������ : {score} \n���� ���� ü�� : {hp}";
    }
}
