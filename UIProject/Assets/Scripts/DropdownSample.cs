using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// 드롭 다운의 구성 요소
// 1. Template : 드롭 다운이 펼쳐졌을 때, 보이는 리스트 항목
// 2. Caption / Item Text : 현재 선택된 항목 / 리스트 항목 각각에 대한 텍스트
//    TMP를 쓰는 경우, 한글 사용을 위해 Label과 Item Label에서 사용 중인 폰트를 수정해 주셔야 사용할 수 있습니다.

// 3. Options : 드롭 다운에 표시될 항목에 대한 리스트
//    인스펙터를 통해 직접 등록이 가능합니다.
//    등록하면 바로 리스트에 적용됩니다.

// 4. On Value Changed : 사용자가 항목을 선택했을 때 호출되는 이벤트
//    인스펙터를 통해 직접 등록할 수 있습니다.
//    드롭 다운 값에 대한 변경 발생 시 호출됩니다.

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
    // Options에 등록할 값은 문자열

    // 리스트에 값을 넣고 생성하는 방법
    // 리스트<T> 리스트명 = new 리스트명<T> {요소, 요소2, 요소3 };
    private List<string> job_options = new List<string>() { "","전사", "마법사", "궁수", "도적" };
    private List<string> gender_options = new List<string>() { "","남","여" };
    private List<string> weapon_options = new List<string>() { "","몽둥이", "지팡이", "활", "표창"};
    private List<string> tribe_options = new List<string>() { "", "인간", "오크", "엘프", "고블린" };

    private void Start()
    {
        job_dropdown.ClearOptions(); // 드롭다운의 Option 명단을 제거하는 코드
        gender_dr.ClearOptions();
        weapon_dr.ClearOptions();
        tribe_dr.ClearOptions();
        //dropdown.AddOptions(job_options); // 준비된 명단에 대한 추가
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
        // 이벤트 등록시 요구하는 형태대로 작성이 되었다면
        // 함수의 이름으로 사용할 수 있게 됩니다. 
    }

    //C# System.int32 -> int
    //   System.int64 -> long
    //   System.Uint32 -> unsigned int(부호가 없는 32비트 정수) (0 ~ 4,294,967,295)
    //void onDropdownValueChanged(Int32 idx)
    //{
    //    Debug.Log("현재 선택된 메뉴는 " + dropdown.options[idx].text);
    //    // 옵션 리스트의 idx번째 값에 대한 텍스트
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
        status_text.text = $"직업 : {job}\n성별 : {gender}\n무기 : {weapon}\n종족 : {tribe}";
    }
}
