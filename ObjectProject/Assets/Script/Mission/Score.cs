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
        text.text = $"현재 점수는 : {score}\n현재 남은 체력 : {hp}";
    }

    void Gameover()
    {
        text.text = $"게임 종료! \n최종 점수 {score}";
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player.activeSelf)
        {
            Gameover();
        }
        else
        text.text = $"현재 점수는 : {score} \n현재 남은 체력 : {hp}";
    }
}
