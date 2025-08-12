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
        status.text = $"직업 : {PlayerPrefs.GetString("Job")}\n체력 : {PlayerPrefs.GetInt("HP")}\n공격력 : {PlayerPrefs.GetInt("ATK")}\n방어력 : {PlayerPrefs.GetInt("DEF")}";
    }

    void onReturnClick()
    {
        SceneManager.LoadScene("StartScene");
    }
}
