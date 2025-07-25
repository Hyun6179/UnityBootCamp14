using UnityEngine;

/*
 Sample2 Script를 만들어서 다음 변수 구현합니다.
 화면에서 field of view는 스크롤 대신 값만 구현합니다. 
 */
public enum Projection
{
    Perspective,
    Orthographic
}

public enum Field_Of_View_Axis
{
    Vertical, 
    Horizontal
}

public class Sample2 : MonoBehaviour
{
    public Projection Projection;
    public Field_Of_View_Axis FieldOfViewAxis;
    public float FieldOfView;
    public float ClippingPlanesNear;
    public float ClippingPlanesFar;
    public bool PhysicalCamera;
    // 대문자로 시작하면 자동 띄어쓰기

}
