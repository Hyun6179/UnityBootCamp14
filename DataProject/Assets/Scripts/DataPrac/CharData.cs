using System;
using System.IO;
using UnityEngine;

public class CharData : MonoBehaviour
{
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

    private void Start()
    {
        PlayerList list = new PlayerList()
        {
            players = new PlayerData[] {
                new PlayerData() {Job = "����", HP = 100, ATK = 30, DEF = 20},
                new PlayerData() {Job = "������", HP = 50, ATK = 50, DEF = 10},
                new PlayerData() {Job = "����", HP = 75, ATK = 15, DEF = 15}
                }
        };

        string json = JsonUtility.ToJson(list, true);

        //Debug.Log($"�� ���� ���� ��ġ : {Application.persistentDataPath}");
        string path = Path.Combine(Application.persistentDataPath, "joblist.json");

        File.WriteAllText(path, json);

    }
}
