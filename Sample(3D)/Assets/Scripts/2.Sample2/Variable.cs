using System;
using UnityEngine;
//유니티 인스펙터에서 변수에 대한 표현을 확인하는 코드


public enum Type
{
    불,물,풀
}

// 여러 개를 선택하는 기능(Flags)
// 값을 2의 제곱수로 표현할 수 있습니다.
// 2의 제곱수는 비트 연산으로 표현하기가 쉽습니다 n << 1이면 n의 제곱, n << 2 이면 n의 2제곱
[Flags] 
public enum Type2
{
    //0번은 nothing
    독 = 1 << 0,
    고스트 = 1 << 1, //1에서 1칸 이동하겠습니다. (비트 연산)
    드래곤 = 1 << 2,
    얼음 = 1 << 3,
    전기 = 1 << 4
}

public class Variable : MonoBehaviour
{
    //데이터 앞에 u가 붙으면 양수만 표현하는 것을 의미합니다.
    //ex) int의 표현 범위는 -2,147,483,648 ~ 2,147,483,647까지 표현이 가능합니다.
    //ex) uint로 표현할 경우 0~4,294,967,295

    //NULL은 "값이 없음"을 나타내는 값(0이나 empty와는 다른 개념)

    //유니티 / C# 기본 데이터 타입(primitive)
    //정수(int/uint)
    //실수(float)
    //논리(bool)
    //문자열(string)
    //널 값 허용(nullable) : 자료형?로 작성하면 해당 값은 null을 사용할 수 있음.

    public int Integer;
    public float Float;
    public string Sentence;
    public Type type;
    public bool isDead;
    public Type2 type2;

}
