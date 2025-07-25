using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    public Text text;
    float score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "���� ���� : 0";
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void LateUpdate()
    {
        score = player.GetComponent<SkeletonController>().score;
        text.text = $"���� ���� : {score}";
    }
}
