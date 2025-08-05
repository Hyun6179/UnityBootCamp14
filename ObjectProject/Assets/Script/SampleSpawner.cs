using UnityEngine;

public class SampleSpawner : MonoBehaviour
{
    // 해당 오브젝트가 없을 때 오브젝트를 생성하고, 컴포넌트를 부여하기
    void Start()
    {
        GameObject sample = GameObject.Find("Sample");

        if (sample == null)
        {
            GameObject go = new GameObject("Sample");
            go.AddComponent<Sample>();
        }
        else
        {
            Debug.Log("이미 존재합니다.");
        }
    }
}
