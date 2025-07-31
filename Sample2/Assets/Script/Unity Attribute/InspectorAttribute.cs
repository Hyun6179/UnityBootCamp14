using System.Collections.Generic; // C#���� �������ִ� �ڷᱸ��(List<T>, dictionary<K,V> ���� ��) ��� ����
using System;
using UnityEngine;

public class InspectorAttribute : MonoBehaviour
{
    [Serializable] //
    public struct BOOK // ����� ���� Ÿ�� / Value Ÿ�� / GC �ʿ� ����(���� �������� ������ ���� �Ҵ� / �����ϴ� ���信�� Ȱ�� ex) Vector3)
    {
        public string name;
        public string description;
    }

    [Serializable]
    public class Item // ��ü�� ���� ���赵(�Ӽ��� ���) / ����Ƽ������ class ��� ����
    {
        public string name;
        public string description;
    }


    [Header("score")]
    public int point;
    public int max_point;
    [Header("Info")]
    public string nickname;
    // ���� : ����, ����, �ü�, ������
    public Job myJob; // enum ǥ��

    // �ν����Ϳ� �����ϱ� ���� ���� ���� ����
    [HideInInspector]
    public int value = 5;
    #region ����Ƽ���� �����(private) �ʵ带 �ν����Ϳ� �����Ű�� ����Ƽ�� ����ȭ �ý��ۿ� ���Խ�ŵ�ϴ�.

    // ��� ����
    // public --> ���� + ���� ����
    // private --> ���� X, ���� X
    // SerializeField + private --> ���� X, �ν����Ϳ����� ���� ����

    // �� ����ȭ(Serialization) : �����͸� ���� ������ �������� ��ȯ�ϴ� �۾� 
    // �� ��ȯ�� ���� ��, ������, ���� � �����ϰ� �����ϴ� �۾��� ������ �� �ֽ��ϴ�.

    // ����ȭ ����
    // 1. public or [SerializeField]
    // 2. static�� �ƴ� ���
    // 3. ����ȭ ������ ������ Ÿ���� ���

    // ����ȭ�� ������ ������
    // 1. �⺻ ������(int, float, bool, string ...)
    // 2. ����Ƽ���� �������ִ� ����ü(Vector3, Quaternion, Color)
    // 3. ����Ƽ ��ü ����(GameObject, Transform, Material)
    // 4. [Serializable] �Ӽ��� ���� Ŭ����
    // 5. �迭 or ����Ʈ (����Ƽ������ �迭�� ����Ʈ�� ����)

    // ����ȭ �Ұ����� ������
    // 1. Dictionary<K,V>
    // 2. Interface (�������̽�) <- ����� �� �� ���� �̿ϼ� ������ 
    // 3, static Ű���尡 ���� �ʵ�
    // 4. abstract Ű���尡 ���� Ŭ����

    //[SerializeField]
    //private int value2 = 7;
    #endregion

    // Space(����) : ���� ���̸�ŭ ������ ����ϴ�.

    // TextArea : �� ���ڿ��� ���� �ٷ� ���� �� �ִ� ���� 
    // [TextArea]�� ����� ��� ���� �� �Է��� ������ ���°� �˴ϴ�.
    // [TextArea(�⺻ ǥ�� ��, �ִ� ��)]�� ���� �ν����� �󿡼��� ���̸� �����մϴ�.
    // ���ڿ� ���̿� ���� �������� �κ��� �����ϴ�.
    [Space(30)]
    [TextArea(3, 5)]
    public string quest_info;

    public BOOK book;
    public Item item;
    
    // ����Ƽ �ν����Ϳ����� �迭�� ����Ʈ�� ������ �˴ϴ�.
    // ����Ʈ <T>�� T������ �����͸� �������� ���������� ������ �� �ִ� �������Դϴ�.
    // �������� �˻�, �߰�, �������� ����� �����˴ϴ�.
    public List<Item> item_list;

    public BOOK[] books = new BOOK[5];
    public enum Job // enum�ǿ�Ҵ� ��κ� �빮��
    {
        None,
        Knight,
        Rogue,
        Archer,
        Mage
    }

    //Range(�ּ�, �ִ�)�� ���� �ش� ���� �����Ϳ��� �ּ� ���� �ִ밡 �����Ǿ� �ִ�
    // ��ũ�� ������ ������ ����˴ϴ�.(���� ����)
    [Range(0, 100)] public int bg;
    [Range(0, 100)] public float sfx;

}
