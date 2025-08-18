using System;
using UnityEngine;

public class ActionFuncExample : MonoBehaviour
{
    // Action<T>는 최대 16개의 매개변수를 받을 수 있습니다.
    // 반환 값은 없습니다.(void)
    // 전달이 목적이며, 결과는 받지 않는 형태 

    public Action<int> myAction;
    public Action<int, string> myAction2;

    // Func는 마지막에 적히는 부분이 Func가 사용할 함수의 반환 타입입니다. 
    public Func<bool> func01;
    public Func<string, int> func02;

    int result(string s) => int.Parse(s);

    bool AttackAble()
    {
        int rand = UnityEngine.Random.Range(0, 10);
        return rand >= 3 ? true : false ;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAction += Rage;
        //myAction +=Heal;
        //myAction2 += Rage;
        myAction2 += Heal;

        myAction(50);
        myAction2(40, "Steve");

        func01 = AttackAble;

        if (func01()) // 이때의 func01은 bool타입
            Debug.Log("공격 성공");
        else
            Debug.Log("공격 실패... ");

        func02 = result;
        int point = func02("14");

        func01 = () => point > 10 ? true : false;

    }

    void Rage(int value)
    {
        Debug.Log($"분노로 인해 공격력이 <color=blue><b>{value}</b></color>만큼 상승합니다!");
    }

    void Heal(int value, string character)
    {
        Debug.Log($"회복 마법으로 <color=yellow><b>{character}</b></color>가 <color=green><b>{value}</b></color>만큼 회복합니다!");
    }

}
