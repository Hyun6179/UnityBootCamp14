using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FindData : MonoBehaviour
{
    public Button load;
    public Button R;
    public Button New;
    public Button End;
    public GameObject pannel;

    private void Start()
    {
        New.onClick.AddListener(CreateNewChar);
        R.onClick.AddListener(OnResetClick);
        load.onClick.AddListener(OnNextScene);
        End.onClick.AddListener(GameExit);

    }
    private void Update()
    {
        if (PlayerPrefs.HasKey("Job"))
        {
            load.interactable = true;
        }
        else
        {
            load.interactable = false;
        }
    }

    void CreateNewChar()
    {
        pannel.SetActive(true);
    }

    void OnResetClick()
    {
        PlayerPrefs.DeleteKey("Job");
    }

    void OnNextScene()
    {
        SceneManager.LoadScene("NextScene");
    }
    void GameExit()
    {
#if UNITY_EDITOR
        EditorApplication.Exit(0);
#else
    Applicatiom.Quit();
#endif
    }
}
