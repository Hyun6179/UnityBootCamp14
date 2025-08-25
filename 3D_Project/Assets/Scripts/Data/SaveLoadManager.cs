using System.IO;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;
    private string savePath;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);


        savePath = Path.Combine(Application.persistentDataPath, "saves.json");
        DontDestroyOnLoad(gameObject);
    }

    public void SaveData(PlayerDataList data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(savePath, json);
        Debug.Log ("데이터 저장 완료 : " + savePath);
    }

    public PlayerDataList LoadData()
    {
        if (File.Exists(savePath))
        {

            string json = File.ReadAllText(savePath);
            PlayerDataList data = JsonUtility.FromJson<PlayerDataList>(json);
            Debug.Log("불러오기 완료");
            return data;
        }
        else
        {
            Debug.LogWarning("저장된 데이터가 없습니다.");
            return null;
        }
    }

    private void OnApplicationQuit()
    {
        // 게임 종료시 최종 저장
        if (InventoryManager.Instance != null)
        {
            SaveData(InventoryManager.Instance.GetCurrentData());
        }
    }
}

