using UnityEngine;
// Attribute : [AddComponentMenu("")]처럼 클래스나 함수, 변수 앞에 붙는 []들은 Attribute(속성)
// 에디터에 대한 확장이나 사용자 정의 툴 제작에서 제공되는 기능들
// 사용목적 : 사용자가 에디터를 더 직관적으로 , 편의적으로 사용하기 위해서.

// 1. AddComponentMenu("그룹이름/기능이름")
// Editor의 Component에 메뉴를 추가하는 기능
// 그룹을 적을 경우 그룹이 지정되며, 아닐 경우에는 기능만 지정됩니다.
// 순서 같은 경우는 다음과 같이 정렬 기준을 가지고 있습니다.
// 1. !,#,$,* 특수문자의 경우 맨앞
// 2. 숫자
// 3. 대문자
// 4. 소문자

[AddComponentMenu("Sample/AddComponentMenu")]
public class MenuAttributes : MonoBehaviour
{
    // [ContextMenuItem("기능으로 표현할 이름","함수의 이름")] ***** 함수의 이름 == 함수의 주소
    // message를 대상으로 MessageReset 기능을 에디터에서 사용할 수 있습니다.
    [ContextMenuItem("메시지 초기화", "MessageReset")]
    public string message = "";

    public void MessageReset()
    {
        message = "";   
    }

    [ContextMenu("경고 메시지 호출")]
    public void MenuAttributesMenu()
    {
        Debug.LogWarning("경고 메시지!");
    }



}
