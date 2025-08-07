using System;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    public Button button01;
    public Text message;
    public Text icon_text;

    // 배열이 그 값을 가진 채로 생성됩니다.
    // 자료형[] 배열명 = new 자료형[] {
    // 값1, 값2, 값3
    // };
    public string[] materials = new string[]
    {
        "골드 100",
        "골드 100+루비",
        "골드 200+사파이어+마력석",
        "최대 강화 완료"
    };

    // max_level을 사용할 경우 배열의 길이 -1의 값을 가지게 됩니다.

    [HideInInspector]
    public int upgrade = 0;
    [HideInInspector]
    public int max_level => materials.Length -1;
    // 배열에는 Index라는 개녕이 존재합니다.
    // ex) materials가 하나의 묶음이고, 거기서 2번째 데이터는 materials[1]입니다.
    //     카운트를 0부터 시작.

    private void Start()
    {
        button01.onClick.AddListener(OnUpgradeBtnClick);
        // AddListener는 유니티의 UI의 이벤트에 기능을 연결해주는 코드
        // 전달할 수 있는 값의 형태가 정해져있어서 그 형태대로 설계 해줘야 합니다.
        // 다른 형태로 쓰는 경우(매개변수가 다른 경우)라면 delegate를 활용합니다.
        // 특징) 이 기능을 통해 이벤트에 기능을 전달한다면
        // 유니티 인스펙터에서 연결된 걸 확인 할 수 없습니다.

        // 장점 : 직접 등록하지 않아서 잘못 넣을 확률이 낮아집니다.
        UpdateUI();
        // 시작 시 UI에 대한 렌더링 설정


    }
    // 버튼 클릭 시 호출할 메소드 설계
    private void OnUpgradeBtnClick()
    {
        if (upgrade < max_level)
        {
            UnitInventory iv = GetComponent<UnitInventory>();
            if (upgrade == 0)
            {
                if (iv.g < 100)
                {
                    Debug.Log("강화에 필요한 재화가 없습니다");
                }
                else
                {
                    upgrade++;
                    UpdateUI();
                    iv.g -= 100;
                }
            }
            else if (upgrade == 1)
            {
                if (iv.g < 100 || iv.r < 1)
                {
                    Debug.Log("강화에 필요한 재화가 없습니다");
                }
                else
                {
                    upgrade++;
                    UpdateUI();
                    iv.g -= 100;
                    iv.r -= 1;
                }
            }
            else if (upgrade == 2)
            {
                if (iv.g < 200 || iv.s < 1 || iv.m < 1)
                {
                    Debug.Log("강화에 필요한 재화가 없습니다");
                }
                else
                {
                    upgrade++;
                    UpdateUI();
                    iv.g -= 200;
                    iv.s -= 1;
                    iv.m -= 1;
                }
            }
        }
    }

    private void UpdateUI()
    {
        icon_text.text = $"Wizard + {upgrade}";
        
        message.text = materials[upgrade].ToString();
        
        UnitStat stat = GetComponent<UnitStat>();
        stat.Upgrade();
    }
}
