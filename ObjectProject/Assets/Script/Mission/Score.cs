using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    public GameObject Player;
    public int hp;
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        score = 0;
        hp = 3;
        text.text = $"���� ������ : {score}\n���� ���� ü�� : {hp}";
    }

    void Gameover()
    {
        text.text = $"���� ����! \n���� ���� {score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.activeSelf)
        {
            Gameover();
        }
        else
        text.text = $"���� ������ : {score} \n���� ���� ü�� : {hp}";
    }
}
