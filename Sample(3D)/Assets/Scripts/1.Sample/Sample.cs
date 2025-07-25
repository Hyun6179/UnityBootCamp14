using UnityEngine;
using UnityEngine.UI;

public class Sample : MonoBehaviour
{
    public Text text;
    public GameObject player;
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "score : 0";
    }

    // Update is called once per frame
    void LateUpdate()
    {
        score = player.GetComponent<PlayerController>().score;
        text.text = $"score : {score}";
    }
}
