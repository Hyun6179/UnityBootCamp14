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
        level_text.text = $"현재 스테이지 : {count}";
    }

    private void OnCheckAnswer(string PlayerAnswer)
    {
        if (PlayerAnswer.ToLower() == correctAnswer.ToLower())
        {
            pannel.SetActive(true);
        }
        else 
        {
            Debug.Log("정답이 아닙니다.");
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
                question.text = "처지를 서로 바꾸어\n\n생각함이란 뜻으로,\n\n상대방의 처지에 대해\n\n생각해본다는 말";
                correctAnswer = "역지사지";
                break;
            case 1:
                question.text = "한번 간 사람이 돌아오지 않거나\n소식이 없음을 뜻하는 말";
                correctAnswer = "함흥차사";
                break;
            case 2:
                question.text = "귀신이 풀을 묶어\n\n은혜에 보답한다는 뜻으로\n\n은혜를 꼭 갚는다는 말";
                correctAnswer = "결초보은";
                break;
            case 3:
                question.text = "지난 잘못을 고쳐\n\n새사람이 된다는 말";
                correctAnswer = "개과천선";
                break;
            case 4:
                question.text = "정도가 지나친 것은\n\n모자라는 것과 같다는 말";
                correctAnswer = "과유불급";
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
