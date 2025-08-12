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
                new PlayerData() {Job = "전사", HP = 100, ATK = 30, DEF = 20},
                new PlayerData() {Job = "마법사", HP = 50, ATK = 50, DEF = 10},
                new PlayerData() {Job = "도적", HP = 75, ATK = 15, DEF = 15}
                }
        };

        string json = JsonUtility.ToJson(list, true);

        //Debug.Log($"현 저장 폴더 위치 : {Application.persistentDataPath}");
        string path = Path.Combine(Application.persistentDataPath, "joblist.json");

        File.WriteAllText(path, json);

    }
}
