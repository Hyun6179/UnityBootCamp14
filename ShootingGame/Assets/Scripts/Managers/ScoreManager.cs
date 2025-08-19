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
        quest.text = $"��ǥ\n{count}";
    }

    public void SetScore(int value)
    {
        score += value; // ���� ���� ����ŭ ������ ������Ų��.
        SetScoreText(score);

        // �ܼ��� ���� �ȿ����� ���Ǵ� �������̱� ������ PlayerPrefs ���
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
