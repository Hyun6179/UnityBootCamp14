using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleMission : MonoBehaviour
{
    public Button start;
    public Button end;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start.onClick.AddListener(OnStartClick);
        end.onClick.AddListener(OnEndClick);
    }

    private void OnStartClick()
    {
        SceneManager.LoadScene("GameScene");
    }

    private void OnEndClick()
    {
        Application.Quit();
    }
}
