using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pannel : MonoBehaviour
{
    public Text stage;
    public Button next;
    public Button exit;
    public GameObject pannel;
    private static int level = 1;

    private void Start()
    {
        next.onClick.AddListener(OnNextStage);
        exit.onClick.AddListener(OnExitGame);
    }
    private void Update()
    {
        stage.text = $"현재 스테이지 : {level}";
    }

    private void OnNextStage()
    {
        level++;
        SceneManager.LoadScene("SampleScene");
        pannel.SetActive(false);
    }

    private void OnExitGame()
    {
        Application.Quit();
    }
}
