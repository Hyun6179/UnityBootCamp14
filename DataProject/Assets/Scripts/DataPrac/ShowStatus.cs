using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShowStatus : MonoBehaviour
{
    public Text status;
    public Button back;

    private void Start()
    {
        back.onClick.AddListener(onReturnClick);
    }

    private void Update()
    {
        status.text = $"���� : {PlayerPrefs.GetString("Job")}\nü�� : {PlayerPrefs.GetInt("HP")}\n���ݷ� : {PlayerPrefs.GetInt("ATK")}\n���� : {PlayerPrefs.GetInt("DEF")}";
    }

    void onReturnClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
