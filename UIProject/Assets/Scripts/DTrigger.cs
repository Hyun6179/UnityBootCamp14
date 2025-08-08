using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DTrigger : MonoBehaviour
{
    public List<Dialog> scripts; // IEnumerable�� ������ �����̱� ������ List ��� ����

    public void OnDTriggerEnter()
    {
        if(scripts != null && scripts.Count > 0)
        {
            DialogManager.Instance.StartLine(scripts);
            // Ŭ������.Instance.�޼ҵ��()�� ���� Ŭ������ ���� �ٷ� ����� �� �ֽ��ϴ�.
            // ���� ���� GetComponent�� public������ ����ؼ� ����� �ʿ䰡 ���� ���մϴ�.
        }
    }
}
