using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    public Text scoreText; // 현재점수 \n 맥스점수
    public Text time;
    public Text finalScore;
    public Button restart; // 다시하기 버튼
    public Button end; // 종료하기 버튼
    public int preScore;
    public int maxScore;
    public float endTime;

    public GameObject pannel;

    public static Sample Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        restart.onClick.AddListener(OnRestartClick);
        end.onClick.AddListener(OnEndClick);

        scoreText.text = $"현재점수 : {preScore}\n최고점수 : {PlayerPrefs.GetInt("MaxScore")}";
        endTime = 5.0f;
    }

    private void Update()
    {
        endTime -= Time.deltaTime;
        time.text = $"남은 시간 : {Mathf.CeilToInt(endTime)}";
        if (endTime > 0)
        {
            scoreText.text = $"현재점수 : {preScore}\n최고점수 : {PlayerPrefs.GetInt("MaxScore")}";
        }
        else
        {
            endTime = 0;
            if (preScore >= PlayerPrefs.GetInt("MaxScore"))
            {
                PlayerPrefs.SetInt("MaxScore", preScore);
            }
            pannel.SetActive(true);
            finalScore.text = $"최고 점수 : {PlayerPrefs.GetInt("MaxScore")}";
            PlayerPrefs.Save();
        }
    }
    public void GetScore()
    {
        if(!pannel.activeSelf)
        {
            preScore++;
        }
    }
    public void OnRestartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnEndClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
    Applicatiom.Quit();
#endif
    }

}
