using System;
using UnityEngine;

public class ActionFuncExample : MonoBehaviour
{
    // Action<T>�� �ִ� 16���� �Ű������� ���� �� �ֽ��ϴ�.
    // ��ȯ ���� �����ϴ�.(void)
    // ������ �����̸�, ����� ���� �ʴ� ���� 

    public Action<int> myAction;
    public Action<int, string> myAction2;

    // Func�� �������� ������ �κ��� Func�� ����� �Լ��� ��ȯ Ÿ���Դϴ�. 
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

        if (func01()) // �̶��� func01�� boolŸ��
            Debug.Log("���� ����");
        else
            Debug.Log("���� ����... ");

        func02 = result;
        int point = func02("14");

        func01 = () => point > 10 ? true : false;

    }

    void Rage(int value)
    {
        Debug.Log($"�г�� ���� ���ݷ��� <color=blue><b>{value}</b></color>��ŭ ����մϴ�!");
    }

    void Heal(int value, string character)
    {
        Debug.Log($"ȸ�� �������� <color=yellow><b>{character}</b></color>�� <color=green><b>{value}</b></color>��ŭ ȸ���մϴ�!");
    }

}
