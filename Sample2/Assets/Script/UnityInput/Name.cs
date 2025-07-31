using System;
using UnityEngine;
using UnityEngine.UI;

public class Name : MonoBehaviour
{
    public Text name;
    Enchant enchant;
    // 강화 수치는 강화 확률에서 호출
    // 강화 수치를 level이라는 이름으로 호출 -> 이름 {level}강
    private void Start()
    {
       enchant = GetComponent<Enchant>();
    }

    private void Update()
    {
        name.text = $"나무 몽둥이 {enchant.level}강";
    }


}
