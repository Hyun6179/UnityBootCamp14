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
    public UnityEvent Quest;

    private int score;
    private int count;
    private static int questCount = 0;
    public static ScoreManager Instance = null;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        questCount += 5;
    }

    private void Start()
    {
        SetBestText(PlayerPrefs.GetInt("Best"));
    }

    private void Update()
    {
        quest.text = $"��ǥ : {questCount}\n���� : {count}";
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
        count++;
        if(count == questCount)
        {
            pannel.SetActive(true);
        }
    }

    private void SetScoreText(int score) => scoreText.text = $"Score : {score}";
    private void SetBestText(int best) => bestText.text = $"Best : {best}";
    public int GetScore() => score;
}
