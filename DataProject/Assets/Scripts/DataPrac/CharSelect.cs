using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharSelect : MonoBehaviour
{
    public Text status;
    public int num;

    public GameObject pannel;
    public Button button01;
    public Button button02;
    public Button button03;
    public Button button04;
    [Serializable]
    public class PlayerData
    {
        public string Job;
        public int HP;
        public int ATK;
        public int DEF;
    }

    [Serializable]
    public class PlayerList
    {
        public PlayerData[] players;
    }

    private PlayerList playerlist;

    public void Start()
    {
        button04.interactable = false;
        string path = Path.Combine(Application.persistentDataPath, "joblist.json");
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerlist = JsonUtility.FromJson<PlayerList>(json);

            button01.onClick.AddListener(() => StatusSelect(0,out num));
            button02.onClick.AddListener(() => StatusSelect(1,out num));
            button03.onClick.AddListener(() => StatusSelect(2,out num));
            button04.onClick.AddListener(() => SelectComplete(num));
        }
        else
        {
            Debug.LogWarning("해당 경로에 저장된 JSON 파일이 없습니다.");
        }

    }
    public void StatusSelect(int index, out int num)
    {
        var p = playerlist.players[index];
        status.text = $"직업 : {p.Job}\n체력 : {p.HP}\n공격력 : {p.ATK}\n방어력 : {p.DEF}";
        button04.interactable = true;
        num = index;
    }

    void SelectComplete(int num)
    {
        var p = playerlist.players[num];
        PlayerPrefs.SetString("Job", p.Job);
        PlayerPrefs.SetInt("HP", p.HP);
        PlayerPrefs.SetInt("ATK", p.ATK);
        PlayerPrefs.SetInt("DEF", p.DEF);
        PlayerPrefs.Save();
        Debug.Log($"직업 : {PlayerPrefs.GetString("Job")}\n체력 : {PlayerPrefs.GetInt("HP")}\n공격력 : {PlayerPrefs.GetInt("ATK")}\n방어력 : {PlayerPrefs.GetInt("DEF")}");
        pannel.SetActive(false);
        SceneManager.LoadScene("NextScene");
    }
}
