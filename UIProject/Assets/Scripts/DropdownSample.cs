using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// ��� �ٿ��� ���� ���
// 1. Template : ��� �ٿ��� �������� ��, ���̴� ����Ʈ �׸�
// 2. Caption / Item Text : ���� ���õ� �׸� / ����Ʈ �׸� ������ ���� �ؽ�Ʈ
//    TMP�� ���� ���, �ѱ� ����� ���� Label�� Item Label���� ��� ���� ��Ʈ�� ������ �ּž� ����� �� �ֽ��ϴ�.

// 3. Options : ��� �ٿ ǥ�õ� �׸� ���� ����Ʈ
//    �ν����͸� ���� ���� ����� �����մϴ�.
//    ����ϸ� �ٷ� ����Ʈ�� ����˴ϴ�.

// 4. On Value Changed : ����ڰ� �׸��� �������� �� ȣ��Ǵ� �̺�Ʈ
//    �ν����͸� ���� ���� ����� �� �ֽ��ϴ�.
//    ��� �ٿ� ���� ���� ���� �߻� �� ȣ��˴ϴ�.

public class DropdownSample : MonoBehaviour
{
    public TMP_Dropdown job_dropdown;
    public TMP_Dropdown gender_dr;
    public TMP_Dropdown weapon_dr;
    public TMP_Dropdown tribe_dr;
    public TMP_Text status_text;
    public Button button;

   
    private string job;
    private string gender;
    private string weapon;
    private string tribe;
    // Options�� ����� ���� ���ڿ�

    // ����Ʈ�� ���� �ְ� �����ϴ� ���
    // ����Ʈ<T> ����Ʈ�� = new ����Ʈ��<T> {���, ���2, ���3 };
    private List<string> job_options = new List<string>() { "","����", "������", "�ü�", "����" };
    private List<string> gender_options = new List<string>() { "","��","��" };
    private List<string> weapon_options = new List<string>() { "","������", "������", "Ȱ", "ǥâ"};
    private List<string> tribe_options = new List<string>() { "", "�ΰ�", "��ũ", "����", "���" };

    private void Start()
    {
        job_dropdown.ClearOptions(); // ��Ӵٿ��� Option ����� �����ϴ� �ڵ�
        gender_dr.ClearOptions();
        weapon_dr.ClearOptions();
        tribe_dr.ClearOptions();
        //dropdown.AddOptions(job_options); // �غ�� ��ܿ� ���� �߰�
        job_dropdown.AddOptions(job_options);
        gender_dr.AddOptions(gender_options);
        weapon_dr.AddOptions(weapon_options);
        tribe_dr.AddOptions(tribe_options);


        job_dropdown.onValueChanged.AddListener(onClassEnter);
        gender_dr.onValueChanged.AddListener(onGendersEnter);
        weapon_dr.onValueChanged.AddListener(onWeaponEnter);
        tribe_dr.onValueChanged.AddListener(onTribleEnter);

        button.onClick.AddListener(setStatus);

        //dropdown.onValueChanged.AddListener(onDropdownValueChanged);
        // �̺�Ʈ ��Ͻ� �䱸�ϴ� ���´�� �ۼ��� �Ǿ��ٸ�
        // �Լ��� �̸����� ����� �� �ְ� �˴ϴ�. 
    }

    //C# System.int32 -> int
    //   System.int64 -> long
    //   System.Uint32 -> unsigned int(��ȣ�� ���� 32��Ʈ ����) (0 ~ 4,294,967,295)
    //void onDropdownValueChanged(Int32 idx)
    //{
    //    Debug.Log("���� ���õ� �޴��� " + dropdown.options[idx].text);
    //    // �ɼ� ����Ʈ�� idx��° ���� ���� �ؽ�Ʈ
    //}

    void onClassEnter(Int32 index)
    {
        job = job_dropdown.options[index].text;
    }
    void onGendersEnter(Int32 index)
    {
        gender = gender_dr.options[index].text;
    }
    void onWeaponEnter(Int32 index)
    {
        weapon = weapon_dr.options[index].text;
    }

    void onTribleEnter(Int32 index)
    {
        tribe = tribe_dr.options[index].text;
    }

    void setStatus()
    {
        status_text.text = $"���� : {job}\n���� : {gender}\n���� : {weapon}\n���� : {tribe}";
    }
}
