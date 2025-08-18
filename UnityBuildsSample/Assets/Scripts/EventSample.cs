using System;
using UnityEngine;
// C#�� Event
// Ŭ���̳� ��ġ�� ���� ������ ó���ϴ� �ϳ��� �ý���

// ������(Publisher)
// ������� �ൿ�� ��ٸ��ٰ� �����ڿ��� �˷��ִ� ������ �����մϴ�.


// ������(Subscribers)
// �̺�Ʈ �����ڿ� ���� ������ ���� ������� �ൿ�� ���޹޾Ƽ� �����ϴ� ������
// �����մϴ�.


// �������� ��� �������� �ൿ ��ü�� �����ڰ� �˾ƾ� �� �ʿ�� ���� ����.
// �������� ��� ���к��ϰ� ������ ��� ���� �����ڵ��� ����� ����� �� ����.

// event ����� ���ؼ� System ���ӽ����̽��� ����ؾ� �մϴ�.

public class EventSample : MonoBehaviour
{
    public event EventHandler OnSpaceEnter;
    // �̺�Ʈ ������ �̸��� ���� On + ���� / ������ ��������ϴ�.

    // C#���� �������ִ� delegate Ÿ��
    // EventHandler�� ��� ��ġ�� Ŭ�� ���� �̺�Ʈ�� �����ϴ� �뵵
    // �Ű�����
    // Object sender <- ObjectŸ���� �����͸� ���޹��� �� ������,
    // �̺�Ʈ�� �߻���Ų ����� �ǹ��մϴ�.

    // EventArgs e <- �̺�Ʈ�� ���õ� �����͸� ��� �ִ� ��ü�� �ǹ��մϴ�.
    // �ش� ���� EventArgs �Ǵ� �ش� �ڽ� Ŭ������ �� �� �ֽ��ϴ�.


    private void Start()
    {   
        // ���� ���
        // �̺�Ʈ�� += ���¿� �´� �޼ҵ� �̸�;
        OnSpaceEnter += Debug_OnSpaceEnter;
    }

    // Update is called once per frame
    void Update()
    {
        // 1) �̺�Ʈ ���� ��� �̺�Ʈ��(this, EventArgs.Empty)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Null �˻縦 �����ϰ� ����(�̺�Ʈ ������ �ȵǾ����� ��쿡�� �����ϸ� �ȵǱ� ����)
            if(OnSpaceEnter != null)
            {
                OnSpaceEnter(this, EventArgs.Empty);
            }
            // this : �̺�Ʈ�� �߻���Ų ��ü(���� Ŭ����)
            // EventArgs.Empty : �̺�Ʈ ���࿡ �־� Ư���� �߰��Ǵ� �����Ͱ� ������ �ǹ��մϴ�.
        }

        // 2) �̺�Ʈ ���� ��� Invoke �Լ��� ����ϴ� ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpaceEnter?.Invoke(this, EventArgs.Empty);
            // ?.�� ���� Null�� �ƴ� �� ó���ǵ��� �Ѵ�.

            // int?�� ���� �ڷ����� ?�� ���̰� Nullable �� Ÿ������ ����ϴ� ���
            // ������������ null���� ���� �� �ְ� ���ټ� �ְ� ���ݴϴ�.
            // Ÿ���� ������ �� ���˴ϴ�
            // �� ������ Ÿ�Կ� ���˴ϴ�.

            // ?.�� ���·� ���̴� ��� Null ���� �����ڷ� ����ϴ� ���
            // ��ü�� Null�� �ƴ� ���� ����� ���� ȣ���� �����ϵ��� �����մϴ�.
            // �޼ҵ�, �Ӽ�(Property), �̺�Ʈ ���� ȣ�� �ÿ� ���˴ϴ�.
            // ���۷��� ������ Ÿ�� �Ǵ� Nullable ��ü�� ������� ����մϴ�.

            // >> if(obj != null) ������ �ڵ� ��� ����մϴ�.


        }
    }

    private void Debug_OnSpaceEnter(object sender, EventArgs g)
    {
        Debug.Log("<color=yellow>���� Ű �Է� �̺�Ʈ ���� </color>");
    }
}
