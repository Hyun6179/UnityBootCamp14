using System;
using UnityEngine;
//����Ƽ �ν����Ϳ��� ������ ���� ǥ���� Ȯ���ϴ� �ڵ�


public enum Type
{
    ��,��,Ǯ
}

// ���� ���� �����ϴ� ���(Flags)
// ���� 2�� �������� ǥ���� �� �ֽ��ϴ�.
// 2�� �������� ��Ʈ �������� ǥ���ϱⰡ �����ϴ� n << 1�̸� n�� ����, n << 2 �̸� n�� 2����
[Flags] 
public enum Type2
{
    //0���� nothing
    �� = 1 << 0,
    ��Ʈ = 1 << 1, //1���� 1ĭ �̵��ϰڽ��ϴ�. (��Ʈ ����)
    �巡�� = 1 << 2,
    ���� = 1 << 3,
    ���� = 1 << 4
}

public class Variable : MonoBehaviour
{
    //������ �տ� u�� ������ ����� ǥ���ϴ� ���� �ǹ��մϴ�.
    //ex) int�� ǥ�� ������ -2,147,483,648 ~ 2,147,483,647���� ǥ���� �����մϴ�.
    //ex) uint�� ǥ���� ��� 0~4,294,967,295

    //NULL�� "���� ����"�� ��Ÿ���� ��(0�̳� empty�ʹ� �ٸ� ����)

    //����Ƽ / C# �⺻ ������ Ÿ��(primitive)
    //����(int/uint)
    //�Ǽ�(float)
    //��(bool)
    //���ڿ�(string)
    //�� �� ���(nullable) : �ڷ���?�� �ۼ��ϸ� �ش� ���� null�� ����� �� ����.

    public int Integer;
    public float Float;
    public string Sentence;
    public Type type;
    public bool isDead;
    public Type2 type2;

}
