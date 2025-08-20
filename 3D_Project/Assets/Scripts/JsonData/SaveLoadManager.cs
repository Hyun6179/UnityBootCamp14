using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

    [SerializeField]
    public class PlayerData 
    {
        public string nickname;
        public int gold;
        public Vector3 position;
    }

    [SerializeField]
    public class InventoryItem
    {
        public string itemID;
        public int count;
        public bool equipped;
    }

    [SerializeField]
    public class Settings
    {
        public float volume;
    }

    [SerializeField]
    public class World_state
    {
        public string time;
        public string weather;
        public string season;
    }

[SerializeField]
public class PlayerDataList
{
    public PlayerData playerData;
    public List<InventoryItem> inventroy;
    public Settings settings;
    public World_state state;
}

public class SaveLoadManager : MonoBehaviour
{
    private string path;

    private void Awake()
    {
        string path = Path.Combine(Application.persistentDataPath, "saves.json");
    }

    public void SaveData(PlayerDataList data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
        Debug.Log ("데이터 저장 완료 : " + path);
    }

    public PlayerDataList LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerDataList data = JsonUtility.FromJson<PlayerDataList>(json);
            Debug.Log("데이터 불러오기 완료");
            return data;
        }
        else
        {
            Debug.LogWarning("저장된 데이터가 없습니다.");
            return null;
        }
    }


    private void Start()
    {
        PlayerDataList list = new PlayerDataList()
        {
            playerData = new PlayerData() { nickname = "", gold = 0 },
            inventroy = new List<InventoryItem>() { new InventoryItem() { itemID = "", count = 0, equipped = false } },
            settings = new Settings() { volume = 0 },
            state = new World_state() { time = "00:00", weather = "rain", season = "spring" }
        };
    }
}

