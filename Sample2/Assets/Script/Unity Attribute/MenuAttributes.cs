using UnityEngine;
// Attribute : [AddComponentMenu("")]ó�� Ŭ������ �Լ�, ���� �տ� �ٴ� []���� Attribute(�Ӽ�)
// �����Ϳ� ���� Ȯ���̳� ����� ���� �� ���ۿ��� �����Ǵ� ��ɵ�
// ������ : ����ڰ� �����͸� �� ���������� , ���������� ����ϱ� ���ؼ�.

// 1. AddComponentMenu("�׷��̸�/����̸�")
// Editor�� Component�� �޴��� �߰��ϴ� ���
// �׷��� ���� ��� �׷��� �����Ǹ�, �ƴ� ��쿡�� ��ɸ� �����˴ϴ�.
// ���� ���� ���� ������ ���� ���� ������ ������ �ֽ��ϴ�.
// 1. !,#,$,* Ư�������� ��� �Ǿ�
// 2. ����
// 3. �빮��
// 4. �ҹ���

[AddComponentMenu("Sample/AddComponentMenu")]
public class MenuAttributes : MonoBehaviour
{
    // [ContextMenuItem("������� ǥ���� �̸�","�Լ��� �̸�")] ***** �Լ��� �̸� == �Լ��� �ּ�
    // message�� ������� MessageReset ����� �����Ϳ��� ����� �� �ֽ��ϴ�.
    [ContextMenuItem("�޽��� �ʱ�ȭ", "MessageReset")]
    public string message = "";

    public void MessageReset()
    {
        message = "";   
    }

    [ContextMenu("��� �޽��� ȣ��")]
    public void MenuAttributesMenu()
    {
        Debug.LogWarning("��� �޽���!");
    }



}
