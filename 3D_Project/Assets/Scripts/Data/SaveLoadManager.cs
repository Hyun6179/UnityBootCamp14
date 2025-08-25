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
        Debug.Log ("������ ���� �Ϸ� : " + savePath);
    }

    public PlayerDataList LoadData()
    {
        if (File.Exists(savePath))
        {

            string json = File.ReadAllText(savePath);
            PlayerDataList data = JsonUtility.FromJson<PlayerDataList>(json);
            Debug.Log("�ҷ����� �Ϸ�");
            return data;
        }
        else
        {
            Debug.LogWarning("����� �����Ͱ� �����ϴ�.");
            return null;
        }
    }

    private void OnApplicationQuit()
    {
        // ���� ����� ���� ����
        if (InventoryManager.Instance != null)
        {
            SaveData(InventoryManager.Instance.GetCurrentData());
        }
    }
}

