using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMission : MonoBehaviour
{
    public Text question;
    public Text level_text;

    public InputField answer;

    public GameObject pannel;
    public Button exit;
    public Button next;

    
    static private int count;
    private int seconds = 0;
    private string ans = "";
    private string correctAnswer = string.Empty;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        count = 0;
        SetQuestion();
        answer.onEndEdit.AddListener(OnCheckAnswer);
        exit.onClick.AddListener(OnTitleEnter);
        next.onClick.AddListener(OnNextGame);
    }

    // Update is called once per frame
    void Update()
    {
        level_text.text = $"���� �������� : {count}";
    }

    private void OnCheckAnswer(string PlayerAnswer)
    {
        if (PlayerAnswer.ToLower() == correctAnswer.ToLower())
        {
            pannel.SetActive(true);
        }
        else 
        {
            Debug.Log("������ �ƴմϴ�.");
        }

        answer.text = "";
        answer.ActivateInputField();
    }

    private void SetQuestion()
    {
        int rand = UnityEngine.Random.Range(0, 5);
        switch(rand)
        {
            case 0:
                question.text = "ó���� ���� �ٲپ�\n\n�������̶� ������,\n\n������ ó���� ����\n\n�����غ��ٴ� ��";
                correctAnswer = "��������";
                break;
            case 1:
                question.text = "�ѹ� �� ����� ���ƿ��� �ʰų�\n�ҽ��� ������ ���ϴ� ��";
                correctAnswer = "��������";
                break;
            case 2:
                question.text = "�ͽ��� Ǯ�� ����\n\n������ �����Ѵٴ� ������\n\n������ �� ���´ٴ� ��";
                correctAnswer = "���ʺ���";
                break;
            case 3:
                question.text = "���� �߸��� ����\n\n������� �ȴٴ� ��";
                correctAnswer = "����õ��";
                break;
            case 4:
                question.text = "������ ����ģ ����\n\n���ڶ�� �Ͱ� ���ٴ� ��";
                correctAnswer = "�����ұ�";
                break;
        }
    }

    private void OnNextGame()
    {
        count++;
        pannel.SetActive(false);
        SetQuestion();
    }

    private void OnTitleEnter()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
