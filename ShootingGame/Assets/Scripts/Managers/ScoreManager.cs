using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text bestText;
    public Text quest;
    public GameObject pannel;

    private UnityEvent Quest;
    private int score;
    private int count;
    public static ScoreManager Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Quest.AddListener( NewQuest);
        Quest.Invoke(this, EventArgs.Empty);
        SetBestText(PlayerPrefs.GetInt("Best"));
    }

    private void Update()
    {
        quest.text = $"목표\n{count}";
    }

    public void SetScore(int value)
    {
        score += value; // 전달 받은 값만큼 점수를 증가시킨다.
        SetScoreText(score);

        // 단순히 게임 안에서만 사용되는 데이터이기 때문에 PlayerPrefs 사용
        if (score > PlayerPrefs.GetInt("Best"))
        {
            PlayerPrefs.SetInt("Best", score);
            SetBestText(PlayerPrefs.GetInt("Best"));
        }
        
    }


    public void SetKilledEnemy()
    {
        count--;
        if(count == 0)
        {
            Quest += NewQuest;
            pannel.SetActive(true);
        }
    }

    private void NewQuest(object sender, EventArgs e)
    {
        count += 5;
    }

    private void SetScoreText(int score) => scoreText.text = $"Score : {score}";
    private void SetBestText(int best) => bestText.text = $"Best : {best}";
    public int GetScore() => score;
}
